using System.Runtime.CompilerServices;
using infinitemoto.Models;

namespace infinitemoto.DTOs
{
    public interface IScrutineerreqDto
    {
        string ScrutineerName { get; set; }
    }
    public class ScrutineerreqDto : IScrutineerreqDto
    {
        public string ScrutineerName { get; set; } = null!;
    }

    public interface IScrutineerresDto
    {
        int ScrutineerId { get; set; }
        string ScrutineerName { get; set; }
    }
    public class ScrutineerresDto :     IScrutineerresDto
    {
        public int ScrutineerId { get; set; }
        public string ScrutineerName { get; set; } = null!;
    }


}