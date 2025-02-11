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
        DateTime FcUpto { get; set; }
        string EngNumber { get; set; }
        string Make { get; set; }
        string Model { get; set; }
        string Cc { get; set; }
        int? VehicleOf { get; set; }
        IFormFile VehiclePhoto { get; set; }
        EventStatus Status { get; set; }
        List< VehicleDocDTO?> VehicleDoc{get;set;}
    }
    public class VehicleDTO : IVehicleDto
    {
        public int VehicleId { get; set; }
        public string RegNumb { get; set; }
        public string ChasisNumb { get; set; }
        public DateTime FcUpto { get; set; }
        public string EngNumber { get; set; } = null!;
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Cc { get; set; } = null!;
        public int? VehicleOf { get; set; }
        public IFormFile VehiclePhoto { get; set; }

        //[JsonConverter(typeof(JsonStringEnumConverter))] 
        public EventStatus Status { get; set; }

        // public List< VehicleDocDTO?> VehicleDoc { get; set; }
        public List<VehicleDocDTO> VehicleDoc { get; set; }

    }

    
}
