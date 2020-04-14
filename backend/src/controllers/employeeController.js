import employeeService from './../services/employeeService'
import config from './../constants/config'
import { transError, transSuccess, transValidation } from './../constants/languageEn'

const NUMBER_EMPLOYEE_PER_PAGE = 20

const getAllEmployee = async (req, res) => {
  try {
    let listEmployee = await employeeService.getAllEmployee(req.pool)
    return res.status(200).send({
      data: listEmployee
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const getListEmployee = async (req, res) => {
  try {
    let pageNumber = req.query.page || 1
    let { listEmployee, pageAmount } = await employeeService.getListEmployee(req.pool, NUMBER_EMPLOYEE_PER_PAGE, pageNumber)
    return res.status(200).send({
      data: {
        currentPage: +pageNumber,
        pageAmount,
        listEmployee
      }
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const addNewEmployee = async (req, res) => {
  try {
    let employee = {
      Ma: req.body.ma || null,
      Ten: req.body.ten || null,
      GioiTinh: req.body.gioiTinh || null,
      NgaySinh: req.body.ngaySinh || null,
      DiaChi: req.body.diaChi || null,
      CMND: req.body.CMND || null,
      SDT: req.body.SDT || null,
      Email: req.body.email || null,
      NgayVaoLam: req.body.ngayVaoLam || null
    }

    let employeeId = await employeeService.addNewEmployee(req.pool, employee)
    return res.status(200).send({
      message: transSuccess.add_employee,
      data: { employeeId }
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const updateEmployee = async (req, res) => {
  try {
    let employee = {
      Ma: req.body.ma || null,
      Ten: req.body.ten || null,
      GioiTinh: req.body.gioiTinh || null,
      NgaySinh: req.body.ngaySinh || null,
      DiaChi: req.body.diaChi || null,
      CMND: req.body.CMND || null,
      SDT: req.body.SDT || null,
      Email: req.body.email || null,
      NgayVaoLam: req.body.ngayVaoLam || null,
      Id: req.body.employeeId || null
    }

    await employeeService.updateEmployee(req.pool, employee)
    return res.status(200).send({
      message: transSuccess.update_employee
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

const removeEmployee = async (req, res) => {
  try {
    await employeeService.removeEmployee(req.pool, req.body.employeeId)
    return res.status(200).send({
      message: transSuccess.remove_employee
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}


module.exports = {
  getAllEmployee,
  getListEmployee,
  addNewEmployee,
  updateEmployee,
  removeEmployee
}
