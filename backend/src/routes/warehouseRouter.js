import express from 'express'

import warehouseController from './../controllers/warehouseController'
import { isAuth } from './../middlewares/authMiddleware'
import { checkConnectDB } from './../middlewares/connectDbMiddleware'
import { isAdmin } from './../middlewares/checkRoleMiddleware'

const warehouseRouter = express.Router()

warehouseRouter.get('/list-all-warehouse', checkConnectDB, isAuth, isAdmin, warehouseController.getAllWarehouse)

warehouseRouter.get('/list-product/:warehouseId', checkConnectDB, isAuth, isAdmin, warehouseController.getListProductsByWarehouse)

warehouseRouter.post('/add-new-warehouse', checkConnectDB, isAuth, isAdmin, warehouseController.addNewWarehouse)

warehouseRouter.put('/update-warehouse', checkConnectDB, isAuth, isAdmin, warehouseController.updateWarehouse)

warehouseRouter.delete('/delete-warehouse', checkConnectDB, isAuth, isAdmin, warehouseController.removeWarehouse)

module.exports = warehouseRouter
