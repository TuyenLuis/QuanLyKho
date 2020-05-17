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
    public class NhanVienRepository
    {
        private static NhanVienRepository _instance;
        public static NhanVienRepository Instance
        {
            get
            {
                if (_instance == null) _instance = new NhanVienRepository();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        public async Task<ResponseData> LayTatCaNhanVien()
        {
            try
            {
                string url = string.Format("{0}/api/employee/list-all-employee", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.GET);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);

                var response = await client.ExecuteTaskAsync(request);
                var responseParse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = responseParse["data"];
                    List<NhanVien> listNhanVien = Newtonsoft.Json.JsonConvert.DeserializeObject<List<NhanVien>>(data.ToString());
                    return new ResponseData()
                    {
                        Status = Config.CODE_OK,
                        Data = listNhanVien,
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
                }; ;
            }
        }

        public async Task<ResponseData> ThemNhanVien(NhanVien nhanVien)
        {
            try
            {
                string url = string.Format("{0}/api/employee/add-new-employee", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);
                request.AddJsonBody(new
                {
                    ma = nhanVien.Ma,
                    ten = nhanVien.Ten,
                    gioiTinh = nhanVien.GioiTinh,
                    ngaySinh = nhanVien.NgaySinh,
                    diaChi = nhanVien.DiaChi,
                    CMND = nhanVien.CMND,
                    SDT = nhanVien.SDT,
                    email = nhanVien.Email,
                    ngayVaoLam = nhanVien.NgayVaoLam,
                });
                var response = await client.ExecuteTaskAsync(request);
                var responseParse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = responseParse["data"];
                    int employeeId = data["employeeId"];
                    return new ResponseData()
                    {
                        Status = Config.CODE_OK,
                        Data = employeeId,
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

        public async Task<ResponseData> CapNhatNhanVien(NhanVien nhanVien)
        {
            try
            {
                string url = string.Format("{0}/api/employee/update-employee", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.PUT);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);
                request.AddJsonBody(new
                {
                    ma = nhanVien.Ma,
                    ten = nhanVien.Ten,
                    gioiTinh = nhanVien.GioiTinh,
                    ngaySinh = nhanVien.NgaySinh,
                    diaChi = nhanVien.DiaChi,
                    CMND = nhanVien.CMND,
                    SDT = nhanVien.SDT,
                    email = nhanVien.Email,
                    ngayVaoLam = nhanVien.NgayVaoLam,
                    employeeId = nhanVien.Id
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

        public async Task<ResponseData> XoaNhanVien(int idNhanVien)
        {
            try
            {
                string url = string.Format("{0}/api/employee/delete-employee", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.DELETE);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddHeader("x-access-token", UserResponse.AccessToken);
                request.AddJsonBody(new
                {
                    employeeId = idNhanVien

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
