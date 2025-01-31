using System;
using infinitemoto.DTOs;

namespace infinitemoto.DTOs
{
    public interface IVehicleDto
    { 
        int VehicleId { get; set; }
        int RegNumb { get; set; }
        int ChasisNumb { get; set; }        
        DateTime FcUpto { get; set; }
        string EngNumber { get; set; }
        string Make { get; set; }
        string Model { get; set; }
        string Cc { get; set; }
        int? VehicleOf { get; set; }
        string? VehiclePhoto { get; set; }
        bool? Status { get; set; }

    }
    public class VehicleDto : IVehicleDto
    {
        public int VehicleId { get; set; }

        public int RegNumb { get; set; }

        public int ChasisNumb { get; set; }

        public DateTime FcUpto { get; set; }

        public string EngNumber { get; set; } = null!;

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string Cc { get; set; } = null!;

        public int? VehicleOf { get; set; }

        public string? VehiclePhoto { get; set; }

        public bool? Status { get; set; }

        // public DriverDto Driver { get; set; }

        // Navigation Property
       // public DriverDto? VehicleOfNavigation { get; set; }
    }

}

public interface IvehicaldetailsDTO
{
    DriverDto driver{get;set;}
    List<VehicleDto> vehicle { get; set; }
}
public class vehicaldetailsDTO : IvehicaldetailsDTO
{
    public DriverDto driver {get;set;}
    public List<VehicleDto> vehicle { get; set; }
}
