using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;

namespace Service
{
    public class NhaCungCapService
    {
        public static Task<ResponseData> LayTatCaNhaCungCap()
        {
            return NhaCungCapRepository.Instance.LayTatCaNhaCungCap();
        }

        public static Task<ResponseData> ThemNhaCungCap(NhaCungCap nhaCungCap)
        {
            return NhaCungCapRepository.Instance.ThemNhaCungCap(nhaCungCap);
        }
        public static Task<ResponseData> CapNhatNhaCungCap(NhaCungCap nhaCungCap)
        {
            return NhaCungCapRepository.Instance.CapNhatNhaCungCap(nhaCungCap);
        }

        public static Task<ResponseData> XoaNhaCungCap(int idNhaCungCap)
        {
            return NhaCungCapRepository.Instance.XoaNhaCungCap(idNhaCungCap);
        }

        public static Task<ResponseData> LayTatCaVatTuTheoNhaCungCap(int idNhaCungCap)
        {
            return NhaCungCapRepository.Instance.LayTatCaVatTuTheoNhaCungCap(idNhaCungCap);
        }
    }
}
