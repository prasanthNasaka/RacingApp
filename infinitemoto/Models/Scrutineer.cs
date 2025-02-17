using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Scrutineer
{
    public int ScrutineerId { get; set; }

    public string ScrutineerName { get; set; } = null!;

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
