using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infinitemoto.LookUps;

namespace infinitemoto.DTOs
{
    public class UserInfoDto
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public AuthenticationRoles usertype { get; set; }
        public int compid { get; set; }

        public bool isActive { get; set; } = true;

    }
}