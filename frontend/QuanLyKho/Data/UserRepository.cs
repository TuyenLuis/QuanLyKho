using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using RestSharp;
using RestSharp.Authenticators;
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

        public async Task<Dictionary<bool, int>> DangNhap(string username, string password)
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
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseParse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
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

                    return new Dictionary<bool, int>() { { true, Config.CODE_OK } };
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return new Dictionary<bool, int>() { { true, Config.CODE_UNAUTHORIZED } };
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    return new Dictionary<bool, int>() { { false, Config.CODE_SERVER_ERROR } };
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
