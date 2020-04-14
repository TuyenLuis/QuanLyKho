import express from 'express'

import exchangeGoodController from './../controllers/exchangeGoodController'
import { isLoggedIn, isAuth } from './../middlewares/authMiddleware'
import { isEmployee, isAdmin } from './../middlewares/checkRoleMiddleware'
import { checkConnectDB } from './../middlewares/connectDbMiddleware'

const exchangeRouter = express.Router()

exchangeRouter.get('/get-all', checkConnectDB, isAuth, exchangeGoodController.getAllExchangeReceipt)

exchangeRouter.get('/get-detail/:receiptId', checkConnectDB, isAuth, exchangeGoodController.getExchangeReceiptDetailById)

exchangeRouter.post('/add-new-receipt', checkConnectDB, isAuth, exchangeGoodController.addNewExchangeGoodReceipt)

exchangeRouter.put('/update-receipt', checkConnectDB, isAuth, exchangeGoodController.updateExchangeGoodReceipt)

module.exports = exchangeRouter
