using infinitemoto.DTOs;

namespace infinitemoto.Services
{
    public interface IRegistrationService
    {
        Task<RegistrationresDto> CreateRegistrationAsync(RegistrationreqDto dto);
        Task<IEnumerable<RegistrationresDto>> GetRegistrationsByEventIdAsync(int eventId);
        Task<RegistrationresDto?> GetRegistrationByIdAsync(int id);
    }
}
