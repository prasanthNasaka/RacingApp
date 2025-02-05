using System;
using System.Collections.Generic;
using infinitemoto.Models;

namespace infinitemoto.DTOs;

public interface IDriverDTO
{
    int DriverId { get; set; }
    string DriverName { get; set; }
    int Phone { get; set; }
    string Email { get; set; }
    int FmsciNumb { get; set; }
    DateTime FmsciValidTill { get; set; }
    int DlNumb { get; set; }
    DateTime DlValidTill { get; set; }
    DateTime Dob { get; set; }
    string BloodGroup { get; set; }
    int? TeamMemberOf { get; set; }
    string? DriverPhoto { get; set; }
    string DlPhoto { get; set; }
    string? FmsciLicPhoto { get; set; }
    bool Status { get; set; }
    string? TeamName { get; set; } // Optional: Include team name for display
}

public class DriverDTO : IDriverDTO
{
    public int DriverId { get; set; }
    public string DriverName { get; set; } = null!;
    public int Phone { get; set; } 
    public string Email { get; set; } = null!;
    public int FmsciNumb { get; set; } 
    public DateTime FmsciValidTill { get; set; }
    public int DlNumb { get; set; }
    public DateTime DlValidTill { get; set; }
    public DateTime Dob { get; set; }
    public string BloodGroup { get; set; } = null!;
    public int? TeamMemberOf { get; set; }
    public string? DriverPhoto { get; set; }
    public string? DlPhoto { get; set; }
    public string? FmsciLicPhoto { get; set; }
    public bool Status { get; set; }
    public string? TeamName { get; set; } // Optional: Include team name for display
}
