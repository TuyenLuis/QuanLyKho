﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constant
{
    public class Config
    {
        // public static string HOST = "http://cs-manage-store.herokuapp.com";
        public static string HOST = "http://quanlykho-cs.herokuapp.com";
        // public static string HOST = "http://localhost:6969";
        public static int CODE_OK = 200;
        public static int CODE_UNAUTHORIZED = 401;
        public static int CODE_FORBIDDEN = 403;
        public static int CODE_NOTFOUND = 404;
        public static int CODE_SERVER_ERROR = 500;
        public static string ROLE_ADMIN = "Admin";
        public static string ROLE_EMPLOYEE = "Employee";
        public static string P_NHACC = "NCC";
        public static string P_NVT = "NVT";
        public static string P_VT = "VT";
        public static string P_NV = "NV";
        public static string P_KHO = "K";
    }

}
