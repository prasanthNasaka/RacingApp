using System.Runtime.CompilerServices;
using infinitemoto.Models;

namespace infinitemoto.DTOs
{

    public interface IRegistrationreqDto
    {
        //int RegId { get; set; }

        int VechId { get; set; }

        int DriverId { get; set; }

        int EventId { get; set; }

        int EventcategoryId { get; set; }

        int ContestantNo { get; set; }

        bool AmountPaid { get; set; }

        string ReferenceNo { get; set; }

        string? ScrutinyStatus { get; set; }

        string? DocumentStatus { get; set; }

        // DateTime? ScrutinyDone { get; set; }

        // DateTime? AddDate { get; set; }

        // int? AddBy { get; set; }
        // int? UpdatedBy { get; set; }

    }
    public class RegistrationreqDto : IRegistrationreqDto
    {
        //public int RegId { get; set; }

        public int VechId { get; set; }

        public int DriverId { get; set; }

        public int EventId { get; set; }

        public int EventcategoryId { get; set; }

        public int ContestantNo { get; set; }

        public bool AmountPaid { get; set; }


        public string? ReferenceNo { get; set; } = null!;

        public string? ScrutinyStatus { get; set; }

        public string? DocumentStatus { get; set; }


        //     public string RaceStatus { get; set; } = null!; 

        //        public DateTime? ScrutinyDone { get; set; }

        // public DateTime? AddDate { get; set; }

        // public int? AddBy { get; set; }

        // public int? UpdatedBy { get; set; }

    }

    public interface IRegistrationresDto
    {
        int RegId { get; set; }

        int VechId { get; set; }

        int DriverId { get; set; }

        int EventId { get; set; }
        string Eventname { get; set; }

        int EventcategoryId { get; set; }
        string EvtCategory { get; set; }

        int ContestantNo { get; set; }

        bool AmountPaid { get; set; }

        string? ReferenceNo { get; set; }

        string RegNumb { get; set; }
        string Drivername { get; set; }

        string? ScrutinyStatus { get; set; }

        string? DocumentStatus { get; set; }

        // string RaceStatus { get; set; }

        // DateTime? ScrutinyDone { get; set; }

        // DateTime? AddDate { get; set; }

        // int? AddBy { get; set; }
        // int? UpdatedBy { get; set; }

        // List<EventregistrationResDto> Event { get; set; }
        // List<EventCategorygetDto> Eventcategory { get; set; }
        // List<DriverResDTO> Driver { get; set; }
        // List<vehicleresDto> Vech { get; set; }

    }

    public class RegistrationresDto : IRegistrationresDto

    {
        public int RegId { get; set; }

        public int VechId { get; set; }

        public int DriverId { get; set; }

        public int EventId { get; set; }
        public string Eventname { get; set; }

        public int EventcategoryId { get; set; }

        public string EvtCategory { get; set; }
        public int ContestantNo { get; set; }

        public bool AmountPaid { get; set; }

        public string ReferenceNo { get; set; } = null!;

        public string RegNumb { get; set; }
        public string Drivername { get; set; }

        public string? ScrutinyStatus { get; set; }

        public string? DocumentStatus { get; set; }

        // public List<EventregistrationResDto> Event { get; set; }
        // public List<EventCategorygetDto> Eventcategory { get; set; }
        // public List<DriverResDTO> Driver { get; set; }

        // public List<vehicleresDto> Vech { get; set; }

    }
}
