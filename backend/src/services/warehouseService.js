import sql from 'mssql'

import { transError } from './../constants/languageEn'

const getAllWarehouse = pool => {
  return new Promise(async (resolve, reject) => {
    try {
      let listWarehouseResult = await pool.request()
        .query(`
          SELECT
            K.Id,
            K.Ma,
            K.Ten,
            K.DiaChi,
            K.SDT,
            K.GhiChu,
            K.IdQuanLy,
            N.Ten AS TenQuanLy
          FROM Kho K
          LEFT JOIN NhanVien N ON N.Id = K.IdQuanLy
          WHERE IsActive = 1
        `)
      resolve(listWarehouseResult.recordset)
    } catch (error) {
      return reject(error)
    }
  })
}

const addNewWarehouse = (pool, warehouse) => {
  return new Promise(async (resolve, reject) => {
    try {
      let warehouseResult = await pool.request()
        .input('Ma', sql.NVarChar(50), warehouse.Ma)
        .input('Ten', sql.NVarChar(50), warehouse.Ten)
        .input('DiaChi', sql.NVarChar(50), warehouse.DiaChi)
        .input('SDT', sql.NVarChar(50), warehouse.SDT)
        .input('GhiChu', sql.NVarChar(250), warehouse.GhiChu)
        .input('IdQuanLy', sql.Int, warehouse.IdQuanLy)
        .output('Id', sql.Int)
        .execute('dbo.Usp_AddNewWarehouse')

      if (warehouseResult.output.Id) {
        return resolve(warehouseResult.output.Id)
      } else {
        return reject(transError.add_warehouse)
      }
    } catch (error) {
      return reject(error)
    }
  })
}

const updateWarehouse = (pool, warehouse) => {
  return new Promise(async (resolve, reject) => {
    try {
      let warehouseResult = await pool.request()
        .input('Ma', sql.NVarChar(50), warehouse.Ma)
        .input('Ten', sql.NVarChar(50), warehouse.Ten)
        .input('DiaChi', sql.NVarChar(50), warehouse.DiaChi)
        .input('SDT', sql.NVarChar(50), warehouse.SDT)
        .input('GhiChu', sql.NVarChar(50), warehouse.GhiChu)
        .input('IdQuanLy', sql.Int, warehouse.IdQuanLy)
        .input('Id', sql.Int, warehouse.Id)
        .query(`
          UPDATE Kho
          SET Ma = @Ma,
              Ten = @Ten,
              DiaChi = @DiaChi,
              SDT = @SDT,
              GhiChu = @GhiChu,
              IdQuanLy = @IdQuanLy,
              UpdatedAt = GETDATE()
          WHERE Id = @Id
        `)

      return resolve(warehouseResult)
    } catch (error) {
      return reject(error)
    }
  })
}

const removeWarehouse = (pool, warehouseId) => {
  return new Promise(async (resolve, reject) => {
    try {
      let warehouseResult = await pool.request()
        .input('warehouseId', sql.Int, warehouseId)
        .query('UPDATE Kho SET IsActive = 0 WHERE Id = @warehouseId')

      return resolve(warehouseResult)
    } catch (error) {
      return reject(error)
    }
  })
}

const getListProductsByWarehouse = (pool, warehouseId) => {
  return new Promise(async (resolve, reject) => {
    try {
      let listProductResult = await pool.request()
        .input('warehouseId', sql.Int, warehouseId)
        .query(`
          SELECT
            V.Id,
            V.Ma,
            V.Ten,
            V.DonGia,
            V.DonGiaNhap,
            V.IdNhomVatTu,
            N.Ten AS TenNhomVatTu,
            V.IdNhaCungCap,
            C.Ten AS TenNhaCungCap,
            C.DiaChi,
            C.SDT,
            IIF(T.SoLuong IS NULL, 0, T.SoLuong) AS SoLuong
          FROM dbo.VatTu V
          LEFT JOIN dbo.NhomVatTu N ON N.Id = V.IdNhomVatTu
          LEFT JOIN dbo.NhaCungCap C ON C.Id = V.IdNhaCungCap
          LEFT JOIN (
            SELECT CT.IdVatTu, CT.IdKho, SUM(CT.SoLuong) AS SoLuong
            FROM ChiTietKho CT
            GROUP BY ALL CT.IdVatTu, CT.IdKho
          ) AS T ON T.IdVatTu = V.Id
          WHERE V.IsActive = 1 AND T.IdKho = @warehouseId
        `)

      return resolve(listProductResult.recordset)
    } catch (error) {
      return reject(error)
    }
  })
}

module.exports = {
  getAllWarehouse,
  addNewWarehouse,
  updateWarehouse,
  removeWarehouse,
  getListProductsByWarehouse
}
