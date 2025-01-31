using Microsoft.AspNetCore.Mvc;
using infinitemoto.DTOs;
using infinitemoto.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace infinitemoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        // Constructor that accepts IVehicleService as dependency
        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDto>>> GetVehicles()
        {
            // Get all vehicles from the service
            var vehicles = await _vehicleService.GetAllVehiclesAsync();
            return Ok(vehicles);  // Return the list of vehicles
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDto>> GetVehicle(int id)
        {
            // Get vehicle by ID from the service
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();  // Return NotFound if vehicle not found
            }
            return Ok(vehicle);  // Return the vehicle details
        }

        // POST: api/Vehicles
        [HttpPost]
        public async Task<ActionResult<VehicleDto>> CreateVehicle([FromBody] List<VehicleDto> vehicleDto,int DriverID)
        {
            // Create a new vehicle using the service
            var createdVehicle = await _vehicleService.CreateVehicleAsync(vehicleDto,DriverID);

            // Return CreatedAtAction response with the newly created vehicle
           // return CreatedAtAction(nameof(GetVehicle), new { id = createdVehicle.VehicleId }, createdVehicle);
           return Ok(createdVehicle);
        }

        // PUT: api/Vehicles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] VehicleDto vehicleDto)
        {
            // Update the vehicle using the service
            var result = await _vehicleService.UpdateVehicleAsync(id, new List<VehicleDto> { vehicleDto });
            if (!result)
            {
                return NotFound();  // Return NotFound if vehicle with the specified ID does not exist
            }

            return NoContent();  // Return NoContent if update is successful
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            // Delete the vehicle using the service
            var result = await _vehicleService.DeleteVehicleAsync(id);
            if (!result)
            {
                return NotFound();  // Return NotFound if vehicle with the specified ID does not exist
            }

            return NoContent();  // Return NoContent if deletion is successful
        }
    }
}
