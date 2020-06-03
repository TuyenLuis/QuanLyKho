import sql from 'mssql'

import { transError } from './../constants/languageEn'

const getAllCategory = pool => {
  return new Promise(async (resolve, reject) => {
    try {
      let listCategoryResult = await pool.request()
        .query(`
          SELECT
            Id,
            Ma,
            Ten
          FROM NhomVatTu
          WHERE IsActive = 1
        `)
      resolve(listCategoryResult.recordset)
    } catch (error) {
      return reject(error)
    }
  })
}

const addNewCategory = (pool, category) => {
  return new Promise(async (resolve, reject) => {
    try {
      let categoryResult = await pool.request()
        .input('Ma', sql.NVarChar(50), category.Ma)
        .input('Ten', sql.NVarChar(50), category.Ten)
        .output('Id', sql.Int)
        .execute('dbo.Usp_AddNewCategory')

      if (categoryResult.output.Id) {
        return resolve(categoryResult.output.Id)
      } else {
        return reject(transError.add_category)
      }
    } catch (error) {
      return reject(error)
    }
  })
}

const updateCategory = (pool, category) => {
  return new Promise(async (resolve, reject) => {
    try {
      let categoryResult = await pool.request()
        .input('Ma', sql.NVarChar(50), category.Ma)
        .input('Ten', sql.NVarChar(50), category.Ten)
        .input('Id', sql.Int, category.Id)
        .query(`
          UPDATE NhomVatTu
          SET Ma = @Ma,
              Ten = @Ten,
              UpdatedAt = GETDATE()
          WHERE Id = @Id
        `)

      return resolve(categoryResult)
    } catch (error) {
      return reject(error)
    }
  })
}

const removeCategory = (pool, categoryId) => {
  return new Promise(async (resolve, reject) => {
    try {
      let categoryResult = await pool.request()
        .input('categoryId', sql.Int, categoryId)
        .query('UPDATE NhomVatTu SET IsActive = 0 WHERE Id = @categoryId')

      return resolve(categoryResult)
    } catch (error) {
      return reject(error)
    }
  })
}

const getListProductsByCategory = (pool, categoryId) => {
  return new Promise(async (resolve, reject) => {
    try {
      let listProductResult = await pool.request()
        .input('categoryId', sql.Int, categoryId)
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
          WHERE V.IsActive = 1 AND V.IdNhomVatTu = @categoryId
        `)

      return resolve(listProductResult.recordset)
    } catch (error) {
      return reject(error)
    }
  })
}

module.exports = {
  getAllCategory,
  addNewCategory,
  updateCategory,
  removeCategory,
  getListProductsByCategory
}
