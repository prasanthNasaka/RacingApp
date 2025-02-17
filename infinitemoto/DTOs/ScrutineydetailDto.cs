using System.Runtime.CompilerServices;
using infinitemoto.Models;

namespace infinitemoto.DTOs
{
    public interface IScrutineydetailresDto
    {
        int ScrutineydetailsId { get; set; }
        int ScrutineyruleId { get; set; }
        string Status { get; set; }
        string? Comment { get; set; }
        int RegId { get; set; }
    }
    public class ScrutineydetailresDto : IScrutineydetailresDto
    {
        public int ScrutineydetailsId { get; set; }

        public int ScrutineyruleId { get; set; }

        public string Status { get; set; } = null!;

        public string? Comment { get; set; }

        public int RegId { get; set; }
    }

    public interface IScrutineydetailreqDto
    {
        int ScrutineydetailsId { get; set; }
        int ScrutineyruleId { get; set; }
        string Status { get; set; }
        string? Comment { get; set; }
        int RegId { get; set; }
    }
    public class ScrutineydetailreqDto : IScrutineydetailreqDto
    {
        public int ScrutineydetailsId { get; set; }

        public int ScrutineyruleId { get; set; }

        public string Status { get; set; } = null!;

        public string? Comment { get; set; }

        public int RegId { get; set; }
    }

}