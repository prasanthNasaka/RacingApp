using System;
using System.Collections.Generic;
using infinitemoto.LookUps;

namespace infinitemoto.Models;

public partial class VehicleDoc
{
    public int VehDocId { get; set; }

    public string DocType { get; set; } = null!;

    public string DocPath { get; set; } = null!;

    public int? VehicleId { get; set; }

    public bool? Status { get; set; }

    public DateOnly Validtill { get; set; }

    public virtual Vehicle VehDoc { get; set; } = null!;
}
