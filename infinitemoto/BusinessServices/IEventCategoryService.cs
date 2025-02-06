using infinitemoto.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace infinitemoto.Services
{
    public interface IEventCategoryService
    {
        Task<IEnumerable<EventCategoryDto>> GetAllEventCategoriesAsync();
        Task<EventCategoryDto?> GetEventCategoryByIdAsync(int id);
        Task<EventCategoryDto> AddEventCategoryAsync(EventCategoryDto eventCategory);
        Task<bool> UpdateEventCategoryAsync(int id, EventCategoryDto eventCategory);
        Task<bool> DeleteEventCategoryAsync(int id);
    }
}
