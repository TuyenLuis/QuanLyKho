import sql from 'mssql'

const getAllUser = pool => {
  return new Promise(async (resolve, reject) => {
    try {
      let listUserResult = await pool.request()
        .query(`
          SELECT  U.Id ,
                  U.Username ,
                  U.IdRole ,
                  R.Name AS RoleName ,
                  N.Id AS EmployeeId ,
                  N.Ten AS EmployeeName
          FROM    Users U
                  INNER JOIN Roles R ON U.IdRole = R.Id
                  LEFT JOIN NhanVien N ON N.UserId = U.Id
        `)
      resolve(listUserResult.recordset)
    } catch (error) {
      return reject(error)
    }
  })
}

module.exports = {
  getAllUser
}