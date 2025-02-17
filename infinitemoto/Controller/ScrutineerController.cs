using infinitemoto.DTOs;
using infinitemoto.Services;
using Microsoft.AspNetCore.Mvc;

namespace infinitemoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrutineerController : ControllerBase
    {
        private readonly IScrutineerService _scrutineerService;

        public ScrutineerController(IScrutineerService scrutineerService)
        {
            _scrutineerService = scrutineerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllScrutineers()
        {
            var result = await _scrutineerService.GetAllScrutineersAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetScrutineerById(int id)
        {
            var result = await _scrutineerService.GetScrutineerByIdAsync(id);
            if (result == null) return NotFound("Scrutineer not found");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateScrutineer([FromBody] ScrutineerreqDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.ScrutineerName))
            {
                return BadRequest("Scrutineer name is required.");
            }

            var result = await _scrutineerService.CreateScrutineerAsync(dto);
            return CreatedAtAction(nameof(GetScrutineerById), new { id = result.ScrutineerId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ScrutineerreqDto dto)
        {
            var updatedScrutineer = await _scrutineerService.UpdateScrutineerAsync(id, dto);
            if (updatedScrutineer == null) return NotFound("Scrutineer not found.");

            return Ok(updatedScrutineer);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScrutineer(int id)
        {
            var success = await _scrutineerService.DeleteScrutineerAsync(id);
            if (!success) return NotFound("Scrutineer not found");
            return NoContent();
        }
    }
}
