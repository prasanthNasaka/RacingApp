using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Eventcategory
{
    public int EvtCatId { get; set; }

    public string? EvtCategory { get; set; }

    public int? NoOfVeh { get; set; }

    public string? Status { get; set; }

    public int Nooflaps { get; set; }

    public int? Entryprice { get; set; }

    public int? Wheelertype { get; set; }

    public int? EventId { get; set; }

    public virtual Eventregistration? Event { get; set; }

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
