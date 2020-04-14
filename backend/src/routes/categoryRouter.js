import express from 'express'

import categoryController from './../controllers/categoryController'
import { isAuth } from './../middlewares/authMiddleware'
import { checkConnectDB } from './../middlewares/connectDbMiddleware'

const categoryRouter = express.Router()


categoryRouter.get('/list-all-category', checkConnectDB, isAuth, categoryController.getAllCategory)

categoryRouter.get('/list-product/:categoryId', checkConnectDB, isAuth, categoryController.getListProductsByCategory)

categoryRouter.post('/add-new-category', checkConnectDB, isAuth, categoryController.addNewCategory)

categoryRouter.put('/update-category', checkConnectDB, isAuth, categoryController.updateCategory)

categoryRouter.delete('/delete-category', checkConnectDB, isAuth, categoryController.removeCategory)

module.exports = categoryRouter
