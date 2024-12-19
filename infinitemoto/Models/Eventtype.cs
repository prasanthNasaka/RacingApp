using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Eventtype
{
    public int Eventtypeid { get; set; }

    public string Eventtypename { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Userrole> Userroles { get; set; } = new List<Userrole>();
}
