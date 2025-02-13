using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public string RegNumb { get; set; } = null!;

    public string ChasisNumb { get; set; } = null!;

    public string EngNumber { get; set; } = null!;

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Cc { get; set; } = null!;

    public int? VehicleOf { get; set; }

    public string? VehiclePhoto { get; set; }

    public bool? Status { get; set; }

    public string? RcImage { get; set; }

    public string? InsuranceImage { get; set; }

    public string? RcNum { get; set; }

    public string? IcNum { get; set; }

    public DateOnly? IcUpto { get; set; }

    public DateOnly? RcUpto { get; set; }

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();

    public virtual VehicleDoc? VehicleDoc { get; set; }
}
