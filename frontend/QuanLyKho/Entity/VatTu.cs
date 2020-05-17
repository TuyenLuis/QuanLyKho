using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class VatTu
    {
        public int Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public decimal DonGia { get; set; }
        public decimal DonGiaNhap { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }
        public bool IsActive { get; set; }
        public string IdNhomVatTu { get; set; }
        public string TenNhomVatTu { get; set; }
        public string IdNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public NhaCungCap NhaCungCap { get; set; }
        public NhomVatTu NhomVatTu { get; set; }
    }
}
