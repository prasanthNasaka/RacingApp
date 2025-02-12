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

    public async Task<IEnumerable<EventCategorygetDto>> GetAllEventCategoriesAsync(int event_id = 0)  
    {
        if(event_id > 0 )
        {
            return await _context.Eventcategories 
            .Where(e => e.EventId == event_id)
            .Select(e => new EventCategorygetDto
            {
                EvtCatId = e.EvtCatId,
                EvtCategory = e.EvtCategory,
                NoOfVeh = e.NoOfVeh,
                Status = e.Status,
                Nooflaps = e.Nooflaps,
                Entryprice = e.Entryprice,
                Wheelertype = e.Wheelertype,
                EventId = e.EventId
            })
            .ToListAsync();
        }
        else
        {
        return await _context.Eventcategories
            .Select(e => new EventCategorygetDto
            {
                EvtCatId = e.EvtCatId,
                EvtCategory = e.EvtCategory,
                NoOfVeh = e.NoOfVeh,
                Status = e.Status,
                Nooflaps = e.Nooflaps,
                Entryprice = e.Entryprice,
                Wheelertype = e.Wheelertype,
                EventId = e.EventId
            })
            .ToListAsync();
        }
    }

    public async Task<EventCategorygetDto?> GetEventCategoryByIdAsync(int id)
    {
        var eventCategory = await _context.Eventcategories.FindAsync(id);
        if (eventCategory == null) return null;

        return new EventCategorygetDto
        {
            EvtCatId = eventCategory.EvtCatId,
            EvtCategory = eventCategory.EvtCategory,
            NoOfVeh = eventCategory.NoOfVeh,
            Status = eventCategory.Status,
            Nooflaps = eventCategory.Nooflaps,
            Entryprice = eventCategory.Entryprice,
            Wheelertype = eventCategory.Wheelertype,
            EventId = eventCategory.EventId
        };
    }

    public async Task<EventCategoryCreateDto> CreateEventCategoryAsync(EventCategoryCreateDto eventCategoryDto)
    {
        var newCategory = new Eventcategory
        {
            EvtCategory = eventCategoryDto.EvtCategory,
            NoOfVeh = eventCategoryDto.NoOfVeh,
            Status = eventCategoryDto.Status,
            Nooflaps = eventCategoryDto.Nooflaps,
            Entryprice = eventCategoryDto.Entryprice,
            Wheelertype = eventCategoryDto.Wheelertype,
            EventId = eventCategoryDto.EventId
        };

        _context.Eventcategories.Add(newCategory);
        await _context.SaveChangesAsync();

        return new EventCategoryCreateDto
        {
            EvtCatId = newCategory.EvtCatId,
            EvtCategory = newCategory.EvtCategory,
            NoOfVeh = newCategory.NoOfVeh,
            Status = newCategory.Status,
            Nooflaps = newCategory.Nooflaps,
            Entryprice = newCategory.Entryprice,
            Wheelertype = newCategory.Wheelertype,
            EventId = newCategory.EventId
        };
    }

    public async Task<bool> UpdateEventCategoryAsync(int id, EventCategoryCreateDto eventCategoryDto)
    {
        var eventCategory = await _context.Eventcategories.FindAsync(id);
        if (eventCategory == null) return false;

        eventCategory.EvtCategory = eventCategoryDto.EvtCategory;
        eventCategory.NoOfVeh = eventCategoryDto.NoOfVeh;
        eventCategory.Status = eventCategoryDto.Status;
        eventCategory.Nooflaps = eventCategoryDto.Nooflaps;
        eventCategory.Entryprice = eventCategoryDto.Entryprice;
        eventCategory.Wheelertype = eventCategoryDto.Wheelertype;
        eventCategory.EventId = eventCategoryDto.EventId;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteEventCategoryAsync(int id)
    {
        var eventCategory = await _context.Eventcategories.FindAsync(id);
        if (eventCategory == null) return false;

        _context.Eventcategories.Remove(eventCategory);
        await _context.SaveChangesAsync();
        return true;
    }
}

}
