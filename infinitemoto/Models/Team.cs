using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Team
{
    public int TeamId { get; set; }

    public string? TeamName { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();
}
