using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Constant;
using DevComponents.DotNetBar;

namespace QuanLyKho
{
    public partial class frmMain : Office2007Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public static frmMain _frmMain;
        public static frmMain FrmMain
        {
            get
            {
                if (_frmMain == null)
                {
                    _frmMain = new frmMain();
                }
                return _frmMain;
            }
        }

        public Panel PanelContainer
        {
            get
            {
                return panelContainer;
            }
            set
            {
                panelContainer = value;
            }
        }

        public DevComponents.DotNetBar.TabControl TabContainer
        {
            get
            {
                return tabContainer;
            }
            set
            {
                tabContainer = value;
            }
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            ButtonItem btnItem = sender as ButtonItem;
            string tabName = btnItem.Tag.ToString();
            string tabText = btnItem.Description.ToString();

            foreach (TabItem tabItem in TabContainer.Tabs)
            {
                if (tabItem.Name == tabName)
                {
                    TabContainer.SelectedTab = tabItem;
                    return;
                }
            }

            TabItem newTab = TabContainer.CreateTab(tabText);
            newTab.Name = tabName;
            TabContainer.SelectedTab = newTab;
            TabControlPanel panel = (TabControlPanel)newTab.AttachedControl;
            panel.BringToFront();

            switch (tabName)
            {
                case "tabNhanVien":
                    if (Common.ucNhanVien == null || Common.ucNhanVien.IsDisposed)
                    {
                        Common.ucNhanVien = new ucNhanVien();
                    }
                    panel.Controls.Add(Common.ucNhanVien);
                    Common.ucNhanVien.Dock = DockStyle.Fill;
                    Common.ucNhanVien.BringToFront();
                    break;
                case "tabNhaCungCap":
                    if (Common.ucNhaCungCap == null || Common.ucNhaCungCap.IsDisposed)
                    {
                        Common.ucNhaCungCap = new ucNhaCungCap();
                    }
                    panel.Controls.Add(Common.ucNhaCungCap);
                    Common.ucNhaCungCap.Dock = DockStyle.Fill;
                    Common.ucNhaCungCap.BringToFront();
                    break;
                case "tabVatTu":
                    if (Common.ucVatTu == null || Common.ucVatTu.IsDisposed)
                    {
                        Common.ucVatTu = new ucVatTu();
                    }
                    panel.Controls.Add(Common.ucVatTu);
                    Common.ucVatTu.Dock = DockStyle.Fill;
                    Common.ucVatTu.BringToFront();
                    break;
                case "tabNhomVatTu":
                    if (Common.ucNhomVatTu == null || Common.ucNhomVatTu.IsDisposed)
                    {
                        Common.ucNhomVatTu = new ucNhomVatTu();
                    }
                    panel.Controls.Add(Common.ucNhomVatTu);
                    Common.ucNhomVatTu.Dock = DockStyle.Fill;
                    Common.ucNhomVatTu.BringToFront();
                    break;
                case "tabKho":
                    if (Common.ucKho == null || Common.ucKho.IsDisposed)
                    {
                        Common.ucKho = new ucKho();
                    }
                    panel.Controls.Add(Common.ucKho);
                    Common.ucKho.Dock = DockStyle.Fill;
                    Common.ucKho.BringToFront();
                    break;
                case "tabNhapKho":
                    if (Common.ucNhapKho == null || Common.ucNhapKho.IsDisposed)
                    {
                        Common.ucNhapKho = new ucNhapKho();
                    }
                    panel.Controls.Add(Common.ucNhapKho);
                    Common.ucNhapKho.Dock = DockStyle.Fill;
                    Common.ucNhapKho.BringToFront();
                    break;
                case "tabXuatKho":
                    if (Common.ucXuatKho == null || Common.ucXuatKho.IsDisposed)
                    {
                        Common.ucXuatKho = new ucXuatKho();
                    }
                    panel.Controls.Add(Common.ucXuatKho);
                    Common.ucXuatKho.Dock = DockStyle.Fill;
                    Common.ucXuatKho.BringToFront();
                    break;
                case "tabChuyenKho":
                    if (Common.ucChuyenKho == null || Common.ucChuyenKho.IsDisposed)
                    {
                        Common.ucChuyenKho = new ucChuyenKho();
                    }
                    panel.Controls.Add(Common.ucChuyenKho);
                    Common.ucChuyenKho.Dock = DockStyle.Fill;
                    Common.ucChuyenKho.BringToFront();
                    break;
                default:
                    MessageBoxEx.Show("Opps!!!");
                    break;
            }
        }

