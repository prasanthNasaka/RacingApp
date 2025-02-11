using infinitemoto.DTOs;
using infinitemoto.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
// [Authorize]
public class SearchController : ControllerBase
{
    private readonly IVehicleService _vehicleService;
    private readonly IDriverService _driverService;

    public SearchController(IVehicleService vehicleService, IDriverService driverService)
    {
        _vehicleService = vehicleService;
        _driverService = driverService;
    }

    /// <summary>
    /// Search for vehicles based on filters (license plate or model).
    /// </summary>
    /// <param name="searchWord">License plate or model of the vehicle</param>
    /// <returns>List of matching vehicles</returns>
    [HttpGet("vehicles")]
    public async Task<ActionResult<IEnumerable<VehicleDTO>>> SearchVehicles([FromQuery] string? searchWord)
    {
        var vehicles = await _vehicleService.SearchVehiclesAsync(searchWord);

        if (vehicles == null || !vehicles.Any())
        {
            return NotFound(new { message = "No vehicles found matching the search criteria." });
        }

        return Ok(vehicles);
    }

    /// <summary>
    /// Search for drivers with vehicles based on filters.
    /// </summary>
    /// <param name="searchWord">Driver's name</param>
    /// <returns>List of matching drivers with vehicles</returns>
    [HttpGet("drivers")]
    public async Task<ActionResult<IEnumerable<DriverSrcResDTO>>> SearchDrivers([FromQuery] string? searchWord)
    {
        var drivers = await _driverService.SearchDriversWithVehiclesAsync(searchWord);

        if (drivers == null || !drivers.Any())
        {
            return NotFound(new { message = "No drivers found matching the search criteria." });
        }

        return Ok(drivers);
    }
}
