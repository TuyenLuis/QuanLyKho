using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;

namespace Service
{
    public class VatTuService
    {
        public static Task<ResponseData> LayTatCaVatTu()
        {
            return VatTuRepository.Instance.LayTatCaVatTu();
        }

        public static Task<ResponseData> ThemVatTu(VatTu VatTu)
        {
            return VatTuRepository.Instance.ThemVatTu(VatTu);
        }
        public static Task<ResponseData> CapNhatVatTu(VatTu VatTu)
        {
            return VatTuRepository.Instance.CapNhatVatTu(VatTu);
        }

        public static Task<ResponseData> XoaVatTu(int idVatTu)
        {
            return VatTuRepository.Instance.XoaVatTu(idVatTu);
        }
    }
}
