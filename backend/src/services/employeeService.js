import sql from 'mssql'
import { transError } from './../constants/languageEn'

const getAllEmployee = pool => {
  return new Promise(async (resolve, reject) => {
    try {
      let listEmployeeResult = await pool.request()
        .query(`
          SELECT [Id]
                ,[Ma]
                ,[Ten]
                ,[GioiTinh]
                ,[NgaySinh]
                ,[DiaChi]
                ,[CMND]
                ,[SDT]
                ,[Email]
                ,[NgayVaoLam]
            FROM [NhanVien]
        `)
      resolve(listEmployeeResult.recordset)
    } catch (error) {
      return reject(error)
    }
  })
}

const getListEmployee = (pool, pageSize, pageNumber = 1) => {
  return new Promise(async (resolve, reject) => {
    try {
      let emloyeeResult = await pool.request()
        .input('pageSize', sql.Int, pageSize)
        .input('pageNumber', sql.Int, pageNumber)
        .output('pageAmount', sql.Int)
        .execute('dbo.Usp_GetListEmployeePaging')

      return resolve({
        listEmployee: emloyeeResult.recordset,
        pageAmount: emloyeeResult.output.pageAmount
      })
    } catch (error) {
      return reject(error)
    }
  })
}

const addNewEmployee = (pool, employee) => {
  return new Promise(async (resolve, reject) => {
    try {
      let emloyeeResult = await pool.request()
        .input('Ma', sql.NVarChar(50), employee.Ma)
        .input('Ten', sql.NVarChar(50), employee.Ten)
        .input('GioiTinh', sql.Bit, employee.GioiTinh)
        .input('NgaySinh', sql.Date, employee.NgaySinh)
        .input('DiaChi', sql.NVarChar(250), employee.DiaChi)
        .input('CMND', sql.NVarChar(50), employee.CMND)
        .input('SDT', sql.NVarChar(50), employee.SDT)
        .input('Email', sql.NVarChar(50), employee.Email)
        .input('NgayVaoLam', sql.Date, employee.NgayVaoLam)
        .output('Id', sql.Int)
        .execute('dbo.Usp_AddNewEmployee')

      if (emloyeeResult.output.Id) {
        return resolve(emloyeeResult.output.Id)
      } else {
        return reject(transError.add_employee)
      }
    } catch (error) {
      return reject(error)
    }
  })
}

const updateEmployee = (pool, employee) => {
  return new Promise(async (resolve, reject) => {
    try {
      let emloyeeResult = await pool.request()
        .input('Ma', sql.NVarChar(50), employee.Ma)
        .input('Ten', sql.NVarChar(50), employee.Ten)
        .input('GioiTinh', sql.Bit, employee.GioiTinh)
        .input('NgaySinh', sql.Date, employee.NgaySinh)
        .input('DiaChi', sql.NVarChar(250), employee.DiaChi)
        .input('CMND', sql.NVarChar(50), employee.CMND)
        .input('SDT', sql.NVarChar(50), employee.SDT)
        .input('Email', sql.NVarChar(50), employee.Email)
        .input('NgayVaoLam', sql.Date, employee.NgayVaoLam)
        .input('Id', sql.Int, employee.Id)
        .query(`
          UPDATE NhanVien
          SET Ma = @Ma,
              Ten = @Ten,
              GioiTinh = @GioiTinh,
              NgaySinh = @NgaySinh,
              DiaChi = @DiaChi,
              CMND = @CMND,
              SDT = @SDT,
              Email = @Email,
              NgayVaoLam = @NgayVaoLam,
              UpdatedAt = GETDATE()
          WHERE Id = @Id
        `)

      return resolve(emloyeeResult)
    } catch (error) {
      return reject(error)
    }
  })
}

const removeEmployee = (pool, employeeId) => {
  return new Promise(async (resolve, reject) => {
    try {
      let emloyeeResult = await pool.request()
        .input('EmployeeId', sql.Int, employeeId)
        .execute('Usp_DeleteEmployee')

      return resolve(emloyeeResult)
    } catch (error) {
      return reject(error)
    }
  })
}

module.exports = {
  getAllEmployee,
  getListEmployee,
  addNewEmployee,
  updateEmployee,
  removeEmployee
}
