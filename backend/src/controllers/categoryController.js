import _ from 'lodash'

import categoryService from './../services/categoryService'
import { transError, transSuccess } from '../constants/languageEn'
import config from '../constants/config'

const getAllCategory = async (req, res) => {
  try {
    let listCategory = await categoryService.getAllCategory(req.pool)
    return res.status(200).send({
      data: listCategory
    })
  } catch (err) {
    return res.status(500).send({ err })
  }
}

const getListProductsByCategory = async (req, res) => {
  try {
    let categoryId = req.params.categoryId
    if (!categoryId) {
      return res.status(500).send({ err: transError.catalog_id_empty })
    }

    let listProduct = await categoryService.getListProductsByCategory(req.pool, categoryId)
    if (!listProduct || !listProduct.length) {
      return res.status(200).send({
        message: transError.catalog_id_not_existed.replace('#categoryId', categoryId),
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

const addNewCategory = async (req, res) => {
  try {
    let category = {
      Ma: req.body.ma || null,
      Ten: req.body.ten || null
    }

    let categoryId = await categoryService.addNewCategory(req.pool, category)
    return res.status(200).send({
      message: transSuccess.add_category,
      data: { categoryId }
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const updateCategory = async (req, res) => {
  try {
    let category = {
      Ma: req.body.ma || null,
      Ten: req.body.ten || null,
      Id: req.body.categoryId || null
    }

    await categoryService.updateCategory(req.pool, category)
    return res.status(200).send({
      message: transSuccess.update_category
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const removeCategory = async (req, res) => {
  try {
    await categoryService.removeCategory(req.pool, req.body.categoryId)
    return res.status(200).send({
      message: transSuccess.remove_category
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}


module.exports = {
  getAllCategory,
  getListProductsByCategory,
  addNewCategory,
  updateCategory,
  removeCategory
}
