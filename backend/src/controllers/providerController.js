import _ from 'lodash'

import providerService from './../services/providerService'
import { transError, transSuccess } from '../constants/languageEn'
import config from '../constants/config'

const getAllProvider = async (req, res) => {
  try {
    let listProvider = await providerService.getAllProvider(req.pool)
    return res.status(200).send({
      data: listProvider
    })
  } catch (err) {
    return res.status(500).send({ err })
  }
}

const getListProductsByProvider = async (req, res) => {
  try {
    let providerId = req.params.providerId
    if (!providerId) {
      return res.status(500).send({ err: transError.provider_id_empty })
    }

    let listProduct = await providerService.getListProductsByProvider(req.pool, providerId)
    if (!listProduct || !listProduct.length) {
      return res.status(200).send({
        message: transError.provider_id_not_existed.replace('#providerId', providerId),
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

const addNewProvider = async (req, res) => {
  try {
    let provider = {
      Ma: req.body.ma || null,
      Ten: req.body.ten || null,
      DiaChi: req.body.diaChi || null,
      SDT: req.body.sdt || null,
      Email: req.body.email || null,
      NguoiDaiDien: req.body.nguoiDaiDien || null
    }

    let providerId = await providerService.addNewProvider(req.pool, provider)
    return res.status(200).send({
      message: transSuccess.add_provider,
      data: { providerId }
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const updateProvider = async (req, res) => {
  try {
    let provider = {
      Ma: req.body.ma || null,
      Ten: req.body.ten || null,
      DiaChi: req.body.diaChi || null,
      SDT: req.body.sdt || null,
      Email: req.body.email || null,
      NguoiDaiDien: req.body.nguoiDaiDien || null,
      Id: req.body.providerId || null
    }

    await providerService.updateProvider(req.pool, provider)
    return res.status(200).send({
      message: transSuccess.update_provider
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const removeProvider = async (req, res) => {
  try {
    await providerService.removeProvider(req.pool, req.body.providerId)
    return res.status(200).send({
      message: transSuccess.remove_provider
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}


module.exports = {
  getAllProvider,
  getListProductsByProvider,
  addNewProvider,
  updateProvider,
  removeProvider
}
