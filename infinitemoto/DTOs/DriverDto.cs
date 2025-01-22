using System;
using System.Collections.Generic;
using infinitemoto.Models;
namespace infinitemoto.DTOs;

public interface IDriverDto
{
    int DriverId { get; set; }
    string? Drivername { get; set; }
    string? Phone { get; set; }
    string? Email { get; set; }
    string? FmsciNumb { get; set; }
    string? FmsciValidTill { get; set; }
    string? DlNumb { get; set; }
    string? DlValidTill { get; set; }
    string? Dob { get; set; }
    string? Bloodgroup { get; set; }
    int? Teammemberof { get; set; }
    string? DriverPhoto { get; set; }
    bool? Status { get; set; }
    //Team? TeammemberofNavigation { get; set; }
    //ICollection<Vehicle> Vehicles { get; set; }
}


 public class DriverDto : IDriverDto
 {
    public int DriverId { get; set; }

    public string? Drivername { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? FmsciNumb { get; set; }

    public string? FmsciValidTill { get; set; }

    public string? DlNumb { get; set; }

    public string? DlValidTill { get; set; }

    public string? Dob { get; set; }

    public string? Bloodgroup { get; set; }

    public int? Teammemberof { get; set; }

    public string? DriverPhoto { get; set; }

    public bool? Status { get; set; }

    //public virtual Team? TeammemberofNavigation { get; set; }

    //public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
 }