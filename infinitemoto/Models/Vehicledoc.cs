using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class VehicleDoc
{
    public int VehDocId { get; set; }

    public string DocType { get; set; } = null!;

    public string DocPath { get; set; } = null!;

    public int? VehicleId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime Validtill { get; set; }

    public DateTime RcBookValidTill { get; set; }

    public DateTime InsuranceValidTill { get; set; }

    public bool FitnessRequired { get; set; }

    public string? FitnessCertificate { get; set; }

    public virtual Vehicle VehDoc { get; set; } = null!;
}
