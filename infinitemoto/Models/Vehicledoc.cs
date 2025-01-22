using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Vehicledoc
{
    public int VehDocId { get; set; }

    public string? DocType { get; set; }

    public string? DocPath { get; set; }

    public int? VehicleId { get; set; }

    public virtual Vehicle? Vehicle { get; set; }
}
