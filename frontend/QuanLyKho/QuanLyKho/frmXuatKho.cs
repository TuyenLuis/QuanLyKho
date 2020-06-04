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
    public partial class frmXuatKho : Office2007Form
    {
        public frmXuatKho()
        {
            InitializeComponent();
        }

        List<ChiTietXuatKho> listChiTietXuatKho = new List<ChiTietXuatKho>();
        XuatKho xuatKho = new XuatKho();
        List<NhanVien> listNhanVien = new List<NhanVien>();
        List<Kho> listKho = new List<Kho>();
        List<VatTuNhapXuat> listVatTuTheoKho = new List<VatTuNhapXuat>();
        private bool isLoadingKhoDone = false;
        int idPhieuXuat = ucXuatKho.idPhieuXuat;
        private void frmXuatKho_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadKho();
            if (ucXuatKho.idPhieuXuat != 0)
            {
                LoadChiTietPhieuXuat(idPhieuXuat);
            }
            DisabledControl();
        }

        private void DisabledControl()
        {
            if (ucXuatKho.idPhieuXuat != 0)
            {
                txtMa.Enabled = false;
                cboKho.Enabled = false;
            }
            else
            {
                txtMa.Enabled = false;
                txtMa.Text = UtilitiesService.AutoGenarateCode("PX");
            }
        }

        private async void LoadDanhSachVatTu(int Id)
        {
            var result = await KhoService.LayTatCaVatTuTheoKhoDgv(Id);
            if (result != null && result.Status == Config.CODE_OK)
            {
                listVatTuTheoKho = (List<VatTuNhapXuat>)result.Data;
                foreach (var item in listVatTuTheoKho)
                {
                    var vatTu = listChiTietXuatKho.SingleOrDefault(x => x.VatTu.Id == item.Id);
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
                dgvVatTu.Columns["SoLuong"].HeaderText = "Số lượng xuất";
                dgvVatTu.Columns["GhiChu"].HeaderText = "Ghi chú";
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
                isLoadingKhoDone = true;
                isLoadingKhoDone = true;
                if (ucXuatKho.idPhieuXuat == 0)
                {
                    LoadDanhSachVatTu(listKho[0].Id);
                    dtpNgayNhap.Value = DateTime.Now;
                }
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

        private async void LoadChiTietPhieuXuat(int Id)
        {
            var result = await XuatKhoService.LayChiTietPhieuXuatKho(Id);
            if (result != null && result.Status == Config.CODE_OK)
            {
                listChiTietXuatKho = (List<ChiTietXuatKho>)result.Data;
                xuatKho = listChiTietXuatKho[0].XuatKho;
                txtMa.Text = xuatKho.Ma;
                txtGhiChu.Text = xuatKho.GhiChu;
                txtTongTien.Text = xuatKho.TongTien.ToString();
                dtpNgayNhap.Value = xuatKho.NgayXuat;
                cboKho.Text = xuatKho.Kho.Ten;
                txtDiaChi.Text = xuatKho.DiaChi;
                cboNhanVien.Text = xuatKho.NhanVien.Ten;

                LoadDanhSachVatTu(xuatKho.Kho.Id);
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
                    int soLuongXuat = 0;
                    if (int.TryParse(dgvVatTu.Rows[indexRow].Cells["SoLuong"].Value.ToString(), out soLuongXuat))
                    {
                        if (soLuongXuat < 0)
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
            XuatKho xuatKho = new XuatKho()
            {
                Ma = txtMa.Text,
                NgayXuat = dtpNgayNhap.Value,
                GhiChu = txtGhiChu.Text,
                DiaChi = txtDiaChi.Text,
                NhanVien = new NhanVien()
                {
                    Id = (int)cboNhanVien.SelectedValue
                },
                Kho = new Kho()
                {
                    Id = (int)cboKho.SelectedValue
                },
                Id = idPhieuXuat,
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

            if (xuatKho.Id != 0)
            {
                // Call update
                var result = await XuatKhoService.CapNhatPhieuXuatKho(xuatKho, listVatTu);
                if (result != null && result.Status == Config.CODE_OK)
                {
                    MessageBoxEx.Show("Cập nhật phiếu xuất kho thành công", "Thông báo");
                    txtTongTien.Text = ((decimal)result.Data).ToString();
                    LoadChiTietPhieuXuat(idPhieuXuat);
                    LoadDanhSachVatTu(xuatKho.Kho.Id);
                }
                else
                {
                    MessageBoxEx.Show("Cập nhật phiếu xuất kho thất bại", "Thông báo");
                    ChiTietXuatKho chiTiet = listChiTietXuatKho.SingleOrDefault(x => x.XuatKho.Id == ucXuatKho.idPhieuXuat);
                    if (chiTiet != null)
                    {
                        xuatKho = chiTiet.XuatKho;
                        txtMa.Text = xuatKho.Ma;
                        txtGhiChu.Text = xuatKho.GhiChu;
                        txtTongTien.Text = xuatKho.TongTien.ToString();
                        dtpNgayNhap.Value = xuatKho.NgayXuat;
                        cboKho.Text = xuatKho.Kho.Ten;
                        txtDiaChi.Text = xuatKho.DiaChi;
                        cboNhanVien.Text = xuatKho.NhanVien.Ten;
                        LoadDanhSachVatTu(xuatKho.Kho.Id);
                    }
                }
            }
            else
            {
                // Caal add new
                var result = await XuatKhoService.ThemMoiPhieuXuatKho(xuatKho, listVatTu);
                if (result != null && result.Status == Config.CODE_OK)
                {
                    MessageBoxEx.Show("Thêm mới phiếu xuất kho thành công", "Thông báo");
                    InforXuatKho infor = (InforXuatKho)result.Data;
                    txtTongTien.Text = ((decimal)infor.totalPrice).ToString();
                    LoadChiTietPhieuXuat(infor.receiptId);
                    LoadDanhSachVatTu(xuatKho.Kho.Id);
                    idPhieuXuat = infor.receiptId;
                }
                else
                {
                    MessageBoxEx.Show("Thêm mới phiếu xuất kho thất bại", "Thông báo");
                    LoadDanhSachVatTu(xuatKho.Kho.Id);
                }
            }
        }

        private void cboKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ucXuatKho.idPhieuXuat == 0 && isLoadingKhoDone == true)
            {
                LoadDanhSachVatTu((int)cboKho.SelectedValue);
            }
        }
    }
}
