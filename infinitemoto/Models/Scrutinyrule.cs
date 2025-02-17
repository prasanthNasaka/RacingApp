using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Scrutinyrule
{
    public int ScrutinyrulesId { get; set; }

    public string ScrutinyDescription { get; set; } = null!;

    public virtual ICollection<Scrutineydetail> Scrutineydetails { get; set; } = new List<Scrutineydetail>();
}
