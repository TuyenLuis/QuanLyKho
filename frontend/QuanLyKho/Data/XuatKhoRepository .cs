using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constant;
using Entity;
using RestSharp;

namespace Data
{
    public class XuatKhoRepository
    {
        private static XuatKhoRepository _instance;
        public static XuatKhoRepository Instance
        {
            get
            {
                if (_instance == null) _instance = new XuatKhoRepository();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        public async Task<ResponseData> LayTatCaPhieuXuatKho()
        {
            try
            {
                string url = string.Format("{0}/api/export/get-all", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.GET);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);

                var response = await client.ExecuteTaskAsync(request);
                var responseParse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = responseParse["data"];
                    var listPhieuNhapJson = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(data.ToString());
                    List<XuatKho> listXuatKho = new List<XuatKho>();
                    foreach (var item in listPhieuNhapJson)
                    {
                        XuatKho xuatKho = Newtonsoft.Json.JsonConvert.DeserializeObject<XuatKho>(item.ToString());
                        Kho kho = new Kho()
                        {
                            Id = item["IdKho"],
                            Ten = item["TenKho"]
                        };
                        NhanVien nhanVien = new NhanVien()
                        {
                            Id = item["IdNhanVien"],
                            Ten = item["TenNhanVien"]
                        };
                        xuatKho.NhanVien = nhanVien;
                        xuatKho.Kho = kho;
                        listXuatKho.Add(xuatKho);
                    }
                    return new ResponseData()
                    {
                        Status = Config.CODE_OK,
                        Data = listXuatKho,
                        Message = ""
                    };
                }
                else
                {
                    return Util.GenerateErrorResponse(response, responseParse);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<ResponseData> LayChiTietPhieuXuatKho(int phieuXuatId)
        {
            try
            {
                string url = string.Format("{0}/api/export/get-detail/{1}", Config.HOST, phieuXuatId);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.GET);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);

                var response = await client.ExecuteTaskAsync(request);
                var responseParse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = responseParse["data"];
                    XuatKho xuatKho = Newtonsoft.Json.JsonConvert.DeserializeObject<XuatKho>(data.ToString());
                    Kho kho = new Kho()
                    {
                        Id = data["IdKho"],
                        Ten = data["TenKho"]
                    };
                    NhanVien nhanVien = new NhanVien()
                    {
                        Id = data["IdNhanVien"],
                        Ten = data["TenNhanVien"]
                    };
                    xuatKho.NhanVien = nhanVien;
                    xuatKho.Kho = kho;

                    var danhSachVatTuJson = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(data["DanhSachVatTu"].ToString());

                    List<ChiTietXuatKho> listChiTietXuatKho = new List<ChiTietXuatKho>();
                    foreach (var item in danhSachVatTuJson)
                    {
                        ChiTietXuatKho chiTiet = Newtonsoft.Json.JsonConvert.DeserializeObject<ChiTietXuatKho>(item.ToString());
                        VatTu vatTu = new VatTu()
                        {
                            Id = item["IdVatTu"],
                            Ten = item["TenVatTu"]
                        };
                        chiTiet.VatTu = vatTu;
                        chiTiet.XuatKho = xuatKho;
                        listChiTietXuatKho.Add(chiTiet);
                    }
                    return new ResponseData()
                    {
                        Status = Config.CODE_OK,
                        Data = listChiTietXuatKho,
                        Message = ""
                    };
                }
                else
                {
                    return Util.GenerateErrorResponse(response, responseParse);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<ResponseData> ThemMoiPhieuXuatKho(XuatKho phieuXuat, List<VatTuNhapXuat> listVatTu)
        {
            try
            {
                string url = string.Format("{0}/api/export/add-new-receipt", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);
                request.AddJsonBody(new
                {
                    Ma = phieuXuat.Ma,
                    NgayXuat = phieuXuat.NgayXuat,
                    DiaChi = phieuXuat.DiaChi,
                    IdNhanVien = phieuXuat.NhanVien.Id,
                    IdKho = phieuXuat.Kho.Id,
                    GhiChu = phieuXuat.GhiChu,
                    listProduct = listVatTu.Select(x => new { x.Id, x.SoLuong, x.GhiChu }).ToList()
                });

                var response = await client.ExecuteTaskAsync(request);
                var responseParse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = responseParse["data"];
                    InforXuatKho inforXuatKho = Newtonsoft.Json.JsonConvert.DeserializeObject<InforXuatKho>(data.ToString());
                    return new ResponseData()
                    {
                        Status = Config.CODE_OK,
                        Data = inforXuatKho,
                        Message = ""
                    };
                }
                else
                {
                    return Util.GenerateErrorResponse(response, responseParse);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ResponseData> CapNhatPhieuXuatKho(XuatKho phieuXuat, List<VatTuNhapXuat> listVatTu)
        {
            try
            {
                string url = string.Format("{0}/api/export/update-receipt", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.PUT);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);
                request.AddJsonBody(new
                {
                    Ma = phieuXuat.Ma,
                    NgayXuat = phieuXuat.NgayXuat,
                    DiaChi = phieuXuat.DiaChi,
                    IdNhanVien = phieuXuat.NhanVien.Id,
                    IdKho = phieuXuat.Kho.Id,
                    Id = phieuXuat.Id,
                    GhiChu = phieuXuat.GhiChu,
                    listProduct = listVatTu.Select(x => new { x.Id, x.SoLuong, x.GhiChu }).ToList()
                });

                var response = await client.ExecuteTaskAsync(request);
                var responseParse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = responseParse["data"];
                    var totalPrice = (decimal)data["totalPrice"];
                    return new ResponseData()
                    {
                        Status = Config.CODE_OK,
                        Data = totalPrice,
                        Message = ""
                    };
                }
                else
                {
                    return Util.GenerateErrorResponse(response, responseParse);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
