using infinitemoto.DTOs;

namespace infinitemoto.Services
{
    public interface IScrutineerService
    {
        Task<IEnumerable<ScrutineerresDto>> GetAllScrutineersAsync();
        Task<ScrutineerresDto?> GetScrutineerByIdAsync(int id);
        Task<ScrutineerresDto> CreateScrutineerAsync(ScrutineerreqDto dto);
        Task<ScrutineerresDto?> UpdateScrutineerAsync(int id, ScrutineerreqDto dto);
        Task<bool> DeleteScrutineerAsync(int id);
    }
}
