import express from 'express'

import importGoodController from './../controllers/importGoodController'
import { isLoggedIn, isAuth } from './../middlewares/authMiddleware'
import { isEmployee, isAdmin } from './../middlewares/checkRoleMiddleware'
import { checkConnectDB } from './../middlewares/connectDbMiddleware'

const importRouter = express.Router()

importRouter.get('/get-all', checkConnectDB, isAuth, importGoodController.getAllImportReceipt)

importRouter.get('/get-detail/:receiptId', checkConnectDB, isAuth, importGoodController.getImportReceiptDetailById)

importRouter.post('/add-new-receipt', checkConnectDB, isAuth, importGoodController.addNewImportGoodReceipt)

importRouter.put('/update-receipt', checkConnectDB, isAuth, importGoodController.updateImportGoodReceipt)

module.exports = importRouter
