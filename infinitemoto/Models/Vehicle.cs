using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public string RegNumb { get; set; } = null!;

    public string ChasisNumb { get; set; } = null!;

    public DateOnly FcUpto { get; set; }

    public string EngNumber { get; set; } = null!;

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Cc { get; set; } = null!;

    public int? VehicleOf { get; set; }

    public string? VehiclePhoto { get; set; }

    public bool? Status { get; set; }

    public string? RcImage { get; set; }

    public string? InsuranceImage { get; set; }

    public string? FcImage { get; set; }

    public virtual VehicleDoc? VehicleDoc { get; set; }
}
