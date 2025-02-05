using infinitemoto.DTOs;
using infinitemoto.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace infinitemoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleDocController : ControllerBase
    {
        private readonly IVehicleDocService _vehicleDocService;

        public VehicleDocController(IVehicleDocService vehicleDocService)
        {
            _vehicleDocService = vehicleDocService;
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleDocDTO>> GetVehicleDocs()
        {
            return await _vehicleDocService.GetAllVehicleDocsAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleDoc(int id)
        {
            var vehicleDoc = await _vehicleDocService.GetVehicleDocByIdAsync(id);
            if (vehicleDoc == null)
                return NotFound();

            return Ok(vehicleDoc);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicleDoc([FromBody] VehicleDocDTO vehicleDocDto)
        {
            await _vehicleDocService.AddVehicleDocAsync(vehicleDocDto);
            return CreatedAtAction(nameof(GetVehicleDoc), new { id = vehicleDocDto.VehDocId }, vehicleDocDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicleDoc(int id, [FromBody] VehicleDocDTO vehicleDocDto)
        {
            await _vehicleDocService.UpdateVehicleDocAsync(id, vehicleDocDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleDoc(int id)
        {
            await _vehicleDocService.DeleteVehicleDocAsync(id);
            return NoContent();
        }
    }
}
