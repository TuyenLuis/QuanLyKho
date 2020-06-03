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
    public class KhoRepository
    {
        private static KhoRepository _instance;
        public static KhoRepository Instance
        {
            get
            {
                if (_instance == null) _instance = new KhoRepository();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        public async Task<ResponseData> LayTatCaKho()
        {
            try
            {
                string url = string.Format("{0}/api/warehouse/list-all-warehouse", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.GET);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);

                var response = await client.ExecuteTaskAsync(request);
                var responseParse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = responseParse["data"];
                    var listKhoJson = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(data.ToString());
                    List<Kho> listKho = new List<Kho>();
                    foreach(var item in listKhoJson)
                    {
                        Kho kho = Newtonsoft.Json.JsonConvert.DeserializeObject<Kho>(item.ToString());
                        NhanVien quanLy = new NhanVien()
                        {
                            Id = item["IdQuanLy"],
                            Ten = item["TenQuanLy"]
                        };
                        kho.QuanLy = quanLy; 
                        listKho.Add(kho);
                    }
                    return new ResponseData()
                    {
                        Status = Config.CODE_OK,
                        Data = listKho,
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

        public async Task<ResponseData> ThemMoiKho(Kho kho)
        {
            try
            {
                string url = string.Format("{0}/api/warehouse/add-new-warehouse", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);
                request.AddJsonBody(new
                {
                    ma = kho.Ma,
                    ten = kho.Ten,
                    diaChi = kho.DiaChi,
                    sdt = kho.SDT,
                    ghiChu = kho.GhiChu,
                    idQuanLy = kho.QuanLy.Id

                });
                var response = await client.ExecuteTaskAsync(request);
                var responseParse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = responseParse["data"];
                    int warehouseId = data["warehouseId"];
                    return new ResponseData()
                    {
                        Status = Config.CODE_OK,
                        Data = warehouseId,
                        Message = responseParse["message"]
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

        public async Task<ResponseData> CapNhatKho(Kho kho)
        {
            try
            {
                string url = string.Format("{0}/api/warehouse/update-warehouse", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.PUT);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);
                request.AddJsonBody(new
                {
                    ma = kho.Ma,
                    ten = kho.Ten,
                    diaChi = kho.DiaChi,
                    sdt = kho.SDT,
                    ghiChu = kho.GhiChu,
                    idQuanLy = kho.QuanLy.Id,
                    warehouseId = kho.Id

                });
                var response = await client.ExecuteTaskAsync(request);
                var responseParse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return new ResponseData()
                    {
                        Status = Config.CODE_OK,
                        Data = null,
                        Message = responseParse["message"]
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

        public async Task<ResponseData> XoaKho(int idKho)
        {
            try
            {
                string url = string.Format("{0}/api/warehouse/delete-warehouse", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.DELETE);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);
                request.AddJsonBody(new
                {
                    warehouseId = idKho

                });
                var response = await client.ExecuteTaskAsync(request);
                var responseParse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return new ResponseData()
                    {
                        Status = Config.CODE_OK,
                        Data = null,
                        Message = responseParse["message"]
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

        public async Task<ResponseData> LayTatCaVatTuTheoKho(int khoId)
        {
            try
            {
                string url = string.Format("{0}/api/warehouse/list-product/{1}", Config.HOST, khoId);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.GET);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);

                var response = await client.ExecuteTaskAsync(request);
                var responseParse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = responseParse["data"];
                    var listVatTuJson = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(data.ToString());
                    List<VatTu> listVatTu = new List<VatTu>();
                    foreach (var item in listVatTuJson)
                    {
                        VatTu vatTu = Newtonsoft.Json.JsonConvert.DeserializeObject<VatTu>(item.ToString());
                        NhaCungCap nhaCungCap = new NhaCungCap()
                        {
                            Id = item["IdNhaCungCap"],
                            Ten = item["TenNhaCungCap"]
                        };
                        NhomVatTu nhomVatTu = new NhomVatTu()
                        {
                            Id = item["IdNhomVatTu"],
                            Ten = item["TenNhomVatTu"]
                        };
                        vatTu.NhomVatTu = nhomVatTu;
                        vatTu.NhaCungCap = nhaCungCap;
                        vatTu.SoLuongHienTai = item["SoLuong"];
                        listVatTu.Add(vatTu);
                    }
                    return new ResponseData()
                    {
                        Status = Config.CODE_OK,
                        Data = listVatTu,
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

        public async Task<ResponseData> LayTatCaVatTuTheoKhoDgv(int khoId)
        {
            try
            {
                string url = string.Format("{0}/api/warehouse/list-product/{1}", Config.HOST, khoId);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.GET);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);

                var response = await client.ExecuteTaskAsync(request);
                var responseParse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = responseParse["data"];
                    var listVatTuJson = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(data.ToString());
                    List<VatTuNhapXuat> listVatTu = new List<VatTuNhapXuat>();
                    foreach (var item in listVatTuJson)
                    {
                        VatTuNhapXuat vatTu = Newtonsoft.Json.JsonConvert.DeserializeObject<VatTuNhapXuat>(item.ToString());
                        vatTu.DonGia = item["DonGiaNhap"];
                        vatTu.SoLuongHienTai = item["SoLuong"];
                        listVatTu.Add(vatTu);
                    }
                    return new ResponseData()
                    {
                        Status = Config.CODE_OK,
                        Data = listVatTu,
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
