using infinitemoto.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using infinitemoto.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DriverSearchController : ControllerBase
{
    private readonly DriverService _driverService;

    public DriverSearchController(DriverService driverService)
    {
        _driverService = driverService;
    }

    /// <summary>
    /// Search for drivers with vehicles based on filters
    /// </summary>
    /// <param name="search word">Driver's name</param>
  
    /// <returns>List of matching drivers with vehicles</returns>
    [HttpGet("search Word")]
    public async Task<ActionResult<IEnumerable<DriverDTO>>> SearchDrivers(
        [FromQuery] string? searchWord)
    {
        var drivers = await _driverService.SearchDriversWithVehiclesAsync(searchWord);

        // Check if any drivers were found
        if (drivers == null || !drivers.Any())
        {
            // Return a 404 Not Found response if no drivers are found
            return NotFound(new { message = "No drivers found matching the search criteria." });
        }



        return Ok(drivers);
    }
}
