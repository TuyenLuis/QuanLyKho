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
    public partial class ucNhanVien : UserControl
    {
        public ucNhanVien()
        {
            InitializeComponent();
        }

        private List<NhanVien> listNhanVien = new List<NhanVien>();
        private NhanVien currentnhanVien = null;

        protected override void OnLoad(EventArgs e)
        {
            LoadnhanVien();
        }

        private async void LoadnhanVien()
        {
            var result = await NhanVienService.LayTatCaNhanVien();
            if (result != null && result.Status == Config.CODE_OK)
            {
                listNhanVien = (List<NhanVien>)result.Data;
                lvNhanVien.Items.Clear();
                foreach (NhanVien nhanVien in listNhanVien)
                {
                    ListViewItem listViewItem = new ListViewItem(nhanVien.Ma.ToString());
                    listViewItem.SubItems.Add(nhanVien.Ten);
                    listViewItem.SubItems.Add(nhanVien.GioiTinh != null ? (nhanVien.GioiTinh.Value ? "Nữ" : "Nam") : "");
                    listViewItem.SubItems.Add(nhanVien.NgaySinh.ToShortDateString());
                    listViewItem.SubItems.Add(nhanVien.DiaChi);
                    listViewItem.SubItems.Add(nhanVien.SDT);
                    listViewItem.SubItems.Add(nhanVien.CMND);
                    listViewItem.SubItems.Add(nhanVien.Email);
                    listViewItem.SubItems.Add(nhanVien.NgayVaoLam.ToString());

                    listViewItem.SubItems[0].Tag = nhanVien.Id;
                    lvNhanVien.Items.Add(listViewItem);
                }
            }
            dateTimeInput1.Value = DateTime.Now;
            dateTimeInput2.Value = DateTime.Now;
            rdNam.Checked = true;
        }

        private void ClearLayout()
        {
            txtManhanVien.Text = "";
            txtTennhanVien.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtCMND.Text = "";
            dateTimeInput1.Value = DateTime.Now;
            dateTimeInput2.Value = DateTime.Now;
            rdNam.Checked = true;
        }

        private void lvnhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvNhanVien.SelectedItems.Count > 0)
            {
                ListViewItem lvItem = lvNhanVien.SelectedItems[0];
                txtManhanVien.Text = lvItem.SubItems[0].Text;
                txtIdNhanVien.Text = lvItem.SubItems[0].Tag.ToString();
                txtTennhanVien.Text = lvItem.SubItems[1].Text;
                if (lvItem.SubItems[2].Text == "Nam")
                {
                    rdNam.Checked = true;
                }
                else if (lvItem.SubItems[2].Text == "Nữ")
                {
                    rdNu.Checked = true;
                } 
                else
                {
                    rdNam.Checked = rdNu.Checked = false;
                }
                dateTimeInput1.Value = DateTime.Parse(lvItem.SubItems[3].Text);
                txtDiaChi.Text = lvItem.SubItems[4].Text;
                txtCMND.Text = lvItem.SubItems[5].Text;
                txtSDT.Text = lvItem.SubItems[6].Text;
                txtEmail.Text = lvItem.SubItems[7].Text;
                dateTimeInput2.Value = DateTime.Parse(lvItem.SubItems[8].Text).Date;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtManhanVien.Text = UtilitiesService.AutoGenarateCode(Config.P_NV);
            txtTennhanVien.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtCMND.Text = "";
            txtIdNhanVien.Text = "";
            dateTimeInput1.Value = DateTime.Now;
            dateTimeInput2.Value = DateTime.Now;
            rdNam.Checked = true;

            currentnhanVien = new NhanVien();
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            ResponseData result = null;
            if (currentnhanVien != null) // Add new
            {
                currentnhanVien.Ma = txtManhanVien.Text;
                currentnhanVien.Ten = txtTennhanVien.Text;
                currentnhanVien.DiaChi = txtDiaChi.Text;
                currentnhanVien.Email = txtEmail.Text;
                currentnhanVien.SDT = txtSDT.Text;
                currentnhanVien.CMND = txtCMND.Text;
                currentnhanVien.NgaySinh = dateTimeInput1.Value.AddDays(1);
                currentnhanVien.GioiTinh = rdNu.Checked;
                currentnhanVien.NgayVaoLam = dateTimeInput2.Value.AddDays(1);

                result = await NhanVienService.ThemNhanVien(currentnhanVien);
            }
            else // Update
            {
                currentnhanVien = new NhanVien();
                currentnhanVien.Ma = txtManhanVien.Text;
                currentnhanVien.Ten = txtTennhanVien.Text;
                currentnhanVien.DiaChi = txtDiaChi.Text;
                currentnhanVien.Email = txtEmail.Text;
                currentnhanVien.SDT = txtSDT.Text;
                currentnhanVien.CMND = txtCMND.Text;
                currentnhanVien.NgaySinh = dateTimeInput1.Value.AddDays(1);
                currentnhanVien.GioiTinh = rdNu.Checked ? true : false;
                currentnhanVien.NgayVaoLam = dateTimeInput2.Value.AddDays(1);
                currentnhanVien.Id = int.Parse(txtIdNhanVien.Text);

                result = await NhanVienService.CapNhatNhanVien(currentnhanVien);
            }

            if (result.Status == Config.CODE_OK)
            {
                MessageBoxEx.Show(result.Message, "Thông báo");
                ClearLayout();
                LoadnhanVien();
            }
            else if (result != null)
            {
                MessageBoxEx.Show(result.Message, "Thông báo");
            }
            else
            {
                MessageBoxEx.Show("Opps!!!", "Thông báo");
            }

            currentnhanVien = null;
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvNhanVien.SelectedItems.Count == 0)
            {
                MessageBoxEx.Show("Bạn phải chọn 1 nhân viên để xóa!", "Thông báo");
            }
            else
            {
                int idnhanVien = txtIdNhanVien.Text == "" ? 0 : int.Parse(txtIdNhanVien.Text);
                if (idnhanVien == 0)
                {
                    MessageBoxEx.Show("Không thể xóa nhân viên này!", "Thông báo");
                }
                else
                {
                    DialogResult res = MessageBoxEx.Show("Bạn có chắc chắn muốn xóa nhân viên này ?", "Thông báo", MessageBoxButtons.OKCancel);
                    if (res == DialogResult.OK)
                    {
                        var result = await NhanVienService.XoaNhanVien(idnhanVien);
                        if (result.Status == Config.CODE_OK)
                        {
                            MessageBoxEx.Show("Xóa nhân viên thành công", "Thông báo");
                            LoadnhanVien();
                            ClearLayout();
                        }
                        else
                        {
                            MessageBoxEx.Show("Xóa nhân viên thất bại", "Thông báo");
                        }
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            foreach (TabItem tabItem in frmMain.FrmMain.TabContainer.Tabs)
            {
                if (tabItem.Name == "tabNhanVien")
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
