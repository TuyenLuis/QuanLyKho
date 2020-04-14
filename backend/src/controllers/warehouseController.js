import _ from 'lodash'

import warehouseService from './../services/warehouseService'
import { transError, transSuccess } from '../constants/languageEn'
import config from '../constants/config'

const getAllWarehouse = async (req, res) => {
  try {
    let listWarehouse = await warehouseService.getAllWarehouse(req.pool)
    return res.status(200).send({
      data: listWarehouse
    })
  } catch (err) {
    return res.status(500).send({ err })
  }
}

const getListProductsByWarehouse = async (req, res) => {
  try {
    let warehouseId = req.params.warehouseId
    if (!warehouseId) {
      return res.status(500).send({ err: transError.warehouse_id_empty })
    }

    let listProduct = await warehouseService.getListProductsByWarehouse(req.pool, warehouseId)
    if (!listProduct || !listProduct.length) {
      return res.status(200).send({
        message: transError.warehouse_id_not_existed.replace('#warehouseId', warehouseId),
        data: []
      })
    }

    return res.status(200).send({
      message: 'success',
      data: listProduct
    })
  } catch (err) {
    return res.status(500).send({ err })
  }
}

const addNewWarehouse = async (req, res) => {
  try {
    let warehouse = {
      Ma: req.body.ma || null,
      Ten: req.body.ten || null,
      DiaChi: req.body.diaChi || null,
      SDT: req.body.sdt || null,
      GhiChu: req.body.ghiChu || null,
      IdQuanLy: req.body.idQuanLy || null
    }

    let warehouseId = await warehouseService.addNewWarehouse(req.pool, warehouse)
    return res.status(200).send({
      message: transSuccess.add_warehouse,
      data: { warehouseId }
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const updateWarehouse = async (req, res) => {
  try {
    let warehouse = {
      Ma: req.body.ma || null,
      Ten: req.body.ten || null,
      DiaChi: req.body.diaChi || null,
      SDT: req.body.sdt || null,
      GhiChu: req.body.ghiChu || null,
      IdQuanLy: req.body.idQuanLy || null,
      Id: req.body.warehouseId || null
    }

    await warehouseService.updateWarehouse(req.pool, warehouse)
    return res.status(200).send({
      message: transSuccess.update_warehouse
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const removeWarehouse = async (req, res) => {
  try {
    await warehouseService.removeWarehouse(req.pool, req.body.warehouseId)
    return res.status(200).send({
      message: transSuccess.remove_warehouse
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}


module.exports = {
  getAllWarehouse,
  getListProductsByWarehouse,
  addNewWarehouse,
  updateWarehouse,
  removeWarehouse
}
