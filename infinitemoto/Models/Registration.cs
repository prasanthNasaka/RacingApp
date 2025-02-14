using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Registration
{
    public int RegId { get; set; }

    public int VechId { get; set; }

    public int DriverId { get; set; }

    public int EventId { get; set; }

    public int EventcategoryId { get; set; }

    public int ContestantNo { get; set; }

    public bool AmountPaid { get; set; }

    public string? ReferenceNo { get; set; }

    public string? RaceStatus { get; set; }

    public DateTime? ScrutinyDone { get; set; } 

    public DateTime? AddDate { get; set; }

    public int? AddBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual Driver Driver { get; set; } = null!;

    public virtual Eventregistration Event { get; set; } = null!;

    public virtual Eventcategory Eventcategory { get; set; } = null!;

    public virtual Vehicle Vech { get; set; } = null!;
}
