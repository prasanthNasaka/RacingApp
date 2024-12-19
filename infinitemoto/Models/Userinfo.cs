using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Userinfo
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Usertype { get; set; }

    public int Compid { get; set; }
}
