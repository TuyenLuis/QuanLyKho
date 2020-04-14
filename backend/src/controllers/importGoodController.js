import importGoodService from './../services/importGoodService'
import { transSuccess, transError } from './../constants/languageEn'

const getAllImportReceipt = async (req, res) => {
  try {
    let listImportReceipt = await importGoodService.getAllImportReceipt(req.pool)
    return res.status(200).send({
      data: listImportReceipt
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const getImportReceiptDetailById = async (req, res) => {
  try {
    let receiptId = req.params.receiptId
    if (!receiptId) {
      return res.status(500).send({ err: transError.import_receipt_id_empty })
    }

    let listProduct = await importGoodService.getImportReceiptDetailById(req.pool, receiptId)
    if (!listProduct || !listProduct.length) {
      return res.status(200).send({
        message: transError.import_receipt_id_not_existed.replace('#receiptId', receiptId),
        data: []
      })
    }

    return res.status(200).send({
      message: 'success',
      data: listProduct
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const addNewImportGoodReceipt = async (req, res) => {
  try {
    let importReceipt = {
      Ma: req.body.Ma || null,
      NgayNhap: req.body.NgayNhap || null,
      IdNhaCungCap: req.body.IdNhaCungCap || null,
      IdNhanVien: req.body.IdNhanVien || null,
      IdKho: req.body.IdKho || null,
      GhiChu: req.body.GhiChu || null
    }
    let listProduct = req.body.listProduct || null
    if (!listProduct || !listProduct.length) {
      return res.status(500).send({
        message: transError.list_product_empty,
        data: []
      })
    }
    let receiptId = await importGoodService.addNewImportReceiptInfo(req.pool, importReceipt)
    let total = await Promise.all(listProduct.map(async product => {
      let price = await importGoodService.addOrUpdateImportReceiptDetail(req.pool, receiptId, product)
      return price
    }))

    return res.status(200).send({
      message: transSuccess.add_import_good_receipt,
      data: { totalPrice: total[total.length - 1] }
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const updateImportGoodReceipt = async (req, res) => {
  try {
    let importReceipt = {
      Ma: req.body.Ma || null,
      NgayNhap: req.body.NgayNhap || null,
      IdNhaCungCap: req.body.IdNhaCungCap || null,
      IdNhanVien: req.body.IdNhanVien || null,
      GhiChu: req.body.GhiChu || null,
      Id: req.body.Id || null
    }
    let listProduct = req.body.listProduct || null
    if (!listProduct || !listProduct.length) {
      return res.status(500).send({
        message: transError.list_product_empty,
        data: []
      })
    }

    await importGoodService.updateImportReceiptInfo(req.pool, importReceipt)
    let total = await Promise.all(listProduct.map(async product => {
      let price = await importGoodService.addOrUpdateImportReceiptDetail(req.pool, importReceipt.Id, product)
      return price
    }))

    return res.status(200).send({
      message: transSuccess.update_import_good_receipt,
      data: { totalPrice: total[total.length - 1] }
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}


module.exports = {
  getAllImportReceipt,
  getImportReceiptDetailById,
  addNewImportGoodReceipt,
  updateImportGoodReceipt
}
