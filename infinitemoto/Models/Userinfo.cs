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

    public bool IsActive { get; set; }

    public string? Token { get; set; }

    public int? EmpId { get; set; }

    public virtual Companydetail Comp { get; set; } = null!;

    public virtual Employee? Emp { get; set; }

    public virtual Userrole UsertypeNavigation { get; set; } = null!;
}
