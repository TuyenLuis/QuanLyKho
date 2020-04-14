import express from 'express'

import providerController from './../controllers/providerController'
import { isAuth } from './../middlewares/authMiddleware'
import { checkConnectDB } from './../middlewares/connectDbMiddleware'

const providerRouter = express.Router()


providerRouter.get('/list-all-provider', checkConnectDB, isAuth, providerController.getAllProvider)

providerRouter.get('/list-product/:providerId', checkConnectDB, isAuth, providerController.getListProductsByProvider)

providerRouter.post('/add-new-provider', checkConnectDB, isAuth, providerController.addNewProvider)

providerRouter.put('/update-provider', checkConnectDB, isAuth, providerController.updateProvider)

providerRouter.delete('/delete-provider', checkConnectDB, isAuth, providerController.removeProvider)

module.exports = providerRouter
