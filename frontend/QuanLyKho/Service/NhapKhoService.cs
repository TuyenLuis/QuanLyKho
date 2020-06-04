using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;

namespace Service
{
    public class NhapKhoService
    {
        public static Task<ResponseData> LayTatCaPhieuNhapKho()
        {
            return NhapKhoRepository.Instance.LayTatCaPhieuNhapKho();
        }

        public static Task<ResponseData> LayChiTietPhieuNhapKho(int phieuNhapId)
        {
            return NhapKhoRepository.Instance.LayChiTietPhieuNhapKho(phieuNhapId);
        }

        public static Task<ResponseData> ThemMoiPhieuNhapKho(NhapKho phieuNhap, List<VatTuNhapXuat> listVatTu)
        {
            return NhapKhoRepository.Instance.ThemMoiPhieuNhapKho(phieuNhap, listVatTu);
        }

        public static Task<ResponseData> CapNhatPhieuNhapKho(NhapKho phieuNhap, List<VatTuNhapXuat> listVatTu)
        {
            return NhapKhoRepository.Instance.CapNhatPhieuNhapKho(phieuNhap, listVatTu);
        }
    }
}
