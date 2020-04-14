import express from 'express'

import exportGoodController from './../controllers/exportGoodController'
import { isLoggedIn, isAuth } from './../middlewares/authMiddleware'
import { isEmployee, isAdmin } from './../middlewares/checkRoleMiddleware'
import { checkConnectDB } from './../middlewares/connectDbMiddleware'

const exportRouter = express.Router()

exportRouter.get('/get-all', checkConnectDB, isAuth, exportGoodController.getAllExportReceipt)

exportRouter.get('/get-detail/:receiptId', checkConnectDB, isAuth, exportGoodController.getExportReceiptDetailById)

exportRouter.post('/add-new-receipt', checkConnectDB, isAuth, exportGoodController.addNewExportGoodReceipt)

exportRouter.put('/update-receipt', checkConnectDB, isAuth, exportGoodController.updateExportGoodReceipt)

module.exports = exportRouter
