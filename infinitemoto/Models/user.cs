using System;
using System.Collections.Generic;
namespace infinitemoto.Models
{
    public partial  class User
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
