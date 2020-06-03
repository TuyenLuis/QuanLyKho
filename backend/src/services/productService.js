import sql from 'mssql'

import { transError } from './../constants/languageEn'

const getAllProduct = pool => {
  return new Promise(async (resolve, reject) => {
    try {
      let listProductResult = await pool.request()
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
          WHERE V.IsActive = 1
        `)
      resolve(listProductResult.recordset)
    } catch (error) {
      return reject(error)
    }
  })
}

const getListProduct = (pool, pageSize, pageNumber = 1) => {
  return new Promise(async (resolve, reject) => {
    try {
      let productResult = await pool.request()
        .input('pageSize', sql.Int, pageSize)
        .input('pageNumber', sql.Int, pageNumber)
        .output('pageAmount', sql.Int)
        .execute('dbo.Usp_GetListProductPaging')

      return resolve({
        listProduct: productResult.recordset,
        pageAmount: productResult.output.pageAmount
      })
    } catch (error) {
      return reject(error)
    }
  })
}

const addNewProduct = (pool, product) => {
  return new Promise(async (resolve, reject) => {
    try {
      let productResult = await pool.request()
        .input('Ma', sql.NVarChar(50), product.Ma)
        .input('Ten', sql.NVarChar(50), product.Ten)
        .input('DonGia', sql.Decimal(18, 0), product.DonGia)
        .input('DonGiaNhap', sql.Decimal(18, 0), product.DonGiaNhap)
        .input('DonViTinh', sql.NVarChar(50), product.DonViTinh)
        .input('IdNhomVatTu', sql.Int, product.IdNhomVatTu)
        .input('IdNhaCungCap', sql.Int, product.IdNhaCungCap)
        .output('Id', sql.Int)
        .execute('dbo.Usp_AddNewProduct')

      if (productResult.output.Id) {
        return resolve(productResult.output.Id)
      } else {
        return reject(transError.add_product)
      }
    } catch (error) {
      return reject(error)
    }
  })
}

const updateProduct = (pool, product) => {
  return new Promise(async (resolve, reject) => {
    try {
      let productResult = await pool.request()
        .input('Ma', sql.NVarChar(50), product.Ma)
        .input('Ten', sql.NVarChar(50), product.Ten)
        .input('DonGia', sql.Decimal(18, 0), product.DonGia)
        .input('DonGiaNhap', sql.Decimal(18, 0), product.DonGiaNhap)
        .input('DonViTinh', sql.NVarChar(50), product.DonViTinh)
        .input('IdNhomVatTu', sql.Int, product.IdNhomVatTu)
        .input('IdNhaCungCap', sql.Int, product.IdNhaCungCap)
        .input('Id', sql.Int, product.Id)
        .query(`
          UPDATE VatTu
          SET Ma = @Ma,
              Ten = @Ten,
              DonGia = @DonGia,
              DonGiaNhap = @DonGiaNhap,
              DonViTinh = @DonViTinh,
              IdNhomVatTu = @IdNhomVatTu,
              IdNhaCungCap = @IdNhaCungCap,
              UpdatedAt = GETDATE()
          WHERE Id = @Id
        `)

      return resolve(productResult)
    } catch (error) {
      return reject(error)
    }
  })
}

const removeProduct = (pool, productId) => {
  return new Promise(async (resolve, reject) => {
    try {
      let productResult = await pool.request()
        .input('productId', sql.Int, productId)
        .query('UPDATE VatTu SET IsActive = 0 WHERE Id = @productId')

      return resolve(productResult)
    } catch (error) {
      return reject(error)
    }
  })
}

module.exports = {
  getAllProduct,
  getListProduct,
  addNewProduct,
  updateProduct,
  removeProduct
}
