import exchangeGoodService from './../services/exchangeGoodService'
import { transSuccess, transError } from './../constants/languageEn'

const getAllExchangeReceipt = async (req, res) => {
  try {
    let listImportReceipt = await exchangeGoodService.getAllExchangeReceipt(req.pool)
    return res.status(200).send({
      data: listImportReceipt
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const getExchangeReceiptDetailById = async (req, res) => {
  try {
    let receiptId = req.params.receiptId
    if (!receiptId) {
      return res.status(500).send({ err: transError.exchange_receipt_id_empty })
    }

    let listProduct = await exchangeGoodService.getExchangeReceiptDetailById(req.pool, receiptId)
    if (!listProduct || !listProduct.length) {
      return res.status(200).send({
        message: transError.exchange_receipt_id_not_existed.replace('#receiptId', receiptId),
        data: []
      })
    }

    let dataResponse = {
      Id: listProduct[0].Id,
      Ma: listProduct[0].Ma,
      NgayChuyen: listProduct[0].NgayChuyen,
      TongTien: listProduct[0].TongTien,
      GhiChu: listProduct[0].GhiChuPhieu,
      IdNhanVien: listProduct[0].IdNhanVien,
      TenNhanVien: listProduct[0].TenNhanVien,
      IdKhoCu: listProduct[0].IdKhoCu,
      TenKhoCu: listProduct[0].TenKhoCu,
      IdKhoMoi: listProduct[0].IdKhoMoi,
      TenKhoMoi: listProduct[0].TenKhoMoi,
      DanhSachVatTu: []
    }

    dataResponse.DanhSachVatTu = listProduct.map(product => ({
      IdVatTu: product.IdVatTu,
      TenVatTu: product.TenVatTu,
      DonGia: product.DonGia,
      SoLuong: product.SoLuong,
      ThanhTien: product.ThanhTien,
      GhiChu: product.GhiChu
    }))

    return res.status(200).send({
      message: 'success',
      data: dataResponse
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const addNewExchangeGoodReceipt = async (req, res) => {
  try {
    let exchangeReceipt = {
      Ma: req.body.Ma || null,
      NgayChuyen: req.body.NgayChuyen || null,
      IdNhanVien: req.body.IdNhanVien || null,
      IdKhoCu: req.body.IdKhoCu || null,
      IdKhoMoi: req.body.IdKhoMoi || null,
      GhiChu: req.body.GhiChu || null
    }
    let listProduct = req.body.listProduct || null
    if (!listProduct || !listProduct.length) {
      return res.status(500).send({
        message: transError.list_product_empty,
        data: []
      })
    }
    let receiptId = await exchangeGoodService.addNewExchangeReceiptInfo(req.pool, exchangeReceipt)
    let total = await Promise.all(listProduct.map(async product => {
      let price = await exchangeGoodService.addOrUpdateExchangeReceiptDetail(req.pool, receiptId, product)
      return price
    }))

    return res.status(200).send({
      message: transSuccess.add_exchange_good_receipt,
      data: {
        totalPrice: total[total.length - 1],
        receiptId
      }
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const updateExchangeGoodReceipt = async (req, res) => {
  try {
    let exchangeReceipt = {
      Ma: req.body.Ma || null,
      NgayChuyen: req.body.NgayChuyen || null,
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

    await exchangeGoodService.updateExchangeReceiptInfo(req.pool, exchangeReceipt)
    let total = await Promise.all(listProduct.forEach(async product => {
      let price = await exchangeGoodService.addOrUpdateExchangeReceiptDetail(req.pool, exchangeReceipt.Id, product)
      return price
    }))

    return res.status(200).send({
      message: transSuccess.update_exchange_good_receipt,
      data: { totalPrice: total[total.length - 1] }
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}


module.exports = {
  getAllExchangeReceipt,
  getExchangeReceiptDetailById,
  addNewExchangeGoodReceipt,
  updateExchangeGoodReceipt
}
