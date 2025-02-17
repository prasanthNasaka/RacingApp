using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Companydetail
{
    public int CompanyId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public int? Zip { get; set; }

    public string? Country { get; set; }

    public string? Website { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Eventregistration> Eventregistrations { get; set; } = new List<Eventregistration>();

    public virtual ICollection<Userinfo> Userinfos { get; set; } = new List<Userinfo>();
}
