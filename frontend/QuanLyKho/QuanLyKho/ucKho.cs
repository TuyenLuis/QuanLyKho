using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Service;
using Constant;
using DevComponents.DotNetBar;

namespace QuanLyKho
{
    public partial class ucKho : UserControl
    {
        public ucKho()
        {
            InitializeComponent();
        }

        private List<Kho> listKho = new List<Kho>();
        private List<NhanVien> listNhanVien = new List<NhanVien>();
        private Kho currentKho = null;

        protected override void OnLoad(EventArgs e)
        {
            LoadNhanVienComboBox();
            LoadKho();
        }

        private async void LoadNhanVienComboBox()
        {
            var result = await NhanVienService.LayTatCaNhanVien();
            if (result != null && result.Status == Config.CODE_OK)
            {
                listNhanVien = (List<NhanVien>)result.Data;
            }
            cboQuanLy.DataSource = listNhanVien;
            cboQuanLy.DisplayMember = "Ten";
            cboQuanLy.ValueMember = "Id";
        }

        private async void LoadKho()
        {
            var result = await KhoService.LayTatCaKho();
            if (result != null && result.Status == Config.CODE_OK)
            {
                listKho = (List<Kho>)result.Data;
                lvKho.Items.Clear();
                foreach (Kho kho in listKho)
                {
                    ListViewItem listViewItem = new ListViewItem(kho.Ma.ToString());
                    listViewItem.SubItems.Add(kho.Ten);
                    listViewItem.SubItems.Add(kho.DiaChi);
                    listViewItem.SubItems.Add(kho.SDT);
                    listViewItem.SubItems.Add(kho.QuanLy.Ten);
                    listViewItem.SubItems.Add(kho.GhiChu);

                    listViewItem.SubItems[0].Tag = kho.Id;
                    lvKho.Items.Add(listViewItem);
                }
            }
        }

        private void ClearLayout()
        {
            txtMaKho.Text = "";
            txtDiaChi.Text = "";
            txtGhiChu.Text = "";
            txtSDT.Text = "";
            txtTenKho.Text = "";
            cboQuanLy.Text = "";
        }

        private void lvKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKho.SelectedItems.Count > 0)
            {
                ListViewItem lvItem = lvKho.SelectedItems[0];
                txtMaKho.Text = lvItem.SubItems[0].Text;
                txtTenKho.Text = lvItem.SubItems[1].Text;
                txtDiaChi.Text = lvItem.SubItems[2].Text;
                txtSDT.Text = lvItem.SubItems[3].Text;
                cboQuanLy.Text = lvItem.SubItems[4].Text;
                txtGhiChu.Text = lvItem.SubItems[5].Text;
                txtIdKho.Text = lvItem.SubItems[0].Tag.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaKho.Text = UtilitiesService.AutoGenarateCode(Config.P_KHO);
            txtTenKho.Text = "";
            txtDiaChi.Text = "";
            txtGhiChu.Text = "";
            txtSDT.Text = "";
            cboQuanLy.Text = "";
            txtIdKho.Text = "";
            currentKho = new Kho();
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            ResponseData result = null;
            if (currentKho != null) // Add new
            {
                currentKho.Ma = txtMaKho.Text;
                currentKho.Ten = txtTenKho.Text;
                currentKho.DiaChi = txtDiaChi.Text;
                currentKho.GhiChu = txtGhiChu.Text;
                currentKho.SDT = txtSDT.Text;
                currentKho.QuanLy = new NhanVien() { Id = (int)cboQuanLy.SelectedValue };

                result = await KhoService.ThemMoiKho(currentKho);
            }
            else // Update
            {
                currentKho = new Kho();
                currentKho.Ma = txtMaKho.Text;
                currentKho.Ten = txtTenKho.Text;
                currentKho.DiaChi = txtDiaChi.Text;
                currentKho.GhiChu = txtGhiChu.Text;
                currentKho.SDT = txtSDT.Text;
                currentKho.QuanLy = new NhanVien() { Id = (int)cboQuanLy.SelectedValue };
                currentKho.Id = int.Parse(txtIdKho.Text);

                result = await KhoService.CapNhatKho(currentKho);
            }

            if (result.Status == Config.CODE_OK)
            {
                MessageBoxEx.Show(result.Message, "Thông báo");
                ClearLayout();
                LoadKho();
            }
            else if (result != null)
            {
                MessageBoxEx.Show(result.Message, "Thông báo");
            }
            else
            {
                MessageBoxEx.Show("Opps!!!", "Thông báo");
            }

            currentKho = null;
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvKho.SelectedItems.Count == 0)
            {
                MessageBoxEx.Show("Bạn phải chọn 1 nhà kho để xóa!", "Thông báo");
            }
            else
            {
                int idKho = txtIdKho.Text == "" ? 0 : int.Parse(txtIdKho.Text);
                if (idKho == 0)
                {
                    MessageBoxEx.Show("Không thể xóa nhà kho này!", "Thông báo");
                }
                else
                {
                    DialogResult res = MessageBoxEx.Show("Bạn có chắc chắn muốn xóa nhà kho này ?", "Thông báo", MessageBoxButtons.OKCancel);
                    if (res == DialogResult.OK)
                    {
                        var result = await KhoService.XoaKho(idKho);
                        if (result.Status == Config.CODE_OK)
                        {
                            MessageBoxEx.Show("Xóa nhà kho thành công", "Thông báo");
                            LoadKho();
                            ClearLayout();
                        }
                        else
                        {
                            MessageBoxEx.Show("Xóa nhà kho thất bại", "Thông báo");
                        }
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            foreach (TabItem tabItem in frmMain.FrmMain.TabContainer.Tabs)
            {
                if (tabItem.Name == "tabKho")
                {
                    frmMain.FrmMain.TabContainer.Tabs.Remove(tabItem);
                    frmMain.FrmMain.TabContainer.Controls.Remove(tabItem.AttachedControl);
                    frmMain.FrmMain.TabContainer.RecalcLayout();
                    return;
                }
            }
        }
    }
}
