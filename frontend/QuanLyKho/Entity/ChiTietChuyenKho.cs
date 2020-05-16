using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ChiTietChuyenKho
    {
        public int Id { get; set; }
        public ChuyenKho ChuyenKho { get; set; }
        public VatTu VatTu { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public string LyDo { get; set; }
    }
}
