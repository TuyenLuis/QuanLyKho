using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NhanVien
    {
        public int Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string CMND { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public User User { get; set; }

        //public NhanVien (int id, string ma, string ten, bool gioiTinh, DateTime ngaySinh, string diaChi, string cmnd, string sdt, string email, DateTime ngayVaoLam)
        //{
        //    this.Id = id;
        //    this.Ma = Ma;
        //    this.Ten = ten;
        //    this.GioiTinh = gioiTinh;
        //    this.NgaySinh = ngaySinh;
        //    this.DiaChi = diaChi;
        //    this.CMND = cmnd;
        //    this.SDT = sdt;
        //    this.Email = email;
        //    this.NgayVaoLam = ngayVaoLam;
        //}

        //public NhanVien ()
        //{
        //    this.Id = 0;
        //}
    }
}
