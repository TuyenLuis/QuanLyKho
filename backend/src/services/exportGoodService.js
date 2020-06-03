import sql from 'mssql'

import { transError } from './../constants/languageEn'

const getAllExportReceipt = pool => {
  return new Promise(async (resolve, reject) => {
    try {
      let receiptResult = await pool.request()
        .query(`
          SELECT 
            XK.Id,
            XK.Ma,
            XK.NgayXuat,
            XK.DiaChi,
            XK.TongTien,
            XK.GhiChu,
            XK.IdNhanVien,
            NV.Ten AS TenNhanVien,
            XK.IdKho,
            K.Ten AS TenKho
          FROM dbo.XuatKho XK
          INNER JOIN dbo.NhanVien NV ON NV.Id = XK.IdNhanVien
          INNER JOIN dbo.Kho K ON K.Id = XK.IdKho
        `)

        return resolve(receiptResult.recordset)
    } catch (error) {
      return reject(error)
    }
  })
}

const getExportReceiptDetailById = (pool, receiptId) => {
  return new Promise(async (resolve, reject) => {
    try {
      let receiptResult = await pool.request()
        .input('Id', sql.Int, receiptId)
        .query(`
          SELECT  X.Id ,
                  X.Ma ,
                  X.NgayXuat ,
                  X.DiaChi ,
                  X.TongTien ,
                  X.GhiChu AS GhiChuPhieu ,
                  X.IdNhanVien ,
                  NV.Ten AS TenNhanVien ,
                  X.IdKho ,
                  K.Ten AS TenKho ,
                  C.IdVatTu ,
                  V.Ten AS TenVatTu ,
                  C.DonGia ,
                  C.SoLuong ,
                  C.ThanhTien ,
                  C.GhiChu
          FROM    dbo.ChiTietXuatKho C
                  INNER JOIN dbo.VatTu V ON V.Id = C.IdVatTu
                  INNER JOIN dbo.XuatKho X ON X.Id = C.IdXuatKho
                  INNER JOIN dbo.NhanVien NV ON NV.Id = X.IdNhanVien
                  INNER JOIN dbo.Kho K ON K.Id = X.IdKho
          WHERE   C.IdXuatKho = @Id
        `)

        return resolve(receiptResult.recordset)
    } catch (error) {
      return reject(error)
    }
  })
}

const addNewExportReceiptInfo = (pool, exportReceipt) => {
  return new Promise(async (resolve, reject) => {
    try {
      let receiptResult = await pool.request()
        .input('Ma', sql.NVarChar(50), exportReceipt.Ma)
        .input('NgayXuat', sql.Date, exportReceipt.NgayXuat)
        .input('DiaChi', sql.NVarChar(250), exportReceipt.DiaChi)
        .input('IdNhanVien', sql.Int, exportReceipt.IdNhanVien)
        .input('IdKho', sql.Int, exportReceipt.IdKho)
        .input('GhiChu', sql.NVarChar(250), exportReceipt.GhiChu)
        .output('Id', sql.Int)
        .execute('dbo.Usp_AddNewExportGoodReceipt')

      if (receiptResult.output.Id) {
        return resolve(receiptResult.output.Id)
      } else {
        return reject(transError.add_export_receipt)
      }
    } catch (error) {
      return reject(error)
    }
  })
}

const addOrUpdateExportReceiptDetail = (pool, receiptId, product) => {
  return new Promise(async (resolve, reject) => {
    try {
      let receiptResult = await pool.request()
        .input('IdVatTu', sql.Int, product.Id)
        .input('IdXuatKho', sql.Int, receiptId)
        .input('SoLuong', sql.Int, product.SoLuong)
        .input('GhiChu', sql.NVarChar(250), product.GhiChu)
        .output('TongTien', sql.Decimal(18, 2))
        .execute('dbo.Usp_AddOrUpdateExportReceiptDetail')

      if (receiptResult.output.TongTien) {
        return resolve(receiptResult.output.TongTien)
      } else {
        return reject(transError.add_update_export_receipt_detail)
      }
    } catch (error) {
      return reject(error)
    }
  })
}

const updateExportReceiptInfo = (pool, exportReceipt) => {
  return new Promise(async (resolve, reject) => {
    try {
      let receiptResult = await pool.request()
        .input('Ma', sql.NVarChar(50), exportReceipt.Ma)
        .input('NgayXuat', sql.Date, exportReceipt.NgayXuat)
        .input('DiaChi', sql.NVarChar(250), exportReceipt.DiaChi)
        .input('IdNhanVien', sql.Int, exportReceipt.IdNhanVien)
        .input('GhiChu', sql.NVarChar(250), exportReceipt.GhiChu)
        .input('Id', sql.Int, exportReceipt.Id)
        .query(`
          UPDATE XuatKho
          SET Ma = @Ma,
              NgayXuat = @NgayXuat,
              DiaChi = @DiaChi,
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

const removeExportReceipt = (pool, receiptId) => {
  return new Promise(async (resolve, reject) => {
    try {
      let receiptResult = await pool.request()
        .input('Id', sql.Int, receiptId)
        .query(`
          DELETE ChiTietXuatKho
          WHERE IdXuatKho = @Id;

          DELETE XuatKho
          WHERE Id = @Id;
        `)

      resolve(receiptResult)
    } catch (error) {
      return reject(error)
    }
  })
}


module.exports = {
  addNewExportReceiptInfo,
  addOrUpdateExportReceiptDetail,
  updateExportReceiptInfo,
  getAllExportReceipt,
  getExportReceiptDetailById,
  removeExportReceipt
}
