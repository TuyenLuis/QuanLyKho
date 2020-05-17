using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;

namespace Service
{
    public class NhomVatTuService
    {
        public static Task<ResponseData> LayTatCaNhomVatTu()
        {
            return NhomVatTuRepository.Instance.LayTatCaNhomVatTu();
        }

        public static Task<ResponseData> ThemNhomVatTu(NhomVatTu NhomVatTu)
        {
            return NhomVatTuRepository.Instance.ThemNhomVatTu(NhomVatTu);
        }
        public static Task<ResponseData> CapNhatNhomVatTu(NhomVatTu NhomVatTu)
        {
            return NhomVatTuRepository.Instance.CapNhatNhomVatTu(NhomVatTu);
        }

        public static Task<ResponseData> XoaNhomVatTu(int idNhomVatTu)
        {
            return NhomVatTuRepository.Instance.XoaNhomVatTu(idNhomVatTu);
        }
    }
}
