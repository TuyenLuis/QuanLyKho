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
    public partial class ucNhomVatTu : UserControl
    {
        public ucNhomVatTu()
        {
            InitializeComponent();
        }
        private List<NhomVatTu> listNhomVatTu = new List<NhomVatTu>();
        private NhomVatTu currentNhomVatTu = null;
        protected override void OnLoad(EventArgs e)
        {
            LoadNhomVatTu();
        }

        private async void LoadNhomVatTu()
        {
            var result = await NhomVatTuService.LayTatCaNhomVatTu();
            if (result != null && result.Status == Config.CODE_OK)
            {
                listNhomVatTu = (List<NhomVatTu>)result.Data;
                lvNhomVatTu.Items.Clear();
                foreach (NhomVatTu nhomVatTu in listNhomVatTu)
                {
                    ListViewItem listViewItem = new ListViewItem(nhomVatTu.Ma.ToString());
                    listViewItem.SubItems.Add(nhomVatTu.Ten);
                    listViewItem.SubItems[0].Tag = nhomVatTu.Id;

                    lvNhomVatTu.Items.Add(listViewItem);
                }
            }
        }

        private void ClearLayout()
        {
            txtMaNhomVatTu.Text = "";
            txtTenNhomVatTu.Text = "";
        }

        private void lvNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvNhomVatTu.SelectedItems.Count > 0)
            {
                ListViewItem lvItem = lvNhomVatTu.SelectedItems[0];
                txtMaNhomVatTu.Text = lvItem.SubItems[0].Text;
                txtIdNhomVatTu.Text = lvItem.SubItems[0].Tag.ToString();
                txtTenNhomVatTu.Text = lvItem.SubItems[1].Text;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaNhomVatTu.Text = UtilitiesService.AutoGenarateCode(Config.P_NVT);
            txtTenNhomVatTu.Text = "";
            currentNhomVatTu = new NhomVatTu();
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            ResponseData result = null;
            if (currentNhomVatTu != null) // Add new
            {
                currentNhomVatTu.Ma = txtTenNhomVatTu.Text;
                currentNhomVatTu.Ten = txtTenNhomVatTu.Text;

                result = await NhomVatTuService.ThemNhomVatTu(currentNhomVatTu);
            }
            else // Update
            {
                currentNhomVatTu = new NhomVatTu();
                currentNhomVatTu.Ma = txtMaNhomVatTu.Text;
                currentNhomVatTu.Ten = txtTenNhomVatTu.Text;
                currentNhomVatTu.Id = int.Parse(txtIdNhomVatTu.Text);
                result = await NhomVatTuService.CapNhatNhomVatTu(currentNhomVatTu);
            }

            if (result.Status == Config.CODE_OK)
            {
                MessageBoxEx.Show(result.Message, "Thông báo");
                ClearLayout();
                LoadNhomVatTu();
            }
            else if (result != null)
            {
                MessageBoxEx.Show(result.Message, "Thông báo");
            }
            else
            {
                MessageBoxEx.Show("Opps!!!", "Thông báo");
            }

            currentNhomVatTu = null;
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvNhomVatTu.SelectedItems.Count == 0)
            {
                MessageBoxEx.Show("Bạn phải chọn 1 nhà cung cấp để xóa!", "Thông báo");
            }
            else
            {
                int idNhomVatTu = txtIdNhomVatTu.Text == "" ? 0 : int.Parse(txtIdNhomVatTu.Text);
                if (idNhomVatTu == 0)
                {
                    MessageBoxEx.Show("Không thể xóa nhóm vật tư này!", "Thông báo");
                }
                else
                {
                    DialogResult res = MessageBoxEx.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này ?", "Thông báo", MessageBoxButtons.OKCancel);
                    if (res == DialogResult.OK)
                    {
                        var result = await NhomVatTuService.XoaNhomVatTu(idNhomVatTu);
                        if (result.Status == Config.CODE_OK)
                        {
                            MessageBoxEx.Show("Xóa nhóm vật tư thành công", "Thông báo");
                            LoadNhomVatTu();
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
                if (tabItem.Name == "tabNhomVatTu")
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
