using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Kho
    {
        public int Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public NhanVien QuanLy { get; set; }
    }
}
