using infinitemoto.DTOs;
using infinitemoto.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http.Json;
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

        // [HttpPost]
        // public async Task<ActionResult> AddEvent([FromForm] EventregistrationReqDto eventDto)
        // {
        //     bool isAdded = await _eventService.AddEventAsync(eventDto);
        //     if (isAdded)
        //         return CreatedAtAction(nameof(GetEventById), new { id = eventDto.Eventname }, eventDto);

        //     return BadRequest("Failed to add event");
        // }

         [HttpPost]
        public async Task<IActionResult> AddEvent ( [FromBody] EventregistrationReqDto eventDto, [FromForm] IFormFile? banner, [FromForm] IFormFile? qrpath)
        {
            var isAdded = await _eventService.AddEventAsync(eventDto, banner, qrpath);
            if (isAdded)
            {
                return Created("Event created successfully", eventDto);
            }
            return BadRequest("Failed to add event"); 
        }


        // [HttpPost]
        // public async Task<IActionResult> AddEvent([FromForm] string eventData, [FromForm] IFormFile banner, [FromForm] IFormFile qrpath)
        // {
        //     if (string.IsNullOrEmpty(eventData))
        //         return BadRequest("Invalid data received.");

        //     // Deserialize eventData JSON into EventregistrationReqDto
        //     EventregistrationReqDto? eventDto;
        //     try
        //     {
        //         eventDto = System.Text.Json.JsonSerializer.Deserialize<EventregistrationReqDto>(eventData);
        //         if (eventDto == null)
        //             return BadRequest("Failed to parse event data.");
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest($"Error parsing event data: {ex.Message}");
        //     }

        //     // Assign uploaded files
        //     eventDto.Banner = banner;
        //     eventDto.Qrpath = qrpath;

        //     var isAdded = await _eventService.AddEventAsync(eventDto);

        //     if (isAdded)
        //     {
        //         return Created("Event created successfully", eventDto);
        //     }
        //     return BadRequest("Failed to add event");
        // }



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
