using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Driver
{
    public int DriverId { get; set; }

    public string Drivername { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FmsciNumb { get; set; } = null!;

    public DateOnly FmsciValidTill { get; set; }

    public string DlNumb { get; set; } = null!;

    public DateOnly DlValidTill { get; set; }

    public DateOnly Dob { get; set; }

    public string Bloodgroup { get; set; } = null!;

    public int? Teammemberof { get; set; }

    public string? DriverPhoto { get; set; }

    public string? DlPhoto { get; set; }

    public string? FmsciLicPhoto { get; set; }

    public bool Status { get; set; }

    public virtual Team? TeammemberofNavigation { get; set; }
}
