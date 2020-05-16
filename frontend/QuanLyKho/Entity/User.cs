using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        public static int Id { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static Roles Roles { get; set; }
        public static NhanVien NhanVien { get; set; }
    }

    public class UserResponse : User
    {
        public static string AccessToken { get; set; }
        public static string RefreshToken { get; set; }
    }
}
