using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public string? RegNumb { get; set; }

    public string? ChasisNumb { get; set; }

    public DateOnly? FcUpto { get; set; }

    public string? EngNumber { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public string? Cc { get; set; }

    public int? VehicleOf { get; set; }

    public string? VehiclePhoto { get; set; }

    public bool? Status { get; set; }

   public virtual Driver? VehicleOfNavigation { get; set; }

    public virtual ICollection<Vehicledoc> Vehicledocs { get; set; } = new List<Vehicledoc>();
}
