using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infinitemoto.DTOs
{
    public class UserInfoDto
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int usertype { get; set; } //1: SuperAdmin, 2: Admin, 3: Regular User
        public int compid { get; set; }

        public bool isActive { get; set; } = true;

    }
}