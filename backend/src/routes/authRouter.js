import express from 'express'

import authController from '../controllers/authController'
import authValidation from '../validation/authValidation'
import { isAuth, isLoggedOut } from './../middlewares/authMiddleware'
import { checkConnectDB } from './../middlewares/connectDbMiddleware'
import { isAdmin } from './../middlewares/checkRoleMiddleware'

const authRouter = express.Router()

authRouter.post('/login', checkConnectDB, authController.login)

authRouter.post('/refresh-token', checkConnectDB, authController.refreshToken)

authRouter.post('/register', checkConnectDB, isAuth, isAdmin, authValidation.register, authController.register)

authRouter.put('/change-password', checkConnectDB, isAuth, authController.changePassword)

module.exports = authRouter
