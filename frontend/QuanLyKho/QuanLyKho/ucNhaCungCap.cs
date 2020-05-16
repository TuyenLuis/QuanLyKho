using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service;
using Entity;
using Constant;
using DevComponents.DotNetBar;

namespace QuanLyKho
{
    public partial class ucNhaCungCap : UserControl
    {
        public ucNhaCungCap()
        {
            InitializeComponent();
        }

        private List<NhaCungCap> listNhacungCap = new List<NhaCungCap>();
        private NhaCungCap currentNhaCungCap = null;
        protected override void OnLoad(EventArgs e)
        {
            LoadNhaCungCap();
        }

        private async void LoadNhaCungCap()
        {
            var result = await NhaCungCapService.LayTatCaNhaCungCap();
            if (result != null && result.Status == Config.CODE_OK)
            {
                listNhacungCap = (List<NhaCungCap>)result.Data;
                lvNhaCungCap.Items.Clear();
                foreach (NhaCungCap nhaCungCap in listNhacungCap)
                {
                    ListViewItem listViewItem = new ListViewItem(nhaCungCap.Ma.ToString());
                    listViewItem.SubItems.Add(nhaCungCap.Ten);
                    listViewItem.SubItems.Add(nhaCungCap.DiaChi);
                    listViewItem.SubItems.Add(nhaCungCap.Email);
                    listViewItem.SubItems.Add(nhaCungCap.SDT);
                    listViewItem.SubItems.Add(nhaCungCap.NguoiDaiDien);

                    listViewItem.SubItems[0].Tag = nhaCungCap.Id;
                    lvNhaCungCap.Items.Add(listViewItem);
                }
            }
        }

        private void ClearLayout()
        {
            txtMaNhaCungCap.Text = "";
            txtTenNhaCungCap.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtNguoiDaiDien.Text = "";
            txtIdNhaCungCap.Text = "";
        }

        private void lvNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvNhaCungCap.SelectedItems.Count > 0)
            {
                ListViewItem lvItem = lvNhaCungCap.SelectedItems[0];
                txtMaNhaCungCap.Text = lvItem.SubItems[0].Text;
                txtIdNhaCungCap.Text = lvItem.SubItems[0].Tag.ToString();
                txtTenNhaCungCap.Text = lvItem.SubItems[1].Text;
                txtDiaChi.Text = lvItem.SubItems[2].Text;
                txtEmail.Text = lvItem.SubItems[3].Text;
                txtSDT.Text = lvItem.SubItems[4].Text;
                txtNguoiDaiDien.Text = lvItem.SubItems[5].Text;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaNhaCungCap.Text = UtilitiesService.AutoGenarateCode(Config.P_NHACC);
            txtTenNhaCungCap.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtNguoiDaiDien.Text = "";
            txtIdNhaCungCap.Text = "";
            currentNhaCungCap = new NhaCungCap();
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            ResponseData result = null;
            if (currentNhaCungCap != null) // Add new
            {
                currentNhaCungCap.Ma = txtMaNhaCungCap.Text;
                currentNhaCungCap.Ten = txtTenNhaCungCap.Text;
                currentNhaCungCap.DiaChi = txtDiaChi.Text;
                currentNhaCungCap.Email = txtEmail.Text;
                currentNhaCungCap.SDT = txtSDT.Text;
                currentNhaCungCap.NguoiDaiDien = txtNguoiDaiDien.Text;

                result = await NhaCungCapService.ThemNhaCungCap(currentNhaCungCap);
            }
            else // Update
            {
                currentNhaCungCap = new NhaCungCap();
                currentNhaCungCap.Ma = txtMaNhaCungCap.Text;
                currentNhaCungCap.Ten = txtTenNhaCungCap.Text;
                currentNhaCungCap.DiaChi = txtDiaChi.Text;
                currentNhaCungCap.Email = txtEmail.Text;
                currentNhaCungCap.SDT = txtSDT.Text;
                currentNhaCungCap.NguoiDaiDien = txtNguoiDaiDien.Text;
                currentNhaCungCap.Id = int.Parse(txtIdNhaCungCap.Text);

                result = await NhaCungCapService.CapNhatNhaCungCap(currentNhaCungCap);
            }

            if (result.Status == Config.CODE_OK)
            {
                MessageBoxEx.Show(result.Message, "Thông báo");
                ClearLayout();
                LoadNhaCungCap();
            }
            else if (result != null)
            {
                MessageBoxEx.Show(result.Message, "Thông báo");
            }
            else
            {
                MessageBoxEx.Show("Opps!!!", "Thông báo");
            }

            currentNhaCungCap = null;
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvNhaCungCap.SelectedItems.Count == 0)
            {
                MessageBoxEx.Show("Bạn phải chọn 1 nhà cung cấp để xóa!", "Thông báo");
            }
            else
            {
                int idNhacungCap = txtIdNhaCungCap.Text == "" ? 0 : int.Parse(txtIdNhaCungCap.Text);
                if (idNhacungCap == 0)
                {
                    MessageBoxEx.Show("Không thể xóa nhà cung cấp này!", "Thông báo");
                }
                else
                {
                    DialogResult res = MessageBoxEx.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này ?", "Thông báo", MessageBoxButtons.OKCancel);
                    if (res == DialogResult.OK)
                    {
                        var result = await NhaCungCapService.XoaNhaCungCap(idNhacungCap);
                        if (result.Status == Config.CODE_OK)
                        {
                            MessageBoxEx.Show("Xóa nhà cung cấp thành công", "Thông báo");
                            LoadNhaCungCap();
                            ClearLayout();
                        }
                        else
                        {
                            MessageBoxEx.Show("Xóa nhà cung cấp thất bại", "Thông báo");
                        }
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            foreach (TabItem tabItem in frmMain.FrmMain.TabContainer.Tabs)
            {
                if (tabItem.Name == "tabNhaCungCap")
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
