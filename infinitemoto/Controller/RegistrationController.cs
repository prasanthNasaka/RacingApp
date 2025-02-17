using infinitemoto.DTOs;
using infinitemoto.Services;
using Microsoft.AspNetCore.Mvc;

namespace infinitemoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public async Task<ActionResult<RegistrationresDto>> CreateRegistration(RegistrationreqDto dto)
        {
            var createdRegistration = await _registrationService.CreateRegistrationAsync(dto);
            return CreatedAtAction(nameof(GetRegistrationById), new { id = createdRegistration.RegId }, createdRegistration);
        }

        [HttpGet("event/{id}")]
        public async Task<ActionResult<IEnumerable<RegistrationresDto>>> GetRegistrationByEventId(int id)
        {
            var registrations = await _registrationService.GetRegistrationsByEventIdAsync(id);

            // If there are no registrations found, return a 404 Not Found
            if (registrations == null || !registrations.Any())
            {
                return NotFound("No registrations found for the specified event.");
            }

            return Ok(registrations);  // Return the list of registrations with a 200 OK status
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<RegistrationresDto>> GetRegistrationById(int id)
        {
            var registration = await _registrationService.GetRegistrationByIdAsync(id);
            if (registration == null) return NotFound();
            return Ok(registration);
        }
    }
}
