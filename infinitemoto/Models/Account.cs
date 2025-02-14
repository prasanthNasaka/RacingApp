using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Account
{
    public int AccId { get; set; }

    public string? AccName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public int? Status { get; set; }
}
