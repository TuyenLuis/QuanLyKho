using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class XuatKho
    {
        public int Id { get; set; }
        public string Ma { get; set; }
        public DateTime NgayXuat { get; set; }
        public NhanVien NhanVien { get; set; }
        public string DiaChi { get; set; }
        public decimal TongTien { get; set; }
        public string GhiChu { get; set; }
        public Kho Kho { get; set; }
    }

    public class InforXuatKho
    {
        public int receiptId { get; set; }
        public decimal totalPrice { get; set; }
    }
}
