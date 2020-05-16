using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ChiTietXuatKho
    {
        public int Id { get; set; }
        public XuatKho XuatKho { get; set; }
        public VatTu VatTu { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public string GhiChu { get; set; }
    }
}
