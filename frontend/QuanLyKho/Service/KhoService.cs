using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;

namespace Service
{
    public class KhoService
    {
        public static Task<ResponseData> LayTatCaKho()
        {
            return KhoRepository.Instance.LayTatCaKho();
        }

        public static Task<ResponseData> ThemMoiKho(Kho kho)
        {
            return KhoRepository.Instance.ThemMoiKho(kho);
        }
        public static Task<ResponseData> CapNhatKho(Kho kho)
        {
            return KhoRepository.Instance.CapNhatKho(kho);
        }

        public static Task<ResponseData> XoaKho(int idKho)
        {
            return KhoRepository.Instance.XoaKho(idKho);
        }

        public static Task<ResponseData> LayTatCaVatTuTheoKho(int khoId)
        {
            return KhoRepository.Instance.LayTatCaVatTuTheoKho(khoId);
        }
        public static Task<ResponseData> LayTatCaVatTuTheoKhoDgv(int khoId)
        {
            return KhoRepository.Instance.LayTatCaVatTuTheoKhoDgv(khoId);
        }
    }
}