        private void btnItemDangNhap_Click(object sender, EventArgs e)
        {
            RemoveAllTabItems();
            if (Common.frmDangNhap == null || Common.frmDangNhap.IsDisposed)
            {
                Common.frmDangNhap = new frmDangNhap();
            }
            Common.frmDangNhap.ShowDialog();
        }

        private void RemoveAllTabItems()
        {
            TabContainer.Tabs.Clear();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _frmMain = this;
            DisableControl();
            if (Common.frmDangNhap == null || Common.frmDangNhap.IsDisposed)
            {
                Common.frmDangNhap = new frmDangNhap();
            }
            Common.frmDangNhap.ShowDialog();
            if (UserResponse.Id != 0)
            {
                toolHienThi.Text = "Xin chào " + UserResponse.NhanVien.Ten + ". Chúc bạn 1 ngày làm việc tốt lành!";
                buttonItemDangNhapVoiQuyen.Text = "Xin chào " + UserResponse.NhanVien.Ten;
                CheckPhanQuyen();
            }
            else
            {
                DisableControl();
            }
        }

        private void CheckPhanQuyen()
        {
            if (UserResponse.Roles.Name == Config.ROLE_ADMIN)
            {
                buttonItemMenuChuyenTaiKhoanKhac.Enabled = true;
                buttonItemMenuDoiMatKhau.Enabled = true;
                btnItemChuyenSangTaiKhoanKhac.Enabled = true;
                btnItemPhanQuyenNguoiDung.Enabled = true;
                btnItemDoiMatKhau.Enabled = true;
                btnItemHoSoNhanVien.Enabled = true;
                btnItemNhaCungCap.Enabled = true;
                btnItemVatTu.Enabled = true;
                btnItemNhomVatTu.Enabled = true;
                btnItemKho.Enabled = true;
                btnItemNhapKho.Enabled = true;
                btnItemXuatKho.Enabled = true;
                btnItemChuyenKho.Enabled = true;
            }
            else if (UserResponse.Roles.Name == Config.ROLE_EMPLOYEE)
            {
                buttonItemMenuChuyenTaiKhoanKhac.Enabled = true;
                buttonItemMenuDoiMatKhau.Enabled = true;
                btnItemPhanQuyenNguoiDung.Enabled = false;
                btnItemChuyenSangTaiKhoanKhac.Enabled = true;
                btnItemDoiMatKhau.Enabled = true;
                btnItemHoSoNhanVien.Enabled = false;
                btnItemNhaCungCap.Enabled = true;
                btnItemVatTu.Enabled = true;
                btnItemNhomVatTu.Enabled = true;
                btnItemKho.Enabled = false;
                btnItemNhapKho.Enabled = true;
                btnItemXuatKho.Enabled = true;
                btnItemChuyenKho.Enabled = true;
            }
        }

        private void DisableControl()
        {
            buttonItemMenuChuyenTaiKhoanKhac.Enabled = false;
            buttonItemMenuDoiMatKhau.Enabled = false;
            btnItemChuyenSangTaiKhoanKhac.Enabled = false;
            btnItemPhanQuyenNguoiDung.Enabled = false;
            btnItemDoiMatKhau.Enabled = false;
            btnItemHoSoNhanVien.Enabled = false;
            btnItemNhaCungCap.Enabled = false;
            btnItemVatTu.Enabled = false;
            btnItemNhomVatTu.Enabled = false;
            btnItemKho.Enabled = false;
            btnItemNhapKho.Enabled = false;
            btnItemXuatKho.Enabled = false;
            btnItemChuyenKho.Enabled = false;
        }
    }
}
