import express from 'express'

import employeeController from './../controllers/employeeController'
import { isLoggedIn, isAuth } from './../middlewares/authMiddleware'
import { isEmployee, isAdmin } from './../middlewares/checkRoleMiddleware'
import { checkConnectDB } from './../middlewares/connectDbMiddleware'

const employeeRouter = express.Router()


employeeRouter.get('/list-all-employee', checkConnectDB, isAuth, isAdmin, employeeController.getAllEmployee)

employeeRouter.get('/list-employee', checkConnectDB, isAuth, isAdmin, employeeController.getListEmployee)

employeeRouter.post('/add-new-employee', checkConnectDB, isAuth, isAdmin, employeeController.addNewEmployee)

employeeRouter.put('/update-employee', checkConnectDB, isAuth, isAdmin, employeeController.updateEmployee)

employeeRouter.delete('/delete-employee', checkConnectDB, isAuth, isAdmin, employeeController.removeEmployee)

module.exports = employeeRouter
