import sql from 'mssql'

import { transError } from './../constants/languageEn'

const getAllExchangeReceipt = pool => {
  return new Promise(async (resolve, reject) => {
    try {
      let receiptResult = await pool.request()
        .query(`
          SELECT
            CK.Id,
            CK.Ma,
            CK.NgayChuyen,
            CK.TongTien,
            CK.GhiChu,
            CK.IdNhanVien,
            NV.Ten AS TenNhanVien,
            CK.IdKhoCu,
            KC.Ten AS TenKhoCu,
            CK.IdKhoMoi,
            KM.Ten AS TenKhoMoi
          FROM dbo.ChuyenKho CK
          INNER JOIN dbo.NhanVien NV ON NV.Id = CK.IdNhanVien
          INNER JOIN dbo.Kho KC ON KC.Id = CK.IdKhoCu
          INNER JOIN dbo.Kho KM ON KM.Id = CK.IdKhoMoi
        `)

        return resolve(receiptResult.recordset)
    } catch (error) {
      return reject(error)
    }
  })
}

const getExchangeReceiptDetailById = (pool, receiptId) => {
  return new Promise(async (resolve, reject) => {
    try {
      let receiptResult = await pool.request()
        .input('Id', sql.Int, receiptId)
        .query(`
          SELECT 
            C.IdVatTu,
            V.Ten AS TenVatTu,
            C.DonGia,
            C.SoLuong,
            C.ThanhTien,
            C.LyDo
          FROM dbo.ChiTietChuyenKho C
          INNER JOIN dbo.VatTu V ON V.Id = C.IdVatTu
          WHERE C.IdChuyenKho = @Id
        `)

        return resolve(receiptResult.recordset)
    } catch (error) {
      return reject(error)
    }
  })
}

const addNewExchangeReceiptInfo = (pool, exchangeReceipt) => {
  return new Promise(async (resolve, reject) => {
    try {
      let receiptResult = await pool.request()
        .input('Ma', sql.NVarChar(50), exchangeReceipt.Ma)
        .input('NgayChuyen', sql.Date, exchangeReceipt.NgayChuyen)
        .input('IdNhanVien', sql.Int, exchangeReceipt.IdNhanVien)
        .input('IdKhoCu', sql.Int, exchangeReceipt.IdKhoCu)
        .input('IdKhoMoi', sql.Int, exchangeReceipt.IdKhoMoi)
        .input('GhiChu', sql.NVarChar(250), exchangeReceipt.GhiChu)
        .output('Id', sql.Int)
        .execute('dbo.Usp_AddNewExchangeGoodReceipt')

      if (receiptResult.output.Id) {
        return resolve(receiptResult.output.Id)
      } else {
        return reject(transError.add_exchange_receipt)
      }
    } catch (error) {
      return reject(error)
    }
  })
}

const addOrUpdateExchangeReceiptDetail = (pool, receiptId, product) => {
  return new Promise(async (resolve, reject) => {
    try {
      let receiptResult = await pool.request()
        .input('IdVatTu', sql.Int, product.Id)
        .input('IdChuyenKho', sql.Int, receiptId)
        .input('SoLuong', sql.Int, product.SoLuong)
        .input('LyDo', sql.NVarChar(250), product.GhiChu)
        .output('TongTien', sql.Decimal(18, 2))
        .execute('dbo.Usp_AddOrUpdateExchangeReceiptDetail')

      if (receiptResult.output.TongTien) {
        return resolve(receiptResult.output.TongTien)
      } else {
        return reject(transError.add_update_exchange_receipt_detail)
      }
    } catch (error) {
      return reject(error)
    }
  })
}

const updateExchangeReceiptInfo = (pool, exchangeReceipt) => {
  return new Promise(async (resolve, reject) => {
    try {
      let receiptResult = await pool.request()
        .input('Ma', sql.NVarChar(50), exchangeReceipt.Ma)
        .input('NgayChuyen', sql.Date, exchangeReceipt.NgayChuyen)
        .input('IdNhanVien', sql.Int, exchangeReceipt.IdNhanVien)
        .input('GhiChu', sql.NVarChar(250), exchangeReceipt.GhiChu)
        .input('Id', sql.Int, exchangeReceipt.Id)
        .query(`
          UPDATE ChuyenKho
          SET Ma = @Ma,
              NgayChuyen = @NgayChuyen,
              IdNhanVien = @IdNhanVien,
              GhiChu = @GhiChu,
              UpdatedAt = GETDATE()
          WHERE Id = @Id
        `)

      resolve(receiptResult)
    } catch (error) {
      return reject(error)
    }
  })
}


module.exports = {
  addNewExchangeReceiptInfo,
  addOrUpdateExchangeReceiptDetail,
  updateExchangeReceiptInfo,
  getAllExchangeReceipt,
  getExchangeReceiptDetailById
}
