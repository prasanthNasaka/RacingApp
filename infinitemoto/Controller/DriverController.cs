using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using infinitemoto.DTOs;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class DriversController : ControllerBase
{
    private readonly DriverService _driverService;

    public DriversController(DriverService driverService)
    {
        _driverService = driverService;
    }

    /// <summary>
    /// Get all drivers
    /// </summary>
    /// <returns>List of all drivers</returns>
    [HttpGet("all")]
    public async Task<IActionResult> GetAllDrivers()
    {
        var drivers = await _driverService.GetAllDriversAsync();
        return Ok(drivers);
    }

    /// <summary>
    /// Get a driver along with their vehicle by ID
    /// </summary>
    /// <param name="driverId">Driver ID</param>
    /// <returns>Driver with vehicle details</returns>
    [HttpGet("with-vehicle/{driverId}")]
    public async Task<IActionResult> GetDriverWithVehicle(int driverId)
    {
        var driverDetails = await _driverService.GetDriverWithVehicleByIdAsync(driverId);

        if (driverDetails == null)
        {
            return NotFound(new { Message = "Driver not found" });
        }

        return Ok(driverDetails);
    }

    /// <summary>
    /// Get a driver by ID
    /// </summary>
    /// <param name="id">Driver ID</param>
    /// <returns>Driver details</returns>
    [HttpGet("single/{id}")]
    public async Task<ActionResult<DriverDto>> GetDriver(int id)
    {
        var driver = await _driverService.GetDriverAsync(id);
        if (driver == null) return NotFound(new { Message = "Driver not found" });

        return Ok(driver);
    }

    /// <summary>
    /// Create a new driver
    /// </summary>
    /// <param name="driverDto">Driver details</param>
    /// <returns>Created driver</returns>
    [HttpPost]
    public async Task<ActionResult<DriverDto>> CreateDriver([FromBody] DriverDto driverDto)
    {
        // Validate input
        if (driverDto == null)
        {
            return BadRequest("Driver data is required.");
        }

        try
        {
            // Call the service layer to create the driver
            var createdDriver = await _driverService.CreateDriverAsync(driverDto);

            // If the driver creation fails (i.e., returns null), respond with a failure
            if (createdDriver == null)
            {
                return BadRequest("Failed to create driver.");
            }

            // If the driver is created successfully, return the result with Created status
            return CreatedAtAction(nameof(GetDriver), new { id = createdDriver.DriverId }, createdDriver);
        }
        catch (Exception ex)
        {
            // Log the exception (you can use a logging framework here)
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }



    /// <summary>
    /// Update an existing driver
    /// </summary>
    /// <param name="id">Driver ID</param>
    /// <param name="driverDto">Updated driver details</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDriver(int id, [FromBody] DriverDto driverDto)
    {
        var updated = await _driverService.UpdateDriverAsync(id, driverDto);
        if (!updated) return NotFound(new { Message = "Driver not found" });

        return NoContent();
    }

    /// <summary>
    /// Delete a driver by ID
    /// </summary>
    /// <param name="id">Driver ID</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDriver(int id)
    {
        var deleted = await _driverService.DeleteDriverAsync(id);
        if (!deleted) return NotFound(new { Message = "Driver not found" });

        return NoContent();
    }
}
