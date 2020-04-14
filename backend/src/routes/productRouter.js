import express from 'express'

import productController from './../controllers/productController'
import { isLoggedIn, isAuth } from './../middlewares/authMiddleware'
import { isCustomer, isAdmin } from './../middlewares/checkRoleMiddleware'
import { checkConnectDB } from './../middlewares/connectDbMiddleware'

const productRouter = express.Router()


productRouter.get('/list-all-product', checkConnectDB, isAuth, productController.getAllProduct)

productRouter.get('/list-product', checkConnectDB, isAuth, productController.getListProduct)

productRouter.post('/add-new-product', checkConnectDB, isAuth, productController.addNewProduct)

productRouter.put('/update-product', checkConnectDB, isAuth, productController.updateProduct)

productRouter.delete('/delete-product', checkConnectDB, isAuth, productController.removeProduct)

module.exports = productRouter
