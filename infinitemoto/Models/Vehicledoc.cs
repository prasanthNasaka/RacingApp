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

    public DateOnly Validtill { get; set; }

    public DateOnly RcBookValidTill { get; set; }

    public DateOnly InsuranceValidTill { get; set; }

    public bool FitnessRequired { get; set; }

    public string? FitnessCertificate { get; set; }
}
