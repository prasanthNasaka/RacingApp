using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Usertoken
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Token { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string Role { get; set; } = null!;
}
