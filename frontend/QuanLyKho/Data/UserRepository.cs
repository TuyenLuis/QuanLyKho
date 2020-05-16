using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Constant;
using Entity;

namespace Data
{
    public class UserRepository
    {
        private static UserRepository _instance;
        public static UserRepository Instance
        {
            get
            {
                if (_instance == null) _instance = new UserRepository();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        public async Task<ResponseData> DangNhap(string username, string password)
        {
            try
            {
                string url = string.Format("{0}/api/auth/login", Config.HOST);
                var client = new RestSharp.RestClient(url);
                var request = new RestSharp.RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.AddJsonBody(new
                {
                    username = username,
                    password = password

                });
                var response = await client.ExecuteTaskAsync(request);
                var responseParse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    UserResponse.AccessToken = responseParse["accessToken"];
                    UserResponse.RefreshToken = responseParse["refreshToken"];
                    var employeeInfo = responseParse["employee"];
                    UserResponse.Roles = new Roles()
                    {
                        Name = employeeInfo["RoleName"]
                    };
                    UserResponse.Id = employeeInfo["UserId"];
                    UserResponse.Username = employeeInfo["Username"];
                    UserResponse.NhanVien = new NhanVien()
                    {
                        Id = employeeInfo["NhanVienId"],
                        Ma = employeeInfo["MaNhanVien"],
                        Ten = employeeInfo["TenNhanVien"],
                        GioiTinh = employeeInfo["GioiTinh"],
                        NgaySinh = employeeInfo["NgaySinh"],
                        DiaChi = employeeInfo["DiaChi"],
                        SDT = employeeInfo["SDT"],
                        CMND = employeeInfo["CMND"],
                        Email = employeeInfo["Email"],
                        NgayVaoLam = employeeInfo["NgayVaoLam"]
                    };

                    return new ResponseData()
                    {
                        Status = Config.CODE_OK,
                        Data = true,
                        Message = ""
                    };
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return new ResponseData()
                    {
                        Status = Config.CODE_UNAUTHORIZED,
                        Data = true,
                        Message = responseParse["message"]
                    };
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    return new ResponseData()
                    {
                        Status = Config.CODE_SERVER_ERROR,
                        Data = false,
                        Message = responseParse["message"]
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
