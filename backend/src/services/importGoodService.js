import sql from 'mssql'

import { transError } from './../constants/languageEn'

const getAllImportReceipt = pool => {
  return new Promise(async (resolve, reject) => {
    try {
      let receiptResult = await pool.request()
        .query(`
          SELECT
            NK.Id,
            NK.Ma,
            NK.NgayNhap,
            NK.TongTien,
            NK.GhiChu,
            NK.IdNhanVien,
            NV.Ten AS TenNhanVien,
            NK.IdNhaCungCap,
            NCC.Ten AS TenNhaCungCap,
            NK.IdKho,
            K.Ten AS TenKho
          FROM dbo.NhapKho NK
          INNER JOIN dbo.Kho K ON K.Id = NK.IdKho
          INNER JOIN dbo.NhanVien NV ON NV.Id = NK.IdNhanVien
          INNER JOIN dbo.NhaCungCap NCC ON NCC.Id = NK.IdNhaCungCap
        `)

        return resolve(receiptResult.recordset)
    } catch (error) {
      return reject(error)
    }
  })
}

const getImportReceiptDetailById = (pool, receiptId) => {
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
            C.GhiChu
          FROM dbo.ChiTietNhapKho C
          INNER JOIN dbo.VatTu V ON V.Id = C.IdVatTu
          WHERE C.IdNhapKho = @Id
        `)

        return resolve(receiptResult.recordset)
    } catch (error) {
      return reject(error)
    }
  })
}

const addNewImportReceiptInfo = (pool, importReceipt) => {
  return new Promise(async (resolve, reject) => {
    try {
      let receiptResult = await pool.request()
        .input('Ma', sql.NVarChar(50), importReceipt.Ma)
        .input('NgayNhap', sql.Date, importReceipt.NgayNhap)
        .input('IdNhaCungCap', sql.Int, importReceipt.IdNhaCungCap)
        .input('IdNhanVien', sql.Int, importReceipt.IdNhanVien)
        .input('IdKho', sql.Int, importReceipt.IdKho)
        .input('GhiChu', sql.NVarChar(250), importReceipt.GhiChu)
        .output('Id', sql.Int)
        .execute('dbo.Usp_AddNewImportGoodReceipt')

      if (receiptResult.output.Id) {
        return resolve(receiptResult.output.Id)
      } else {
        return reject(transError.add_import_receipt)
      }
    } catch (error) {
      return reject(error)
    }
  })
}

const addOrUpdateImportReceiptDetail = (pool, receiptId, product) => {
  return new Promise(async (resolve, reject) => {
    try {
      let receiptResult = await pool.request()
        .input('IdVatTu', sql.Int, product.Id)
        .input('IdNhapKho', sql.Int, receiptId)
        .input('SoLuong', sql.Int, product.SoLuong)
        .input('GhiChu', sql.NVarChar(250), product.GhiChu)
        .output('TongTien', sql.Decimal(18, 2))
        .execute('dbo.Usp_AddOrUpdateImportReceiptDetail')

      if (receiptResult.output.TongTien) {
        return resolve(receiptResult.output.TongTien)
      } else {
        return reject(transError.add_update_import_receipt_detail)
      }
    } catch (error) {
      return reject(error)
    }
  })
}

const updateImportReceiptInfo = (pool, importReceipt) => {
  return new Promise(async (resolve, reject) => {
    try {
      let receiptResult = await pool.request()
        .input('Ma', sql.NVarChar(50), importReceipt.Ma)
        .input('NgayNhap', sql.Date, importReceipt.NgayNhap)
        .input('IdNhaCungCap', sql.Int, importReceipt.IdNhaCungCap)
        .input('IdNhanVien', sql.Int, importReceipt.IdNhanVien)
        .input('GhiChu', sql.NVarChar(250), importReceipt.GhiChu)
        .input('Id', sql.Int, importReceipt.Id)
        .query(`
          UPDATE NhapKho
          SET Ma = @Ma,
              NgayNhap = @NgayNhap,
              IdNhaCungCap = @IdNhaCungCap,
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
  addNewImportReceiptInfo,
  addOrUpdateImportReceiptDetail,
  updateImportReceiptInfo,
  getAllImportReceipt,
  getImportReceiptDetailById
}
