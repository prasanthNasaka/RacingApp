using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Companydetail
{
    public int Companyid { get; set; }

    public string Companyname { get; set; } = null!;

    public virtual ICollection<Eventregistration> Eventregistrations { get; set; } = new List<Eventregistration>();
}
