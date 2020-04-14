module.exports = {
  ROLES: {
    ADMIN: 'Admin',
    EMPLOYEE: 'Employee'
  },
  IMAGE: {
    DIRECTORY: 'src/public/images',
    SIZE: 1048576 * 2, // 2 MB
    TYPE: ['image/png', 'image/jpg', 'image/jpeg'],
    LIMIT: 15,
    PUBLIC: 'src/public/'
  },
  ERROR_CODE: {
    LIMIT_UNEXPECTED_FILE: 'LIMIT_UNEXPECTED_FILE'
  },
  BACKEND: {
    HOST: 'http://localhost:6116/'
  },
  // BACKEND: {
  //   HOST: 'https://smartphone-store.herokuapp.com/'
  // },
  TRANSACTION_STATUS: {
    SUCCESS: 'Thành công',
    FAIL: 'Thất bại'
  },
}
