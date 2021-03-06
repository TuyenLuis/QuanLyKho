﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Constant;
using RestSharp;

namespace Data
{
    public class NhaCungCapRepository
    {
        private static NhaCungCapRepository _instance;
        public static NhaCungCapRepository Instance
        {
            get
            {
                if (_instance == null) _instance = new NhaCungCapRepository();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        public async Task<ResponseData> LayTatCaNhaCungCap()
        {
            try
            {
                string url = string.Format("{0}/api/provider/list-all-provider", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.GET);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);

                var response = await client.ExecuteTaskAsync(request);
                var responseParse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = responseParse["data"];
                    List<NhaCungCap> listNhaCungCap = Newtonsoft.Json.JsonConvert.DeserializeObject<List<NhaCungCap>>(data.ToString());
                    return new ResponseData()
                    {
                        Status = Config.CODE_OK,
                        Data = listNhaCungCap,
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

        public async Task<ResponseData> ThemNhaCungCap(NhaCungCap nhaCungCap)
        {
            try
            {
                string url = string.Format("{0}/api/provider/add-new-provider", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);
                request.AddJsonBody(new
                {
                    ma = nhaCungCap.Ma,
                    ten = nhaCungCap.Ten,
                    diaChi = nhaCungCap.DiaChi,
                    sdt = nhaCungCap.SDT,
                    email = nhaCungCap.Email,
                    nguoiDaiDien = nhaCungCap.NguoiDaiDien

                });
                var response = await client.ExecuteTaskAsync(request);
                var responseParse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = responseParse["data"];
                    int providerId = data["providerId"];
                    return new ResponseData()
                    {
                        Status = Config.CODE_OK,
                        Data = providerId,
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

        public async Task<ResponseData> CapNhatNhaCungCap(NhaCungCap nhaCungCap)
        {
            try
            {
                string url = string.Format("{0}/api/provider/update-provider", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.PUT);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);
                request.AddJsonBody(new
                {
                    ma = nhaCungCap.Ma,
                    ten = nhaCungCap.Ten,
                    diaChi = nhaCungCap.DiaChi,
                    sdt = nhaCungCap.SDT,
                    email = nhaCungCap.Email,
                    nguoiDaiDien = nhaCungCap.NguoiDaiDien,
                    providerId = nhaCungCap.Id

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

        public async Task<ResponseData> XoaNhaCungCap(int idNhaCungCap)
        {
            try
            {
                string url = string.Format("{0}/api/provider/delete-provider", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.DELETE);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);
                request.AddJsonBody(new
                {
                    providerId = idNhaCungCap

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

        public async Task<ResponseData> LayTatCaVatTuTheoNhaCungCap(int idNhaCungCap)
        {
            try
            {
                string url = string.Format("{0}/api/provider/list-product/{1}", Config.HOST, idNhaCungCap);
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
