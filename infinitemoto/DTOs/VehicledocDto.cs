namespace infinitemoto.DTOs
{

    public interface IVehicledocDto
    {
        int VehDocId { get; set; }
        string DocType { get; set; }
        string DocPath { get; set; }
        int? VehicleId { get; set; }
        string Status { get; set; }
        DateTime Validtill { get; set; }
        DateTime RcBookValidTill { get; set; }
        DateTime InsuranceValidTill { get; set; }
        bool FitnessRequired { get; set; }
        string? FitnessCertificate { get; set; }
    }
    public class VehicleDocDTO : IVehicledocDto
    {
        public int VehDocId { get; set; }
        public string DocType { get; set; } = null!;
        public string DocPath { get; set; } = null!;
        public int? VehicleId { get; set; }
        public string Status { get; set; } = null!;
        public DateTime Validtill { get; set; }
        public DateTime RcBookValidTill { get; set; }
        public DateTime InsuranceValidTill { get; set; }
        public bool FitnessRequired { get; set; }
        public string? FitnessCertificate { get; set; }
    }
}
