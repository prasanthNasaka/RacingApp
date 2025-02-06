using infinitemoto.DTOs;
using infinitemoto.Services;
using infinitemoto.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class VehicleSearchController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehicleSearchController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    /// <summary>
    /// Search for vehicles based on filters (license plate or model).
    /// </summary>
    /// <param name="searchWord">License plate or model of the vehicle</param>
    /// <returns>List of matching vehicles</returns>
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<VehicleDTO>>> SearchVehicles([FromQuery] string? searchWord)
    {
        // Perform the search using the service method
        var vehicles = await _vehicleService.SearchVehiclesAsync(searchWord);

        // Check if any vehicles were found
        if (vehicles == null || !vehicles.Any())
        {
            // Return a 404 Not Found response if no vehicles are found
            return NotFound(new { message = "No vehicles found matching the search criteria." });
        }

        // Return the list of matching vehicles
        return Ok(vehicles);
    }
}
