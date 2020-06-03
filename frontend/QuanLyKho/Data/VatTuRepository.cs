using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Constant;
using RestSharp;

namespace Data
{
    public class VatTuRepository
    {
        private static VatTuRepository _instance;
        public static VatTuRepository Instance
        {
            get
            {
                if (_instance == null) _instance = new VatTuRepository();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        public async Task<ResponseData> LayTatCaVatTu()
        {
            try
            {
                string url = string.Format("{0}/api/product/list-all-product", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.GET);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);

                var response = await client.ExecuteTaskAsync(request);
                var responseParse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = responseParse["data"];
                    List<VatTu> listVatTu = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VatTu>>(data.ToString());
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
                return new ResponseData()
                {
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponseData> ThemVatTu(VatTu vatTu)
        {
            try
            {
                string url = string.Format("{0}/api/product/add-new-product", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);
                request.AddJsonBody(new
                {
                    ma = vatTu.Ma,
                    ten = vatTu.Ten,
                    donGia = vatTu.DonGia,
                    donGiaNhap = vatTu.DonGiaNhap,
                    donViTinh = vatTu.DonViTinh,
                    idNhomVatTu = vatTu.NhomVatTu,
                    idNhaCungCap = vatTu.NhaCungCap
                });
                var response = await client.ExecuteTaskAsync(request);
                var responseParse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = responseParse["data"];
                    int productId = data["productId"];
                    return new ResponseData()
                    {
                        Status = Config.CODE_OK,
                        Data = productId,
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

        public async Task<ResponseData> CapNhatVatTu(VatTu vatTu)
        {
            try
            {
                string url = string.Format("{0}/api/product/update-product", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.PUT);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);
                request.AddJsonBody(new
                {
                    ma = vatTu.Ma,
                    ten = vatTu.Ten,
                    donGia = vatTu.DonGia,
                    donGiaNhap = vatTu.DonGiaNhap,
                    donViTinh = vatTu.DonViTinh,
                    idNhomVatTu = int.Parse(vatTu.IdNhomVatTu),
                    idNhaCungCap = int.Parse(vatTu.IdNhaCungCap),
                    productId = vatTu.Id,
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

        public async Task<ResponseData> XoaVatTu(int idVatTu)
        {
            try
            {
                string url = string.Format("{0}/api/product/delete-product", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.DELETE);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);
                request.AddJsonBody(new
                {
                    productId = idVatTu
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
    }
}
