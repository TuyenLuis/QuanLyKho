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
    public partial class ucNhapKho : UserControl
    {
        public ucNhapKho()
        {
            InitializeComponent();
        }

        public static int idPhieuNhap { get; set; }
        private List<NhapKho> listNhapKho = new List<NhapKho>();
        protected override void OnLoad(EventArgs e)
        {
            LoadListNhapKho();
        }

        private async void LoadListNhapKho()
        {
            var result = await NhapKhoService.LayTatCaPhieuNhapKho();
            if (result != null && result.Status == Config.CODE_OK)
            {
                listNhapKho = (List<NhapKho>)result.Data;
                lvNhapKho.Items.Clear();
                foreach (NhapKho nhapKho in listNhapKho)
                {
                    ListViewItem listViewItem = new ListViewItem(nhapKho.Ma.ToString());
                    listViewItem.SubItems.Add(nhapKho.NgayNhap.ToShortDateString());
                    listViewItem.SubItems.Add(nhapKho.Kho.Ten);
                    listViewItem.SubItems.Add(nhapKho.NhanVien.Ten);
                    listViewItem.SubItems.Add(nhapKho.NhaCungCap.Ten);
                    listViewItem.SubItems.Add(nhapKho.TongTien.ToString());
                    listViewItem.SubItems.Add(nhapKho.GhiChu);
                    listViewItem.SubItems[0].Tag = nhapKho.Id;
                    lvNhapKho.Items.Add(listViewItem);
                }
            }
        }

        private void Thoat_toolStripButton_Click(object sender, EventArgs e)
        {
            foreach (TabItem tabItem in frmMain.FrmMain.TabContainer.Tabs)
            {
                if (tabItem.Name == "tabNhapKho")
                {
                    frmMain.FrmMain.TabContainer.Tabs.Remove(tabItem);
                    frmMain.FrmMain.TabContainer.Controls.Remove(tabItem.AttachedControl);
                    frmMain.FrmMain.TabContainer.RecalcLayout();
                    return;
                }
            }
        }

        private void lvNhapKho_DoubleClick(object sender, EventArgs e)
        {
            if (lvNhapKho.SelectedItems.Count == 0)
            {
                return;
            }
            idPhieuNhap = int.Parse(lvNhapKho.SelectedItems[0].SubItems[0].Tag.ToString());
            Common.frmNhapKho = new frmNhapKho();
            Common.frmNhapKho.ShowDialog();
            LoadListNhapKho();
        }
    }
}
