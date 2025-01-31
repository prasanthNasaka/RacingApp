using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Company
{
    public int ComId { get; set; }

    public string? ComName { get; set; }

    public string? Email { get; set; }

    public int? Phone { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<Emp> Emps { get; set; } = new List<Emp>();
}
