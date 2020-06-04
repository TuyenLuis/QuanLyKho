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
using System.Threading;

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
        private bool isLoadingNhaCungCapDone = false;

        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadKho();
            LoadNhaCungCap();
            Thread.Sleep(100);
            if (ucNhapKho.idPhieuNhap != 0)
            {
                LoadChiTietPhieuNhap(ucNhapKho.idPhieuNhap);
            }
            DisabledControl();
        }

        private void DisabledControl()
        {
            if (ucNhapKho.idPhieuNhap != 0)
            {
                txtMa.Enabled = false;
                cboNhaCungCap.Enabled = false;
            }
            else
            {
                txtMa.Enabled = false;
                txtMa.Text = UtilitiesService.AutoGenarateCode("PN");
            }
        }

        private async void LoadDanhSachVatTu(int idNhaCungCap)
        {
            var result = await NhaCungCapService.LayTatCaVatTuTheoNhaCungCap(idNhaCungCap);
            if (result != null && result.Status == Config.CODE_OK)
            {
                listVatTuTheoKho = (List<VatTuNhapXuat>)result.Data;
                foreach (var item in listVatTuTheoKho)
                {
                    var vatTu = listChiTietNhapKho.SingleOrDefault(x => x.VatTu.Id == item.Id);
                    if (vatTu == null)
                    {
                        item.SoLuong = 0;
                        item.GhiChu = "";
                    }
                    else
                    {
                        item.SoLuong = vatTu.SoLuong;
                        item.GhiChu = vatTu.GhiChu;
                    }
                }
            }

            dgvVatTu.DataSource = typeof(List<VatTuNhapXuat>);
            dgvVatTu.DataSource = listVatTuTheoKho;

            EditDataGridView(listVatTuTheoKho);
        }

        private void EditDataGridView(List<VatTuNhapXuat> listVatTu)
        {
            if (listVatTu != null)
            {
                dgvVatTu.Columns["Id"].Visible = false;
                dgvVatTu.Columns["Ma"].HeaderText = "Mã";
                dgvVatTu.Columns["Ten"].HeaderText = "Tên";
                dgvVatTu.Columns["DonViTinh"].HeaderText = "ĐVT";
                dgvVatTu.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvVatTu.Columns["SoLuongHienTai"].HeaderText = "Số lượng tồn";
                dgvVatTu.Columns["SoLuong"].HeaderText = "Số lượng nhập";
                dgvVatTu.Columns["GhiChu"].HeaderText = "Ghi chú";
            }
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
                isLoadingNhaCungCapDone = true;
                if (ucNhapKho.idPhieuNhap == 0)
                {
                    LoadDanhSachVatTu(listNhaCungCap[0].Id);
                    dtpNgayNhap.Value = DateTime.Now;
                }
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

        private async void LoadChiTietPhieuNhap(int idPhieuNhap)
        {
            var result = await NhapKhoService.LayChiTietPhieuNhapKho(idPhieuNhap);
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

                LoadDanhSachVatTu(nhapKho.NhaCungCap.Id);
            }
        }

        private void dgvVatTu_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var indexCol = e.ColumnIndex;
            var indexRow = e.RowIndex;
            if (indexCol != 6 && indexCol != 7)
            {
                MessageBoxEx.Show("Bạn chỉ có thể thay đổi số lượng nhập và ghi chú", "Thông báo");
                dgvVatTu.Rows[indexRow].Cells[indexCol].Value = OldValue;
            }
            else
            {
                try
                {
                    int soLuongNhap = 0;         
                    if (int.TryParse(dgvVatTu.Rows[indexRow].Cells["SoLuong"].Value.ToString(), out soLuongNhap))
                    {
                        if (soLuongNhap < 0)
                        {
                            MessageBoxEx.Show("Dữ liệu nhập vào bị sai. Xin kiểm tra lại!!", "Thông báo");
                            dgvVatTu.Rows[indexRow].Cells[indexCol].Value = OldValue;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show("Bạn nhập sai định dạng dữ liệu", "Thông báo");
                }
            }
        }

        public object OldValue { get; set; }
        private void dgvVatTu_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var indexCol = e.ColumnIndex;
            var indexRow = e.RowIndex;
            OldValue = dgvVatTu.Rows[indexRow].Cells[indexCol].Value;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            NhapKho nhapKho = new NhapKho()
            {
                Ma = txtMa.Text,
                NgayNhap = dtpNgayNhap.Value,
                GhiChu = txtGhiChu.Text,
                NhanVien = new NhanVien()
                {
                    Id = (int)cboNhanVien.SelectedValue
                },
                NhaCungCap = new NhaCungCap()
                {
                    Id = (int)cboNhaCungCap.SelectedValue
                },
                Kho = new Kho()
                {
                    Id = (int)cboKho.SelectedValue
                },
                Id = ucNhapKho.idPhieuNhap
            };
            List<VatTuNhapXuat> listVatTu = new List<VatTuNhapXuat>();
            for (int i = 0; i < dgvVatTu.Rows.Count; i++)
            {
                var dr = dgvVatTu.Rows[i];
                VatTuNhapXuat vatTu = new VatTuNhapXuat()
                {
                    Id = (int)dr.Cells["Id"].Value,
                    GhiChu = (string)dr.Cells["GhiChu"].Value,
                    SoLuong = (int)dr.Cells["SoLuong"].Value
                };
                if (vatTu.SoLuong > 0)
                {
                    listVatTu.Add(vatTu);
                }
            }

            if (nhapKho.Id != 0)
            {
                // Call update
                var result = await NhapKhoService.CapNhatPhieuNhapKho(nhapKho, listVatTu);
                if (result != null && result.Status == Config.CODE_OK)
                {
                    MessageBoxEx.Show("Cập nhật phiếu nhập kho thành công", "Thông báo");
                    txtTongTien.Text = ((decimal)result.Data).ToString();

                    LoadChiTietPhieuNhap(ucNhapKho.idPhieuNhap);
                    LoadDanhSachVatTu(nhapKho.NhaCungCap.Id);
                }
                else
                {
                    MessageBoxEx.Show("Cập nhật phiếu nhập kho thất bại", "Thông báo");
                    ChiTietNhapKho chiTiet = listChiTietNhapKho.SingleOrDefault(x => x.NhapKho.Id == ucNhapKho.idPhieuNhap);
                    if (chiTiet != null)
                    {
                        nhapKho = chiTiet.NhapKho;
                        txtMa.Text = nhapKho.Ma;
                        txtGhiChu.Text = nhapKho.GhiChu;
                        txtTongTien.Text = nhapKho.TongTien.ToString();
                        dtpNgayNhap.Value = nhapKho.NgayNhap;
                        cboKho.Text = nhapKho.Kho.Ten;
                        cboNhaCungCap.Text = nhapKho.NhaCungCap.Ten;
                        cboNhanVien.Text = nhapKho.NhanVien.Ten;
                        LoadDanhSachVatTu(nhapKho.NhaCungCap.Id);
                    }
                }
            }
            else
            {
                // Call add new
                var result = await NhapKhoService.ThemMoiPhieuNhapKho(nhapKho, listVatTu);
                if (result != null && result.Status == Config.CODE_OK)
                {
                    MessageBoxEx.Show("Thêm mới phiếu nhập kho thành công", "Thông báo");
                    InforNhapKho infor = (InforNhapKho)result.Data;
                    txtTongTien.Text = ((decimal)infor.totalPrice).ToString();
                    LoadChiTietPhieuNhap(infor.receiptId);
                    LoadDanhSachVatTu(nhapKho.NhaCungCap.Id);
                    ucNhapKho.idPhieuNhap = infor.receiptId;
                }
                else
                {
                    MessageBoxEx.Show("Thêm mới phiếu nhập kho thất bại", "Thông báo");
                    LoadDanhSachVatTu(nhapKho.NhaCungCap.Id);
                }
            }
        }

        private void cboNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ucNhapKho.idPhieuNhap == 0 && isLoadingNhaCungCapDone)
            {
                LoadDanhSachVatTu((int)cboNhaCungCap.SelectedValue);
            }
        }
    }
}
