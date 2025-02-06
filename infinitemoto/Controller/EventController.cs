using infinitemoto.DTOs;
using infinitemoto.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly IEventCategoryService _eventCategoryService;
    private readonly IEventRegistrationService _eventRegistrationService;

    public EventController(IEventCategoryService eventCategoryService, IEventRegistrationService eventRegistrationService)
    {
        _eventCategoryService = eventCategoryService;
        _eventRegistrationService = eventRegistrationService;
    }

    // ================================
    // 🚀 Event Category Endpoints
    // ================================

    // 🔹 Get All Event Categories
    [HttpGet("categories")]
    public async Task<ActionResult<IEnumerable<EventCategoryDto>>> GetAllEventCategories()
    {
        var categories = await _eventCategoryService.GetAllEventCategoriesAsync();
        return Ok(categories);
    }

    // 🔹 Get a Single Event Category by ID (including its Event details)
    [HttpGet("categories/{id}")]
    public async Task<ActionResult<EventCategoryDto>> GetEventCategoryById(int id)
    {
        var category = await _eventCategoryService.GetEventCategoryByIdAsync(id);
        if (category == null) return NotFound();
        return Ok(category);
    }

    // 🔹 Create a New Event Category
    [HttpPost("categories")]
    public async Task<ActionResult<EventCategoryDto>> CreateEventCategory([FromBody] EventCategoryDto category)
    {
        var createdCategory = await _eventCategoryService.AddEventCategoryAsync(category);
        return CreatedAtAction(nameof(GetEventCategoryById), new { id = createdCategory.EvtCatId }, createdCategory);
    }

    // 🔹 Update an Existing Event Category
    [HttpPut("categories/{id}")]
    public async Task<IActionResult> UpdateEventCategory(int id, [FromBody] EventCategoryDto category)
    {
        var updated = await _eventCategoryService.UpdateEventCategoryAsync(id, category);
        if (!updated) return NotFound();
        return NoContent();
    }

    // 🔹 Delete an Event Category
    [HttpDelete("categories/{id}")]
    public async Task<IActionResult> DeleteEventCategory(int id)
    {
        var deleted = await _eventCategoryService.DeleteEventCategoryAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }

    // ================================
    // 🚀 Event Registration Endpoints
    // ================================

    // 🔹 Get All Event Registrations
    [HttpGet("registrations")]
    public async Task<ActionResult<IEnumerable<EventregistrationDto>>> GetAllEventRegistrations()
    {
        var registrations = await _eventRegistrationService.GetAllEventsAsync();
        return Ok(registrations);
    }

    // 🔹 Get a Single Event Registration by ID
    [HttpGet("registrations/{id}")]
    public async Task<ActionResult<EventregistrationDto>> GetEventRegistrationById(int id)
    {
        var registration = await _eventRegistrationService.GetEventByIdAsync(id);
        if (registration == null) return NotFound();
        return Ok(registration);
    }

    // 🔹 Create a New Event Registration
    [HttpPost("registrations")]
    public async Task<ActionResult<EventregistrationDto>> CreateEventRegistration([FromBody] EventregistrationDto registration)
    {
        var createdRegistration = await _eventRegistrationService.AddEventAsync(registration);
        return CreatedAtAction(nameof(GetEventRegistrationById), new { id = createdRegistration.Eventid }, createdRegistration);
    }

    // 🔹 Update an Existing Event Registration
    [HttpPut("registrations/{id}")]
    public async Task<IActionResult> UpdateEventRegistration(int id, [FromBody] EventregistrationDto registration)
    {
        var updated = await _eventRegistrationService.UpdateEventAsync(id, registration);
        if (!updated) return NotFound();
        return NoContent();
    }

    // 🔹 Delete an Event Registration
    [HttpDelete("registrations/{id}")]
    public async Task<IActionResult> DeleteEventRegistration(int id)
    {
        var deleted = await _eventRegistrationService.DeleteEventAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
