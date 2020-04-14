import sql, { MAX } from 'mssql'

import ultilitiesService from './ultilitiesService'
import { transError } from '../constants/languageEn'

const getEmployeeInfo = (employeeId, pool) => {
  return new Promise(async (resolve, reject) => {
    try {
      let userResult = await pool.request()
        .input('Id', sql.Int, employeeId)
        .query(`
          SELECT  U.Id AS UserId ,
                  U.Username ,
                  N.Id AS NhanVienId ,
                  N.Ma AS MaNhanVien ,
                  N.Ten AS TenNhanVien ,
                  N.GioiTinh ,
                  N.NgaySinh ,
                  N.DiaChi ,
                  N.SDT ,
                  N.CMND ,
                  N.Email ,
                  N.NgayVaoLam ,
                  R.Name AS RoleName
          FROM    dbo.Users U
                  INNER JOIN dbo.Roles R ON R.Id = U.IdRole
                  INNER JOIN dbo.NhanVien N ON N.UserId = U.Id
          WHERE U.Id = @Id
        `)
      let user = userResult.recordset[0]
      resolve(user)
    } catch (error) {
      reject(error)
    }
  })
}

const getEmployeeByUserName = (pool, userName) => {
  return new Promise(async (resolve, reject) => {
    try {
      let userResult = await pool.request()
        .input('Username', sql.VarChar(50), userName)
        .query(`
          SELECT * FROM dbo.Users WHERE Username = @Username
        `)
      resolve(userResult.recordset)
    } catch (error) {
      reject(error)
    }
  })
}

const saveToken = (pool, refreshToken, accessToken) => {
  return new Promise(async (resolve, reject) => {
    try {
      let result = await pool.request()
        .input('RefreshToken', sql.NVarChar(MAX), refreshToken)
        .input('AccessToken', sql.NVarChar(MAX), accessToken)
        .execute('prc_Insert_SaveToken')
      resolve(result.recordset)
    } catch (error) {
      reject(error)
    }
  })
}

const getAllToken = pool => {
  return new Promise(async (resolve, reject) => {
    try {
      let result = await pool.request()
        .query(`
          SELECT RefreshToken, AccessToken FROM TokenLists
        `)

      let tokenList = {}
      result.recordset.forEach(token => {
        tokenList[token.RefreshToken] = token.AccessToken
      })

      resolve(tokenList)
    } catch (error) {
      reject(error)
    }
  })
}

const register = ({username, password, employeeId, roleId}, pool) => {
  return new Promise(async (resolve, reject) => {
    try {
      let checkUsername = await pool.request()
        .input('Username', sql.VarChar(128), username)
        .query(`
          SELECT COUNT(*) AS isExist FROM dbo.Users WHERE Username = @Username
        `)
      if (checkUsername.recordset[0].isExist) {
        return reject(transError.user_name_in_used)
      }

      let newUser = await pool.request()
        .input('Username', sql.NVarChar(50), username)
        .input('EmployeeId', sql.Int, employeeId)
        .input('RoleId', sql.Int, roleId)
        .input('Password', sql.NVarChar(250), ultilitiesService.hashPassword(password))
        .output('Id', sql.Int)
        .execute('dbo.Usp_CreateAccount')

      if (newUser.output.Id) {
        return resolve(newUser.output.Id)
      } else {
        return reject(transError.register_failed)
      }
    } catch (error) {
      return reject(error)
    }
  })
}

const checkPassword = (employeeId, password, pool) => {
  return new Promise(async (resolve, reject) => {
    try {
      let employeePassword = await pool.request()
        .input('EmployeeId', sql.Int, employeeId)
        .query(`
          SELECT Password
          FROM dbo.Users U
          INNER JOIN dbo.NhanVien N ON N.UserId = U.Id
          WHERE N.Id = @EmployeeId
        `)

      if (ultilitiesService.comparePassword(password, employeePassword.recordset[0].Password)) {
        return resolve(true)
      } else {
        return resolve(false)
      }

      return reject(false)
    } catch (error) {
      return reject(error)
    }
  })
}

const updatePassword = (employeeId, password, pool) => {
  return new Promise(async (resolve, reject) => {
    try {
      let passwordResult = await pool.request()
        .input('EmployeeId', sql.Int, employeeId)
        .input('Password', sql.NVarChar(250), ultilitiesService.hashPassword(password))
        .query(`
          UPDATE Users SET [Password] = @Password, [UpdatedAt] = GETDATE()
          WHERE Id = (
            SELECT UserId FROM NhanVien WHERE Id = @EmployeeId
          )
        `)
      resolve(passwordResult)
    } catch (error) {
      return reject(error)
    }
  })
}

module.exports = {
  getEmployeeInfo,
  register,
  getEmployeeByUserName,
  saveToken,
  getAllToken,
  checkPassword,
  updatePassword
}
