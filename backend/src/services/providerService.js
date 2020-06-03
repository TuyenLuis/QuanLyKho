import sql from 'mssql'

import { transError } from './../constants/languageEn'

const getAllProvider = pool => {
  return new Promise(async (resolve, reject) => {
    try {
      let listProviderResult = await pool.request()
        .query(`
          SELECT
            Id,
            Ma,
            Ten,
            DiaChi,
            SDT,
            Email,
            NguoiDaiDien
          FROM NhaCungCap
          WHERE IsActive = 1
        `)
      resolve(listProviderResult.recordset)
    } catch (error) {
      return reject(error)
    }
  })
}

const addNewProvider = (pool, provider) => {
  return new Promise(async (resolve, reject) => {
    try {
      let providerResult = await pool.request()
        .input('Ma', sql.NVarChar(50), provider.Ma)
        .input('Ten', sql.NVarChar(50), provider.Ten)
        .input('DiaChi', sql.NVarChar(250), provider.DiaChi)
        .input('SDT', sql.NVarChar(50), provider.SDT)
        .input('Email', sql.NVarChar(50), provider.Email)
        .input('NguoiDaiDien', sql.NVarChar(50), provider.NguoiDaiDien)
        .output('Id', sql.Int)
        .execute('dbo.Usp_AddNewProvider')

      if (providerResult.output.Id) {
        return resolve(providerResult.output.Id)
      } else {
        return reject(transError.add_provider)
      }
    } catch (error) {
      return reject(error)
    }
  })
}

const updateProvider = (pool, provider) => {
  return new Promise(async (resolve, reject) => {
    try {
      let providerResult = await pool.request()
        .input('Ma', sql.NVarChar(50), provider.Ma)
        .input('Ten', sql.NVarChar(50), provider.Ten)
        .input('DiaChi', sql.NVarChar(250), provider.DiaChi)
        .input('SDT', sql.NVarChar(50), provider.SDT)
        .input('Email', sql.NVarChar(50), provider.Email)
        .input('NguoiDaiDien', sql.NVarChar(50), provider.NguoiDaiDien)
        .input('Id', sql.Int, provider.Id)
        .query(`
          UPDATE NhaCungCap
          SET Ma = @Ma,
              Ten = @Ten,
              DiaChi = @DiaChi,
              SDT = @SDT,
              Email = @Email,
              NguoiDaiDien = @NguoiDaiDien,
              UpdatedAt = GETDATE()
          WHERE Id = @Id
        `)

      return resolve(providerResult)
    } catch (error) {
      return reject(error)
    }
  })
}

const removeProvider = (pool, providerId) => {
  return new Promise(async (resolve, reject) => {
    try {
      let providerResult = await pool.request()
        .input('providerId', sql.Int, providerId)
        .query('UPDATE NhaCungCap SET IsActive = 0 WHERE Id = @providerId')

      return resolve(providerResult)
    } catch (error) {
      return reject(error)
    }
  })
}

const getListProductsByProvider = (pool, providerId) => {
  return new Promise(async (resolve, reject) => {
    try {
      let listProductResult = await pool.request()
        .input('providerId', sql.Int, providerId)
        .query(`
          SELECT
            V.Id,
            V.Ma,
            V.Ten,
            V.DonGia,
            V.DonGiaNhap,
            V.DonViTinh,
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
            SELECT CT.IdVatTu, SUM(CT.SoLuong) AS SoLuong
            FROM ChiTietKho CT
            GROUP BY ALL CT.IdVatTu
          ) AS T ON T.IdVatTu = V.Id
          WHERE V.IsActive = 1 AND V.IdNhaCungCap = @providerId
        `)

      return resolve(listProductResult.recordset)
    } catch (error) {
      return reject(error)
    }
  })
}

module.exports = {
  getAllProvider,
  addNewProvider,
  updateProvider,
  removeProvider,
  getListProductsByProvider
}
