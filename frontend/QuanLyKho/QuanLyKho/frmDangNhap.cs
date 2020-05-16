using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Service;
using Constant;

namespace QuanLyKho
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text;
            string password = txtMatKhau.Text;
            bool saveInfo = chkLuuThongTinDangNhap.Checked;
            var result = await UserService.DangNhap(username, password);
            var loginSuccess = true;
            if (result[loginSuccess] == Config.CODE_OK)
            {
                MessageBoxEx.Show(ResponseMessage.Login_Success, "Thông báo");
                this.Close();
            }
            else if (result[loginSuccess] == Config.CODE_UNAUTHORIZED)
            {
                MessageBoxEx.Show(ResponseMessage.Login_Fail, "Thông báo");
            }
            else
            {
                MessageBoxEx.Show(ResponseMessage.Login_Error, "Thông báo");
            }
        }
    }
}
