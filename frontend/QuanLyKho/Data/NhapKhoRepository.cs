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
    public class NhapKhoRepository
    {
        private static NhapKhoRepository _instance;
        public static NhapKhoRepository Instance
        {
            get
            {
                if (_instance == null) _instance = new NhapKhoRepository();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        public async Task<ResponseData> LayTatCaPhieuNhapKho()
        {
            try
            {
                string url = string.Format("{0}/api/import/get-all", Config.HOST);
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
                    List<NhapKho> listNhapKho = new List<NhapKho>();
                    foreach (var item in listPhieuNhapJson)
                    {
                        NhapKho nhapKho = Newtonsoft.Json.JsonConvert.DeserializeObject<NhapKho>(item.ToString());
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
                        NhaCungCap nhaCungCap = new NhaCungCap()
                        {
                            Id = item["IdNhaCungCap"],
                            Ten = item["TenNhaCungCap"]
                        };
                        nhapKho.NhanVien = nhanVien;
                        nhapKho.Kho = kho;
                        nhapKho.NhaCungCap = nhaCungCap;
                        listNhapKho.Add(nhapKho);
                    }
                    return new ResponseData()
                    {
                        Status = Config.CODE_OK,
                        Data = listNhapKho,
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


        public async Task<ResponseData> LayChiTietPhieuNhapKho(int phieuNhapId)
        {
            try
            {
                string url = string.Format("{0}/api/import/get-detail/{1}", Config.HOST, phieuNhapId);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.GET);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);

                var response = await client.ExecuteTaskAsync(request);
                var responseParse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = responseParse["data"];
                    NhapKho nhapKho = Newtonsoft.Json.JsonConvert.DeserializeObject<NhapKho>(data.ToString());
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
                    NhaCungCap nhaCungCap = new NhaCungCap()
                    {
                        Id = data["IdNhaCungCap"],
                        Ten = data["TenNhaCungCap"]
                    };
                    nhapKho.NhanVien = nhanVien;
                    nhapKho.Kho = kho;
                    nhapKho.NhaCungCap = nhaCungCap;

                    var danhSachVatTuJson = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(data["DanhSachVatTu"].ToString());

                    List<ChiTietNhapKho> listChiTietNhapKho = new List<ChiTietNhapKho>();
                    foreach (var item in danhSachVatTuJson)
                    {
                        ChiTietNhapKho chiTiet = Newtonsoft.Json.JsonConvert.DeserializeObject<ChiTietNhapKho>(item.ToString());
                        VatTu vatTu = new VatTu()
                        {
                            Id = item["IdVatTu"],
                            Ten = item["TenVatTu"]
                        };
                        chiTiet.VatTu = vatTu;
                        chiTiet.NhapKho = nhapKho;
                        listChiTietNhapKho.Add(chiTiet);
                    }
                    return new ResponseData()
                    {
                        Status = Config.CODE_OK,
                        Data = listChiTietNhapKho,
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


        public async Task<ResponseData> ThemMoiPhieuNhapKho(NhapKho phieuNhap, List<VatTuNhapXuat> listVatTu)
        {
            try
            {
                string url = string.Format("{0}/api/import/add-new-receipt", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);
                request.AddJsonBody(new
                {
                    Ma = phieuNhap.Ma,
                    NgayNhap = phieuNhap.NgayNhap,
                    IdNhaCungCap = phieuNhap.NhaCungCap.Id,
                    IdNhanVien = phieuNhap.NhanVien.Id,
                    IdKho = phieuNhap.Kho.Id,
                    GhiChu = phieuNhap.GhiChu,
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

        public async Task<ResponseData> CapNhatPhieuNhapKho(NhapKho phieuNhap, List<VatTuNhapXuat> listVatTu)
        {
            try
            {
                string url = string.Format("{0}/api/import/update-receipt", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.PUT);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);
                request.AddJsonBody(new
                {
                    Ma = phieuNhap.Ma,
                    NgayNhap = phieuNhap.NgayNhap,
                    IdNhaCungCap = phieuNhap.NhaCungCap.Id,
                    IdNhanVien = phieuNhap.NhanVien.Id,
                    Id = phieuNhap.Id,
                    GhiChu = phieuNhap.GhiChu,
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
