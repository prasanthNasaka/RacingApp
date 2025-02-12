using infinitemoto.DTOs;
using infinitemoto.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace infinitemoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRegistrationController : ControllerBase
    {
        private readonly IEventRegistrationService _eventService;

        public EventRegistrationController(IEventRegistrationService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventregistrationResDto>>> GetAllEvents()
        {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventregistrationResDto>> GetEventById(int id)
        {
            var eventDto = await _eventService.GetEventByIdAsync(id);
            if (eventDto == null)
                return NotFound("Event not found");

            return Ok(eventDto);
        }

        [HttpPost]
        public async Task<ActionResult> AddEvent([FromForm] EventregistrationReqDto eventDto)
        {
            bool isAdded = await _eventService.AddEventAsync(eventDto);
            if (isAdded)
                return CreatedAtAction(nameof(GetEventById), new { id = eventDto.Eventname }, eventDto);
            
            return BadRequest("Failed to add event");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEvent(int id, [FromForm] EventregistrationReqDto eventDto)
        {
            try
            {
                await _eventService.UpdateEventAsync(id, eventDto);
                return NoContent();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            try
            {
                await _eventService.DeleteEventAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
