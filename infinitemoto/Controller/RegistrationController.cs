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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistrationresDto>>> GetAllRegistrations()
        {
            return Ok(await _registrationService.GetAllRegistrationsAsync());
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
