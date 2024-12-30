using System;
using System.Collections.Generic;

namespace infinitemoto.Models
{
    public class Usertoken
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }

        public required string Token { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
