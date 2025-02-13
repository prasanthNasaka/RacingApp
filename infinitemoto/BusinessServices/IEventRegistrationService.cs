using infinitemoto.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace infinitemoto.Services
{
     public interface IEventRegistrationService
    {
        Task<IEnumerable<EventregistrationResDto>> GetAllEventsAsync();
        Task<EventregistrationResDto?> GetEventByIdAsync(int eventId);
        Task<bool> AddEventAsync(EventregistrationReqDto eventDto, IFormFile banner, IFormFile qrpath);
        Task UpdateEventAsync(int eventId, EventregistrationReqDto eventDto);
        Task DeleteEventAsync(int eventId);
    }
}
