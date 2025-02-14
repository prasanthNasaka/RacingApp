using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? EmpName { get; set; }

    public string? Email { get; set; }

    public int? ComId { get; set; }

    public int? AccId { get; set; }

    public int? Phone { get; set; }

    public int? Age { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Location { get; set; }

    public virtual Company? Com { get; set; }
}
