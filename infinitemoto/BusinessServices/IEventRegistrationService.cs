using infinitemoto.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace infinitemoto.Services
{
    public interface IEventRegistrationService
    {
        Task<IEnumerable<EventregistrationDto>> GetAllEventsAsync();
        Task<EventregistrationDto?> GetEventByIdAsync(int id);
        Task<EventregistrationDto> AddEventAsync(EventregistrationDto eventRegistration);
        Task<bool> UpdateEventAsync(int id, EventregistrationDto eventRegistration);
        Task<bool> DeleteEventAsync(int id);
    }
}
