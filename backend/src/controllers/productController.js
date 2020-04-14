import productService from './../services/productService'
import { transSuccess } from './../constants/languageEn'

const NUMBER_PRODUCT_PER_PAGE = 20

const getAllProduct = async (req, res) => {
  try {
    let listProduct = await productService.getAllProduct(req.pool)
    return res.status(200).send({
      data: listProduct
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const getListProduct = async (req, res) => {
  try {
    let pageNumber = req.query.page || 1
    let { listProduct, pageAmount } = await productService.getListProduct(req.pool, NUMBER_PRODUCT_PER_PAGE, pageNumber)
    return res.status(200).send({
      data: {
        currentPage: +pageNumber,
        pageAmount,
        listProduct
      }
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const addNewProduct = async (req, res) => {
  try {
    let product = {
      Ma: req.body.ma || null,
      Ten: req.body.ten || null,
      DonGia: req.body.donGia || null,
      DonGiaNhap: req.body.donGiaNhap || null,
      DonViTinh: req.body.donViTinh || null,
      IdNhomVatTu: req.body.idNhomVatTu || null,
      IdNhaCungCap: req.body.idNhaCungCap || null
    }

    let productId = await productService.addNewProduct(req.pool, product)
    return res.status(200).send({
      message: transSuccess.add_product,
      data: { productId }
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const updateProduct = async (req, res) => {
  try {
    let product = {
      Ma: req.body.ma || null,
      Ten: req.body.ten || null,
      DonGia: req.body.donGia || null,
      DonGiaNhap: req.body.donGiaNhap || null,
      DonViTinh: req.body.donViTinh || null,
      IdNhomVatTu: req.body.idNhomVatTu || null,
      IdNhaCungCap: req.body.idNhaCungCap || null,
      Id: req.body.productId || null
    }

    await productService.updateProduct(req.pool, product)
    return res.status(200).send({
      message: transSuccess.update_product
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const removeProduct = async (req, res) => {
  try {
    await productService.removeProduct(req.pool, req.body.productId)
    return res.status(200).send({
      message: transSuccess.remove_product
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}


module.exports = {
  getAllProduct,
  getListProduct,
  addNewProduct,
  updateProduct,
  removeProduct
}
