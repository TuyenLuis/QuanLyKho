import { validationResult } from 'express-validator'

import ultilitiesService from '../services/ultilitiesService'
import authService from '../services/authService'
import { transError, transSuccess } from '../constants/languageEn'

const accessTokenLife = process.env.ACCESS_TOKEN_LIFE
const accessTokenSecret = process.env.ACCESS_TOKEN_SECRET
const refreshTokenLife = process.env.REFRESH_TOKEN_LIFE
const refreshTokenSecret = process.env.REFRESH_TOKEN_SECRET

const login = async (req, res) => {
  try {
    let employeeResult = await authService.getEmployeeByUserName(req.pool, req.body.username)
    if (!employeeResult.length) {
      return res.status(401).send({ message: transError.login_failed })
    }

    let employee = employeeResult[0]

    let comparePassword = await ultilitiesService.comparePassword(req.body.password, employee.Password)
    if (!comparePassword) {
      return res.status(401).send({ message: transError.login_failed })
    }

    let employeeInfo = await authService.getEmployeeInfo(employee.Id, req.pool)
    const accessToken = await ultilitiesService.generateToken(employeeInfo, accessTokenSecret, accessTokenLife)
    const refreshToken = await ultilitiesService.generateToken(employeeInfo, refreshTokenSecret, refreshTokenLife)
    await authService.saveToken(req.pool, refreshToken, accessToken)

    return res.status(200).send({
      employee: employeeInfo,
      accessToken,
      refreshToken
    })
  } catch (err) {
    return res.status(500).send({ message: transError.authen_process })
  }
}

const refreshToken = async (req, res) => {
  const refreshTokenFromClient = req.body.refreshToken
  let tokenList = await authService.getAllToken(req.pool)

  if (refreshTokenFromClient && tokenList[refreshTokenFromClient]) {
    try {
      const decoded = await ultilitiesService.verifyToken(refreshTokenFromClient, refreshTokenSecret)
      const user = decoded.data
      const accessToken = await ultilitiesService.generateToken(user, accessTokenSecret, accessTokenLife)

      return res.status(200).send({ accessToken })
    } catch (error) {
      res.status(403).send({
        message: 'Invalid refresh token.'
      })
    }
  } else {
    return res.status(403).send({
      message: 'No token provided.'
    })
  }
}

const register = async (req, res) => {
  const errorArr = []
  const validationErrors = validationResult(req)
  if (!validationErrors.isEmpty()) {
    let errors = Object.values(validationErrors.mapped())
    errors.forEach(err => {
      errorArr.push(err.msg)
    })

    if (errorArr.length) {
      return res.status(500).send({ errorArr })
    }
  }

  try {
    const employeeId = await authService.register(req.body, req.pool)
    const employee = await authService.getEmployeeInfo(employeeId, req.pool)
    return res.status(200).send({
      message: transSuccess.register,
      employee
    })
  } catch (err) {
    errorArr.push(err)
    return res.status(500).send({ errorArr })
  }
}

const changePassword = async (req, res) => {
  try {
    let oldPassword = req.body.oldPassword
    let newPassword = req.body.newPassword
    let confirmPassword = req.body.confirmPassword
    let employeeId = req.body.employeeId

    let isPasswordCorrect = await authService.checkPassword(employeeId, oldPassword, req.pool)
    if (!isPasswordCorrect) {
      return res.status(500).send({
        message: transError.password_incorrect
      })
    }

    if (confirmPassword !== newPassword) {
      return res.status(500).send({
        message: transError.confirm_password_incorrect
      })
    }

    let isUpdatePasswordSuccess = await authService.updatePassword(employeeId, newPassword, req.pool)
    if (isUpdatePasswordSuccess) {
      return res.status(200).send({
        message: transSuccess.update_password
      })
    } else {
      return res.status(200).send({
        message: transError.update_password
      })
    }
  } catch (error) {
    return res.status(500).send({ errorArr })
  }
}

module.exports = {
  login,
  refreshToken,
  register,
  changePassword
}
