﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;
namespace Service
{
    public class UserService
    {
        public static Task<ResponseData> DangNhap(string username, string password)
        {
            return  UserRepository.Instance.DangNhap(username, password);
        }
    }
}
