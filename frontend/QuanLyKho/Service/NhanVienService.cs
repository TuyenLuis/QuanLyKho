using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;

namespace Service
{
    public class NhanVienService
    {
        public static Task<ResponseData> LayTatCaNhanVien()
        {
            return NhanVienRepository.Instance.LayTatCaNhanVien();
        }

        public static Task<ResponseData> ThemNhanVien(NhanVien NhanVien)
        {
            return NhanVienRepository.Instance.ThemNhanVien(NhanVien);
        }
        public static Task<ResponseData> CapNhatNhanVien(NhanVien NhanVien)
        {
            return NhanVienRepository.Instance.CapNhatNhanVien(NhanVien);
        }

        public static Task<ResponseData> XoaNhanVien(int idNhanVien)
        {
            return NhanVienRepository.Instance.XoaNhanVien(idNhanVien);
        }
    }
}
