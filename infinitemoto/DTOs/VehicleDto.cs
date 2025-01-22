using System;
using System.Collections.Generic;
namespace infinitemoto.DTOs;


public interface IVehicleDto
{
    int VehicleId { get; set; }
    string? RegNumb { get; set; }
    string? ChasisNumb { get; set; }
    string? FcUpto { get; set; }
    string? EngNumber { get; set; }
    string? Make { get; set; }
    string? Model { get; set; }
    string? Cc { get; set; }
    int? VehicleOf { get; set; }
    string? VehiclePhoto { get; set; }
    bool? Status { get; set; }
 //   DriverDto? VehicleOfNavigation { get; set; }
    //ICollection<VehicledocDto> Vehicledocs { get; set; }
}

public class VehicleDto : IVehicleDto
{ 
    public int VehicleId { get; set; }

    public string? RegNumb { get; set; }

    public string? ChasisNumb { get; set; }

    public string? FcUpto { get; set; }

    public string? EngNumber { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public string? Cc { get; set; }

    public int? VehicleOf { get; set; }

    public string? VehiclePhoto { get; set; }

    public bool? Status { get; set; }

//    public virtual DriverDto? VehicleOfNavigation { get; set; }

 //   public virtual ICollection<VehicledocDto> Vehicledocs { get; set; } = new List<VehicledocDto>();

}