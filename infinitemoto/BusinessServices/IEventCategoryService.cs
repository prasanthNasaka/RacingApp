using infinitemoto.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace infinitemoto.Services
{
  public interface IEventCategoryService
{
    Task<IEnumerable<EventCategorygetDto>> GetAllEventCategoriesAsync();
    Task<EventCategorygetDto?> GetEventCategoryByIdAsync(int id);
    Task<EventCategoryCreateDto> CreateEventCategoryAsync(EventCategoryCreateDto eventCategoryDto);
    Task<bool> UpdateEventCategoryAsync(int id, EventCategoryCreateDto eventCategoryDto);
    Task<bool> DeleteEventCategoryAsync(int id);
}

}
