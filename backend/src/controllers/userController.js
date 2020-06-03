import userService from './../services/userService'

const getAllUser = async (req, res) => {
  try {
    let listUser = await userService.getAllUser(req.pool)
    return res.status(200).send({
      data: listUser
    })
  } catch (error) {
    return res.status(500).send({ error })
  }
}

module.exports = {
  getAllUser
}
