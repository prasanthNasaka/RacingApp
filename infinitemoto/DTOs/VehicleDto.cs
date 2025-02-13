using System.Text.Json.Serialization;
using infinitemoto.LookUps;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace infinitemoto.DTOs
{

    public interface IVehicleDto
    {
        int VehicleId { get; set; }
        string RegNumb { get; set; }
        string ChasisNumb { get; set; }
      //  DateTime FcUpto { get; set; }
        string EngNumber { get; set; }
        string Make { get; set; }
        string Model { get; set; }
        string Cc { get; set; }
        int? VehicleOf { get; set; }

        string? RcNum { get; set; }
        string? IcNum { get; set; }
        DateTime IcUpto { get; set; }
        DateTime RcUpto { get; set; }

        IFormFile VehiclePhoto { get; set; }
        IFormFile RcImage { get; set; }

        IFormFile InsuranceImage { get; set; }

       // IFormFile FcImage { get; set; }
        bool Status { get; set; }
        // List< VehicleDocDTO?> VehicleDoc{get;set;}
    }
    public class VehicleDTO : IVehicleDto
    {
        public int VehicleId { get; set; }
        public string RegNumb { get; set; }
        public string ChasisNumb { get; set; }
       // public DateTime FcUpto { get; set; }
        public string EngNumber { get; set; } = null!;
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Cc { get; set; } = null!;
        public int? VehicleOf { get; set; }
        public IFormFile VehiclePhoto { get; set; }
        public IFormFile RcImage { get; set; }

        public IFormFile InsuranceImage { get; set; }

        //public IFormFile FcImage { get; set; }
        //[JsonConverter(typeof(JsonStringEnumConverter))] 
        public bool Status { get; set; }

       public string? RcNum { get; set; }
        public string? IcNum { get; set; }
       public  DateTime IcUpto { get; set; }
       public DateTime RcUpto { get; set; }

        // public List< VehicleDocDTO?> VehicleDoc { get; set; }
        // public List<VehicleDocDTO> VehicleDoc { get; set; }

    }

     public interface IVehicleresDto
    {
        int VehicleId { get; set; }
        string RegNumb { get; set; }
        string ChasisNumb { get; set; }
       // DateTime FcUpto { get; set; }
        string EngNumber { get; set; }
        string Make { get; set; }
        string Model { get; set; }
        string Cc { get; set; }
        int? VehicleOf { get; set; }
        string VehiclePhoto { get; set; }
        string RcImage { get; set; }

        string InsuranceImage { get; set; }

        string? RcNum { get; set; }
        string? IcNum { get; set; }
        DateOnly? IcUpto { get; set; }
        DateOnly? RcUpto { get; set; }

        //string FcImage { get; set; }
        bool? Status { get; set; }
        // List< VehicleDocDTO?> VehicleDoc{get;set;}
    }

    public class vehicleresDto : IVehicleresDto
    {
        public int VehicleId { get ; set ; }
        public string RegNumb { get ; set ; }
        public string ChasisNumb { get ; set ; }
        //public DateTime FcUpto { get ; set ; }
        public string EngNumber { get ; set ; }
        public string Make { get ; set ; }
        public string Model { get ; set ; }
        public string Cc { get ; set ; }
        public int? VehicleOf { get ; set ; }
        public string VehiclePhoto { get ; set ; }
        public string RcImage { get ; set ; }
        public string InsuranceImage { get ; set ; }

        public string? RcNum { get; set; }
        public string? IcNum { get; set; }
       public  DateOnly? IcUpto { get; set; }
       public DateOnly? RcUpto { get; set; }
        //public string FcImage { get ; set ; }
        public bool? Status { get ; set ; }
    }

public interface IvehiclescrDto
{
    string RegNumb { get; set; }
    // string ChasisNumb { get; set; }
    // string EngNumber { get; set; }
    string Make { get; set; }
    string Model { get; set; }
    string Cc { get; set; }

    string VehiclePhoto { get; set; }
    //int? VehicleOf { get; set; }

}

public class vehiclescrDto : IvehiclescrDto
{
    public string RegNumb { get; set; }
    // public string ChasisNumb  { get; set; }
    // public string EngNumber { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string Cc { get; set; } 

    public string VehiclePhoto { get; set; }

    //public int? VehicleOf { get; set; } 
}

}
