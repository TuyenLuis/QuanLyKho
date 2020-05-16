using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ChiTietKho
    {
        public int Id { get; set; }
        public Kho Kho { get; set; }
        public VatTu VatTu { get; set; }
        public int SoLuong { get; set; }
    }
}
