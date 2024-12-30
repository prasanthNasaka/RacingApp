using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace infinitemoto.Models
{
   public class Registration
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public required DateTime DOB { get; set; }
        public required string BloodGroup { get; set; }
        public required string DrivingLicense { get; set; }
        public DateTime DrivingLicenseValidTill { get; set; }
        public required string FMSCI_License { get; set; }
        public DateTime FMSCI_LicenseValidTill { get; set; }
        public required string Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public  string   Email { get; set; }
        public string Image { get; set; }
    }
}
