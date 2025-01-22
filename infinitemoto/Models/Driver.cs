using System;
using System.Collections.Generic;
// using System.DateOnly; // Removed as DateOnly is a type, not a namespace

namespace infinitemoto.Models;

public partial class Driver
{
    public int DriverId { get; set; }

    public string? Drivername { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? FmsciNumb { get; set; }

    public DateOnly? FmsciValidTill { get; set; }

    public string? DlNumb { get; set; }

    public DateOnly? DlValidTill { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Bloodgroup { get; set; }

    public int? Teammemberof { get; set; }

    public string? DriverPhoto { get; set; }

    public bool? Status { get; set; }

   public virtual Team? TeammemberofNavigation { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
