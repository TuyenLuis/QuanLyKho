using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ChuyenKho
    {
        public int Id { get; set; }
        public string Ma { get; set; }
        public DateTime NgayChuyen { get; set; }
        public NhanVien NhanVien { get; set; }
        public decimal TongTien { get; set; }
        public string GhiChu { get; set; }
        public Kho KhoMoi { get; set; }
        public Kho KhoCu { get; set; }
    }
}
