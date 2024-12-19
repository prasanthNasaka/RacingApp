using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Category
{
    public int Categoryid { get; set; }

    public int Eventtypeid { get; set; }

    public string Categoryname { get; set; } = null!;

    public virtual Eventtype Eventtype { get; set; } = null!;
}
