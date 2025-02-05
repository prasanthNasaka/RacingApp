using infinitemoto.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        var drivers = string.Empty; //await _driverService.SearchDriversWithVehiclesAsync(searchWord);
        return Ok(drivers);
    }
}
