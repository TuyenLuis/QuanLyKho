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
    public partial class ucXuatKho : UserControl
    {
        public ucXuatKho()
        {
            InitializeComponent();
        }

        public static int idPhieuXuat { get; set; }
        private List<XuatKho> listXuatKho = new List<XuatKho>();
        protected override void OnLoad(EventArgs e)
        {
            LoadListXuatKho();
        }

        private async void LoadListXuatKho()
        {
            var result = await XuatKhoService.LayTatCaPhieuXuatKho();
            if (result != null && result.Status == Config.CODE_OK)
            {
                listXuatKho = (List<XuatKho>)result.Data;
                lvXuatKho.Items.Clear();
                foreach (XuatKho xuatKho in listXuatKho)
                {
                    ListViewItem listViewItem = new ListViewItem(xuatKho.Ma.ToString());
                    listViewItem.SubItems.Add(xuatKho.NgayXuat.ToShortDateString());
                    listViewItem.SubItems.Add(xuatKho.Kho.Ten);
                    listViewItem.SubItems.Add(xuatKho.NhanVien.Ten);
                    listViewItem.SubItems.Add(xuatKho.DiaChi);
                    listViewItem.SubItems.Add(xuatKho.TongTien.ToString());
                    listViewItem.SubItems.Add(xuatKho.GhiChu);
                    listViewItem.SubItems[0].Tag = xuatKho.Id;
                    lvXuatKho.Items.Add(listViewItem);
                }
            }
        }

        private void Thoat_toolStripButton_Click(object sender, EventArgs e)
        {
            foreach (TabItem tabItem in frmMain.FrmMain.TabContainer.Tabs)
            {
                if (tabItem.Name == "tabXuatKho")
                {
                    frmMain.FrmMain.TabContainer.Tabs.Remove(tabItem);
                    frmMain.FrmMain.TabContainer.Controls.Remove(tabItem.AttachedControl);
                    frmMain.FrmMain.TabContainer.RecalcLayout();
                    return;
                }
            }
        }

        private void lvXuatKho_DoubleClick(object sender, EventArgs e)
        {
            if (lvXuatKho.SelectedItems.Count == 0)
            {
                return;
            }
            idPhieuXuat = int.Parse(lvXuatKho.SelectedItems[0].SubItems[0].Tag.ToString());
            Common.frmXuatKho = new frmXuatKho();
            Common.frmXuatKho.ShowDialog();
            LoadListXuatKho();
        }

        private void ThemMoi_toolStripButton_Click(object sender, EventArgs e)
        {
            idPhieuXuat = 0;
            Common.frmXuatKho = new frmXuatKho();
            Common.frmXuatKho.ShowDialog();
            LoadListXuatKho();
        }
    }
}
