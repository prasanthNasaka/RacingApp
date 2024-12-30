namespace infinitemoto.DTOs
{

    public interface IRegistrationDto
    {
         int Id { get; set; }
         string Name { get; set; }
         DateTime DOB { get; set; }
         string BloodGroup { get; set; }
         string DrivingLicense { get; set; }
         DateTime DrivingLicenseValidTill { get; set; }
         string FMSCI_License { get; set; }
         DateTime FMSCI_LicenseValidTill { get; set; }
         string Phone { get; set; }
         string Email { get; set; }
         string Image { get; set; }
    }
      public class RegistrationDto:IRegistrationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string BloodGroup { get; set; }
        public string DrivingLicense { get; set; }
        public DateTime DrivingLicenseValidTill { get; set; }
        public string FMSCI_License { get; set; }
        public DateTime FMSCI_LicenseValidTill { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
}
