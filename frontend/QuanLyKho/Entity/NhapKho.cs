using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NhapKho
    {
        public int Id { get; set; }
        public string Ma { get; set; }
        public DateTime NgayNhap { get; set; }
        public NhaCungCap NhaCungCap { get; set; }
        public NhanVien NhanVien { get; set; }
        public decimal TongTien { get; set; }
        public string GhiChu { get; set; }
        public Kho Kho { get; set; }
    }
}
