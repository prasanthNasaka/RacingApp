using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Registration
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string BloodGroup { get; set; } = null!;

    public string DrivingLicense { get; set; } = null!;

    public DateTime DrivingLicenseValidTill { get; set; }

    public string FmsciLicense { get; set; } = null!;

    public DateTime FmsciLicenseValidTill { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Image { get; set; } = null!;
}
