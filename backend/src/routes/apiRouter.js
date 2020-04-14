import express from 'express'
import authRouter from './authRouter'
import productRouter from './productRouter'
import providerRouter from './providerRouter'
import categoryRouter from './categoryRouter'
import employeeRouter from './employeeRouter'
import warehouseRouter from './warehouseRouter'
import importRouter from './importGoodRouter'
import exportRouter from './exportGoodRouter'
import exchangeRouter from './exchangeGoodRouter'

const apiRouter = express.Router()

apiRouter.use('/auth', authRouter)
apiRouter.use('/product', productRouter)
apiRouter.use('/provider', providerRouter)
apiRouter.use('/category', categoryRouter)
apiRouter.use('/employee', employeeRouter)
apiRouter.use('/warehouse', warehouseRouter)
apiRouter.use('/import', importRouter)
apiRouter.use('/export', exportRouter)
apiRouter.use('/exchange', exchangeRouter)

module.exports = apiRouter
