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
using Entity;
using Service;
using Constant;

namespace QuanLyKho
{
    public partial class frmNhapKho : Office2007Form
    {
        public frmNhapKho()
        {
            InitializeComponent();
        }

        List<ChiTietNhapKho> listChiTietNhapKho = new List<ChiTietNhapKho>();
        NhapKho nhapKho = new NhapKho();
        List<NhanVien> listNhanVien = new List<NhanVien>();
        List<Kho> listKho = new List<Kho>();
        List<NhaCungCap> listNhaCungCap = new List<NhaCungCap>();
        List<VatTuNhapXuat> listVatTuTheoKho = new List<VatTuNhapXuat>();

        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadKho();
            LoadNhaCungCap();
            LoadChiTietPhieuNhap();
        }

        private async void LoadDanhSachVatTu()
        {
            var result = await NhaCungCapService.LayTatCaVatTuTheoNhaCungCap(nhapKho.NhaCungCap.Id);
            if (result != null && result.Status == Config.CODE_OK)
            {
                listVatTuTheoKho = (List<VatTuNhapXuat>)result.Data;
                foreach (var item in listVatTuTheoKho)
                {
                    var vatTu = listChiTietNhapKho.SingleOrDefault(x => x.Id == item.Id);
                    if (vatTu == null)
                    {
                        item.SoLuongNhapXuat = 0;
                    }
                    else
                    {
                        item.SoLuongNhapXuat = vatTu.SoLuong;
                    }
                }
            }

            dgvVatTu.DataSource = typeof(List<VatTu>);
            dgvVatTu.DataSource = listVatTuTheoKho;
        }

        private async void LoadNhaCungCap()
        {
            var result = await NhaCungCapService.LayTatCaNhaCungCap();
            if (result != null && result.Status == Config.CODE_OK)
            {
                listNhaCungCap = (List<NhaCungCap>)result.Data;
                cboNhaCungCap.DataSource = listNhaCungCap;
                cboNhaCungCap.DisplayMember = "Ten";
                cboNhaCungCap.ValueMember = "Id";
            }
        }

        private async void LoadKho()
        {
            var result = await KhoService.LayTatCaKho();
            if (result != null && result.Status == Config.CODE_OK)
            {
                listKho = (List<Kho>)result.Data;
                cboKho.DataSource = listKho;
                cboKho.DisplayMember = "Ten";
                cboKho.ValueMember = "Id";
            }
        }

        private async void LoadNhanVien()
        {
            var result = await NhanVienService.LayTatCaNhanVien();
            if (result != null && result.Status == Config.CODE_OK)
            {
                listNhanVien = (List<NhanVien>)result.Data;
                cboNhanVien.DataSource = listNhanVien;
                cboNhanVien.DisplayMember = "Ten";
                cboNhanVien.ValueMember = "Id";
            }
        }

        private async void LoadChiTietPhieuNhap()
        {
            var result = await NhapKhoService.LayChiTietPhieuNhapKho(ucNhapKho.idPhieuNhap);
            if (result != null && result.Status == Config.CODE_OK)
            {
                listChiTietNhapKho = (List<ChiTietNhapKho>)result.Data;
                nhapKho = listChiTietNhapKho[0].NhapKho;
                txtMa.Text = nhapKho.Ma;
                txtGhiChu.Text = nhapKho.GhiChu;
                txtTongTien.Text = nhapKho.TongTien.ToString();
                dtpNgayNhap.Value = nhapKho.NgayNhap;
                cboKho.Text = nhapKho.Kho.Ten;
                cboNhaCungCap.Text = nhapKho.NhaCungCap.Ten;
                cboNhanVien.Text = nhapKho.NhanVien.Ten;

                LoadDanhSachVatTu();
            }
        }
    }
}
