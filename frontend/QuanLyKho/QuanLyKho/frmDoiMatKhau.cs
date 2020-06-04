using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service;
using Constant;

namespace QuanLyKho
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btDongY_Click(object sender, EventArgs e)
        {
            string oldPassword = txtMKHienTai.Text;
            string newPassword = txtMKMoi.Text;
            string confirmPassword = txtKDMatKhau.Text;

            if (confirmPassword != newPassword)
            {
                MessageBoxEx.Show("Nhập lại mật khẩu không chính xác. Xin kiểm tra lại", "Thông báo");
                return;
            }

            var result = await UserService.DoiMatKhau(oldPassword, newPassword, confirmPassword);
            if (result != null && result.Status == Config.CODE_OK)
            {
                var message = (string)result.Data;
                MessageBoxEx.Show(message, "Thông báo");
            }
            else
            {
                MessageBoxEx.Show("Mật khẩu hiện tại không chính xác. Xin kiểm tra lại", "Thông báo");
            }
        }
    }
}
