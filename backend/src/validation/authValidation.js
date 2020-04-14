import { check } from 'express-validator'
import { transValidation } from './../constants/languageEn'

let register = [
  check('username', transValidation.username_incorrect )
    .matches(/^[\s0-9a-zA-Z ]+$/)
    .isLength({ max: 50, min: 1 })
    .trim(),
  check('password', transValidation.password_incorrect)
    .isLength({ min: 8 }),
  check('confirmPassword', transValidation.password_confirmation_incorrect)
    .custom((value, { req }) => {
      return value === req.body.password
    })
]

module.exports = {
  register
}
