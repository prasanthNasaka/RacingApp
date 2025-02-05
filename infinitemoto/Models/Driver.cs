using System;

namespace infinitemoto.Models
{
    public partial class Driver
    {
        public int DriverId { get; set; }

        public string Drivername { get; set; } = null!;

        public int Phone { get; set; }

        public string Email { get; set; } = null!;

        public int FmsciNumb { get; set; }

        public DateTime FmsciValidTill { get; set; }

        public int? DlNumb { get; set; }

        public DateTime DlValidTill { get; set; }

        public DateTime Dob { get; set; }

        public string Bloodgroup { get; set; } = null!;

        public int Teammemberof { get; set; }  // Foreign key for the Team (Nullable)

        public string? DriverPhoto { get; set; }

        public string? DlPhoto { get; set; }

        public string? FmsciLicPhoto { get; set; }

        public bool Status { get; set; }

        // Navigation property for Team
        public virtual Team? TeammemberofNavigation { get; set; }  
    }
}
