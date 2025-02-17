using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Userrole
{
    public int Roleid { get; set; }

    public string Rolename { get; set; } = null!;

    public int? Eventtypeid { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Userinfo> Userinfos { get; set; } = new List<Userinfo>();
}
