using infinitemoto.DTOs;

namespace infinitemoto.Services
{
    public interface IRegistrationService
    {
        Task<RegistrationresDto> CreateRegistrationAsync(RegistrationreqDto dto);
        Task<IEnumerable<RegistrationresDto>> GetAllRegistrationsAsync();
        Task<RegistrationresDto?> GetRegistrationByIdAsync(int id);
    }
}
