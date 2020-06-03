import express from 'express'

import userController from './../controllers/userController'
import { isAuth } from './../middlewares/authMiddleware'
import { checkConnectDB } from './../middlewares/connectDbMiddleware'

const userRouter = express.Router()

userRouter.get('/list-all-user', checkConnectDB, isAuth, userController.getAllUser)

module.exports = userRouter
