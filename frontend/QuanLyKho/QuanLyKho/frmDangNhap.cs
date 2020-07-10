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
        public int test = 0;
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
            if (result.Status == Config.CODE_OK && (bool)result.Data)
            {
                MessageBoxEx.Show(ResponseMessage.Login_Success, "Thông báo");
                this.Close();
            }
            else if (result.Status == Config.CODE_UNAUTHORIZED && !(bool)result.Data)
            {
                MessageBoxEx.Show(result.Message, "Thông báo");
            }
            else
            {
                MessageBoxEx.Show(result.Message, "Thông báo");
            }
        }
    }
}
