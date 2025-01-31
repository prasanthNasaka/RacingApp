using System;
using System.Collections.Generic;
using infinitemoto.Models;

namespace infinitemoto.DTOs;

public interface IDriverDto
{
     int DriverId { get; set; }
        string Drivername { get; set; }
        int Phone { get; set; }
        string Email { get; set; }
        int FmsciNumb { get; set; }
        DateTime FmsciValidTill { get; set; }
        int DlNumb { get; set; }
        DateTime DlValidTill { get; set; }
        DateTime Dob { get; set; }
        string Bloodgroup { get; set; }
        int? Teammemberof { get; set; }
        string? DriverPhoto { get; set; }
        string? DlPhoto { get; set; }
        string? FmsciLicPhoto { get; set; }
        bool Status { get; set; }
        List<VehicleDto> Vehicles { get; set; }
    // Team? TeammemberofNavigation { get; set; }
    // ICollection<Vehicle> Vehicles { get; set; }
}

public class DriverDto : IDriverDto
{
    public int DriverId { get; set; }
        public string Drivername { get; set; } = null!;
        public int Phone { get; set; }
        public string Email { get; set; } = null!;
        public int FmsciNumb { get; set; }
        public DateTime FmsciValidTill { get; set; }
        public int DlNumb { get; set; }
        public DateTime DlValidTill { get; set; }
        public DateTime Dob { get; set; }
        public string Bloodgroup { get; set; } = null!;
        public int? Teammemberof { get; set; }
        public string? DriverPhoto { get; set; }
        public string? DlPhoto { get; set; }
        public string? FmsciLicPhoto { get; set; }
        public bool Status { get; set; }

        public List<VehicleDto> Vehicles { get; set; }
   // public object VehicleName { get; internal set; }

    //public VehicleDto obbb  { get; set; }

    // public virtual Team? TeammemberofNavigation { get; set; }
    // public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
