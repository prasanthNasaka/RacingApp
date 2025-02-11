using infinitemoto.LookUps;

namespace infinitemoto.DTOs
{

    public interface IVehicledocDto
    {
        int VehDocId { get; set; }
        string DocType { get; set; }
        IFormFile ? DocImage { get; set; }
        int? VehicleId { get; set; }
        EventStatus Status { get; set; }
        DateTime Validtill { get; set; }
        
    }
    public class VehicleDocDTO : IVehicledocDto
    {
        public int VehDocId { get; set; }
        public string DocType { get; set; } = null!;
        public IFormFile ? DocImage { get; set; } = null!;
        public int? VehicleId { get; set; }
        public EventStatus Status { get; set; }
        public DateTime Validtill { get; set; }
        
    }
}
