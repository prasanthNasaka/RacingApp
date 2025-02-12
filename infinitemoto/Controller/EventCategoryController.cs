using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infinitemoto.DTOs;
using infinitemoto.Models;
using infinitemoto.LookUps;
using Microsoft.AspNetCore.Authorization;
using infinitemoto.Services;

namespace infinitemoto.Controllers
{
    [ApiController]
[Route("api/eventcategories")]
public class EventCategoryController : ControllerBase
{
    private readonly IEventCategoryService _eventCategoryService;

    public EventCategoryController(IEventCategoryService eventCategoryService)
    {
        _eventCategoryService = eventCategoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int event_id=0)
    {
        var result = await _eventCategoryService.GetAllEventCategoriesAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _eventCategoryService.GetEventCategoryByIdAsync (id); 
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(EventCategoryCreateDto dto)
    {
        var created = await _eventCategoryService.CreateEventCategoryAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.EvtCatId }, created);
    } 

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EventCategoryCreateDto dto)
    {
        var updated = await _eventCategoryService.UpdateEventCategoryAsync(id, dto);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _eventCategoryService.DeleteEventCategoryAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}

}
