using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;

namespace Service
{
    public class XuatKhoService
    {
        public static Task<ResponseData> LayTatCaPhieuXuatKho()
        {
            return XuatKhoRepository.Instance.LayTatCaPhieuXuatKho();
        }

        public static Task<ResponseData> LayChiTietPhieuXuatKho(int phieuXuatId)
        {
            return XuatKhoRepository.Instance.LayChiTietPhieuXuatKho(phieuXuatId);
        }
        public static Task<ResponseData> ThemMoiPhieuXuatKho(XuatKho phieuXuat, List<VatTuNhapXuat> listVatTu)
        {
            return XuatKhoRepository.Instance.ThemMoiPhieuXuatKho(phieuXuat, listVatTu);
        }

        public static Task<ResponseData> CapNhatPhieuXuatKho(XuatKho phieuXuat, List<VatTuNhapXuat> listVatTu)
        {
            return XuatKhoRepository.Instance.CapNhatPhieuXuatKho(phieuXuat, listVatTu);
        }
    }
}
