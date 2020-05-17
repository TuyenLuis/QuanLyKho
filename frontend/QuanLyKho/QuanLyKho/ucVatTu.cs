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
    public partial class ucVatTu : UserControl
    {
        public ucVatTu()
        {
            InitializeComponent();
        }

        private List<VatTu> listVatTu = new List<VatTu>();
        private VatTu currentVatTu = null;
        protected override void OnLoad(EventArgs e)
        {
            LoadVatTu();
        }

        private async void LoadVatTu()
        {
            var result = await VatTuService.LayTatCaVatTu();
            var resultNhomVatTu = await NhomVatTuService.LayTatCaNhomVatTu();
            var resultNhaCungCap = await NhaCungCapService.LayTatCaNhaCungCap();
        //    MessageBox.Show(result.Message.ToString());
            if (result != null && result.Status == Config.CODE_OK)
            {
                listVatTu = (List<VatTu>)result.Data;
                lvVatTu.Items.Clear();
                foreach (VatTu vatTu in listVatTu)
                {
                    ListViewItem listViewItem = new ListViewItem(vatTu.Ma.ToString());
                    listViewItem.SubItems.Add(vatTu.Ten);
                    listViewItem.SubItems[0].Tag = vatTu.Id;
                    listViewItem.SubItems.Add(vatTu.DonGiaNhap.ToString());
                    listViewItem.SubItems.Add(vatTu.DonGia.ToString());
                    listViewItem.SubItems.Add(vatTu.SoLuong.ToString());
                    listViewItem.SubItems.Add(vatTu.DonViTinh);
                    listViewItem.SubItems.Add(vatTu.TenNhomVatTu);
                    listViewItem.SubItems.Add(vatTu.TenNhaCungCap);
                    lvVatTu.Items.Add(listViewItem);
                }
            }
            if (resultNhomVatTu != null && resultNhomVatTu.Status == Config.CODE_OK)
            {
                comboBoxEx1.DataSource = (List<NhomVatTu>)resultNhomVatTu.Data;
                comboBoxEx1.ValueMember = "Id";
                comboBoxEx1.DisplayMember = "Ten";
            }
            if (resultNhaCungCap != null && resultNhaCungCap.Status == Config.CODE_OK)
            {
                comboBoxEx2.DataSource = (List<NhaCungCap>)resultNhaCungCap.Data;
                comboBoxEx2.ValueMember = "Id";
                comboBoxEx2.DisplayMember = "Ten";
            }
        }

        private void ClearLayout()
        {
            txtMaVatTu.Text = "";
            txtTenVatTu.Text = "";
            txtDonViTinh.Text = "";
            txtDonGiaBan.Text = "";
            txtDonGiaNhap.Text = "";
        }

        private void lvVatTu_selectedindexchanged(object sender, EventArgs e)
        {
            if (lvVatTu.SelectedItems.Count > 0)
            {
                ListViewItem lvItem = lvVatTu.SelectedItems[0];
                txtMaVatTu.Text = lvItem.SubItems[0].Text;
                txtIdVatTu.Text = lvItem.SubItems[0].Tag.ToString();
                txtTenVatTu.Text = lvItem.SubItems[1].Text;
                txtDonGiaNhap.Text = lvItem.SubItems[2].Text;
                txtDonGiaBan.Text = lvItem.SubItems[3].Text;
                txtDonViTinh.Text = lvItem.SubItems[5].Text;
                comboBoxEx1.Text = lvItem.SubItems[6].Text;
                comboBoxEx2.Text = lvItem.SubItems[7].Text;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaVatTu.Text = UtilitiesService.AutoGenarateCode(Config.P_VT);
            txtTenVatTu.Text = "";
            txtDonViTinh.Text = "";
            txtDonGiaBan.Text = "";
            txtDonGiaNhap.Text = "";
            currentVatTu = new VatTu();
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            ResponseData result = null;
            if (currentVatTu != null) // Add new
            {
                currentVatTu.Ma = txtMaVatTu.Text;
                currentVatTu.Ten = txtTenVatTu.Text;
                currentVatTu.DonGiaNhap = int.Parse(txtDonGiaNhap.Text);
                currentVatTu.DonGia = int.Parse(txtDonGiaBan.Text);
                currentVatTu.DonViTinh = txtDonViTinh.Text;
                currentVatTu.IdNhomVatTu = comboBoxEx1.SelectedValue.ToString();
                currentVatTu.IdNhaCungCap = comboBoxEx2.SelectedValue.ToString();

                result = await VatTuService.ThemVatTu(currentVatTu);
            }
            else // Update
            {
                currentVatTu = new VatTu();
                currentVatTu.Ma = txtMaVatTu.Text;
                currentVatTu.Ten = txtTenVatTu.Text;
                currentVatTu.DonGiaNhap = int.Parse(txtDonGiaNhap.Text);
                currentVatTu.DonGia = int.Parse(txtDonGiaBan.Text);
                currentVatTu.DonViTinh = txtDonViTinh.Text;
                currentVatTu.IdNhomVatTu = comboBoxEx1.SelectedValue.ToString();
                currentVatTu.IdNhaCungCap = comboBoxEx2.SelectedValue.ToString();

                currentVatTu.Id = int.Parse(txtIdVatTu.Text);
                result = await VatTuService.CapNhatVatTu(currentVatTu);
            }

            if (result.Status == Config.CODE_OK)
            {
                MessageBoxEx.Show(result.Message, "Thông báo");
                ClearLayout();
                LoadVatTu();
            }
            else if (result != null)
            {
                MessageBoxEx.Show(result.Message, "Thông báo");
            }
            else
            {
                MessageBoxEx.Show("Opps!!!", "Thông báo");
            }

            currentVatTu = null;
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvVatTu.SelectedItems.Count == 0)
            {
                MessageBoxEx.Show("Bạn phải chọn 1 nhà cung cấp để xóa!", "Thông báo");
            }
            else
            {
                int idNhomVatTu = txtIdVatTu.Text == "" ? 0 : int.Parse(txtIdVatTu.Text);
                if (idNhomVatTu == 0)
                {
                    MessageBoxEx.Show("Không thể xóa nhóm vật tư này!", "Thông báo");
                }
                else
                {
                    DialogResult res = MessageBoxEx.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này ?", "Thông báo", MessageBoxButtons.OKCancel);
                    if (res == DialogResult.OK)
                    {
                        var result = await VatTuService.XoaVatTu(idNhomVatTu);
                        if (result.Status == Config.CODE_OK)
                        {
                            MessageBoxEx.Show("Xóa nhóm vật tư thành công", "Thông báo");
                            LoadVatTu();
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
                if (tabItem.Name == "tabVatTu")
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
