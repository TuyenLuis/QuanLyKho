import { transError } from './../constants/languageEn'
import config from './../constants/config'

const isAdmin = (req, res, next) => {
  let isAdmin = req.user.RoleName === config.ROLES.ADMIN
  if (isAdmin) {
    next()
  } else {
    return res.status(403).send({ message: transError.permission_denied })
  }
}

const isEmployee = (req, res, next) => {
  let isEmployee = req.user.RoleName === config.ROLES.EMPLOYEE
  if (isEmployee) {
    next()
  } else {
    return res.status(403).send({ message: transError.permission_denied })
  }
}

module.exports = {
  isAdmin,
  isEmployee
}
