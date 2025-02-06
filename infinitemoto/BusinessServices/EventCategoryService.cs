using infinitemoto.DTOs;
using infinitemoto.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infinitemoto.Services
{
    public class EventCategoryService : IEventCategoryService
    {
        private readonly DummyProjectSqlContext _context;

        public EventCategoryService(DummyProjectSqlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventCategoryDto>> GetAllEventCategoriesAsync()
        {
            return await _context.Eventcategories
                .Select(ec => new EventCategoryDto
                {
                    EvtCatId = ec.EvtCatId,
                    EvtCategory = ec.EvtCategory,
                    NoOfVeh = ec.NoOfVeh,
                    Status = ec.Status,
                    Nooflaps = ec.Nooflaps,
                    Entryprice = ec.Entryprice,
                    Wheelertype = ec.Wheelertype,
                    EventId = ec.EventId
                })
                .ToListAsync();
        }

        public async Task<EventCategoryDto?> GetEventCategoryByIdAsync(int id)
        {
            var category = await _context.Eventcategories.FindAsync(id);
            if (category == null) return null;

            return new EventCategoryDto
            {
                EvtCatId = category.EvtCatId,
                EvtCategory = category.EvtCategory,
                NoOfVeh = category.NoOfVeh,
                Status = category.Status,
                Nooflaps = category.Nooflaps,
                Entryprice = category.Entryprice,
                Wheelertype = category.Wheelertype,
                EventId = category.EventId
            };
        }

        public async Task<EventCategoryDto> AddEventCategoryAsync(EventCategoryDto eventCategory)
        {
            var category = new Eventcategory
            {
                EvtCategory = eventCategory.EvtCategory,
                NoOfVeh = eventCategory.NoOfVeh,
                Status = eventCategory.Status,
                Nooflaps = eventCategory.Nooflaps,
                Entryprice = eventCategory.Entryprice,
                Wheelertype = eventCategory.Wheelertype,
                EventId = eventCategory.EventId
            };

            _context.Eventcategories.Add(category);
            await _context.SaveChangesAsync();

            eventCategory.EvtCatId = category.EvtCatId;
            return eventCategory;
        }

        public async Task<bool> UpdateEventCategoryAsync(int id, EventCategoryDto eventCategory)
        {
            var category = await _context.Eventcategories.FindAsync(id);
            if (category == null) return false;

            category.EvtCategory = eventCategory.EvtCategory;
            category.NoOfVeh = eventCategory.NoOfVeh;
            category.Status = eventCategory.Status;
            category.Nooflaps = eventCategory.Nooflaps;
            category.Entryprice = eventCategory.Entryprice;
            category.Wheelertype = eventCategory.Wheelertype;
            category.EventId = eventCategory.EventId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEventCategoryAsync(int id)
        {
            var category = await _context.Eventcategories.FindAsync(id);
            if (category == null) return false;

            _context.Eventcategories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
