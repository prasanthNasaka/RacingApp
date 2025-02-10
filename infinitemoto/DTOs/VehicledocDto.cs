using infinitemoto.LookUps;

namespace infinitemoto.DTOs
{

    public interface IVehicledocDto
    {
        int VehDocId { get; set; }
        string DocType { get; set; }
        string DocPath { get; set; }
        int? VehicleId { get; set; }
        bool? Status { get; set; }
        DateTime Validtill { get; set; }
        
    }
    public class VehicleDocDTO : IVehicledocDto
    {
        public int VehDocId { get; set; }
        public string DocType { get; set; } = null!;
        public string DocPath { get; set; } = null!;
        public int? VehicleId { get; set; }
        public bool? Status { get; set; } = null!;
        public DateTime Validtill { get; set; }
        
    }
}
