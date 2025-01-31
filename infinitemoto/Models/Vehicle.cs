using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public int RegNumb { get; set; }

    public int ChasisNumb { get; set; }

    public DateTime FcUpto { get; set; }

    public string EngNumber { get; set; } = null!;

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Cc { get; set; } = null!;

    public int? VehicleOf { get; set; }

    public string? VehiclePhoto { get; set; }

    public bool? Status { get; set; }

    public virtual Driver? VehicleOfNavigation { get; set; }
}
