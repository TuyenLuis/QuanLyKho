/**
 * Import build-in modules
 */
import express from 'express'
import expressEjsExtend from 'express-ejs-extend'
import dotenv from 'dotenv'
import passport from 'passport'
import bodyParser from 'body-parser'
import cookieParser from 'cookie-parser'
import connectFlash from 'connect-flash'
import cors from 'cors'
import http from 'http'

/**
 * Import defined modules
 */
import sessionConfig from './configs/session'
import apiRouter from './routes/apiRouter'
import { request } from 'http'

dotenv.config({ path: process.cwd() + '/sh/.env' })

const PORT = process.env.PORT || process.env.APP_PORT
const app = express()
// Config session
sessionConfig.config(app)

// Use Cors
app.use(cors({
  credentials: true,
  origin: true
}))

// Public image to display
app.use(express.static('./src/public'))

// Enable post data for request
app.use(bodyParser.urlencoded({ extended: true }))
app.use(bodyParser.json())

// Use Cookie Parser
app.use(cookieParser())

// Enable flash message
app.use(connectFlash())

// Config passport
// app.use(passport.initialize())
// app.use(passport.session())

app.engine('ejs', expressEjsExtend)
app.set('view engine', 'ejs')
app.set('views', './src/views')

// Init all routes
app.get('/', (req, res) => {
  return res.render("index")
})
app.use("/api", apiRouter)

app.listen(PORT, () => {
  console.log('Server is running at port ' + PORT)
  console.log(process.env.DB_USERNAME, process.env.DB_PASSWORD, process.env.DB_HOST, process.env.DB_NAME)
  console.log('Server is running')
})

setInterval(() => {
  http.get('http://quanlykho-cs.herokuapp.com')
}, 1740000)
