import exportGoodService from './../services/exportGoodService'
import { transSuccess, transError } from './../constants/languageEn'

const getAllExportReceipt = async (req, res) => {
  try {
    let listExportReceipt = await exportGoodService.getAllExportReceipt(req.pool)
    return res.status(200).send({
      data: listExportReceipt
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const getExportReceiptDetailById = async (req, res) => {
  try {
    let receiptId = req.params.receiptId
    if (!receiptId) {
      return res.status(500).send({ err: transError.export_receipt_id_empty })
    }

    let listProduct = await exportGoodService.getExportReceiptDetailById(req.pool, receiptId)
    if (!listProduct || !listProduct.length) {
      return res.status(200).send({
        message: transError.export_receipt_id_not_existed.replace('#receiptId', receiptId),
        data: []
      })
    }

    let dataResponse = {
      Id: listProduct[0].Id,
      Ma: listProduct[0].Ma,
      NgayXuat: listProduct[0].NgayXuat,
      TongTien: listProduct[0].TongTien,
      DiaChi: listProduct[0].DiaChi,
      GhiChu: listProduct[0].GhiChuPhieu,
      IdNhanVien: listProduct[0].IdNhanVien,
      TenNhanVien: listProduct[0].TenNhanVien,
      IdKho: listProduct[0].IdKho,
      TenKho: listProduct[0].TenKho,
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

const addNewExportGoodReceipt = async (req, res) => {
  try {
    let exportReceipt = {
      Ma: req.body.Ma || null,
      NgayXuat: req.body.NgayXuat || null,
      DiaChi: req.body.DiaChi || null,
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
    let receiptId = await exportGoodService.addNewExportReceiptInfo(req.pool, exportReceipt)
    let total = await Promise.all(listProduct.map(async product => {
      let price = await exportGoodService.addOrUpdateExportReceiptDetail(req.pool, receiptId, product)
      return price
    }))

    return res.status(200).send({
      message: transSuccess.add_export_good_receipt,
      data: {
        totalPrice: total[total.length - 1],
        receiptId
      }
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const updateExportGoodReceipt = async (req, res) => {
  try {
    let exportReceipt = {
      Ma: req.body.Ma || null,
      NgayXuat: req.body.NgayXuat || null,
      DiaChi: req.body.DiaChi || null,
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

    await exportGoodService.updateExportReceiptInfo(req.pool, exportReceipt)
    let total = await Promise.all(listProduct.map(async product => {
      let price = await exportGoodService.addOrUpdateExportReceiptDetail(req.pool, exportReceipt.Id, product)
      return price
    }))

    return res.status(200).send({
      message: transSuccess.update_export_good_receipt,
      data: { totalPrice: total[total.length - 1] }
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}


module.exports = {
  getAllExportReceipt,
  getExportReceiptDetailById,
  addNewExportGoodReceipt,
  updateExportGoodReceipt
}
