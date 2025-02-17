using infinitemoto.DTOs;
using infinitemoto.Models;
using infinitemoto.Services;
using Microsoft.AspNetCore.Mvc;

namespace infinitemoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrutineydetailController : ControllerBase
    {
        private readonly IScrutineydetailService _scrutineydetailService;

        public ScrutineydetailController(IScrutineydetailService scrutineydetailService)
        {
            _scrutineydetailService = scrutineydetailService;
        }

        // 🔹 Get all Scrutineydetails
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var scrutineydetails = await _scrutineydetailService.GetAllScrutineydetailsAsync();
            return Ok(scrutineydetails);
        }

        // 🔹 Get Scrutineydetail by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var scrutineydetail = await _scrutineydetailService.GetScrutineydetailByIdAsync(id);
            if (scrutineydetail == null) return NotFound("Scrutineydetail not found.");
            return Ok(scrutineydetail);
        }

        // 🔹 Create Scrutineydetail
        [HttpPost]
        public async Task<IActionResult> Create(ScrutineydetailreqDto dto)
        {
            try
            {
                var newScrutineydetail = await _scrutineydetailService.CreateScrutineydetailAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = newScrutineydetail.ScrutineydetailsId }, newScrutineydetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // 🔹 Update Scrutineydetail
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ScrutineydetailreqDto dto)
        {
            try
            {
                var updatedScrutineydetail = await _scrutineydetailService.UpdateScrutineydetailAsync(id, dto);
                if (updatedScrutineydetail == null) return NotFound("Scrutineydetail not found.");
                return Ok(updatedScrutineydetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // 🔹 Delete Scrutineydetail
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _scrutineydetailService.DeleteScrutineydetailAsync(id);
            if (!result) return NotFound("Scrutineydetail not found.");
            return NoContent();
        }
    }
}
