using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using infinitemoto.DTOs;
using infinitemoto.Services; // Ensure the correct namespace for IDriverService

[Route("api/drivers")]
[ApiController]
public class DriversController : ControllerBase
{
    private readonly IDriverService _driverService;

    public DriversController(IDriverService driverService)
    {
        _driverService = driverService;
    }

    [HttpGet]
    public async Task<IActionResult> GetDrivers()
    {
        var drivers = await _driverService.GetAllDriversAsync();
        return Ok(drivers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDriver(int id)
    {
        var driver = await _driverService.GetDriverByIdAsync(id);
        if (driver == null)
        {
            return NotFound();
        }
        return Ok(driver);
    }

   [HttpPost]
public async Task<IActionResult> AddDriver([FromBody] DriverDTO driverDto)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    try
    {
        var result = await _driverService.AddDriverAsync(driverDto);
        if (!result)
        {
            return StatusCode(500, "Error adding driver.");
        }
        return CreatedAtAction(nameof(GetDriver), new { id = driverDto.DriverId }, driverDto);
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Internal Server Error: {ex.Message}");
    }
}


    [HttpPut("{id}")]
public async Task<IActionResult> UpdateDriver(int id, [FromBody] DriverDTO driverDto)
{
    if (id != driverDto.DriverId)
    {
        return BadRequest("Driver ID mismatch.");
    }

    try
    {
        // Update the driver in the service layer and check for success
        var result = await _driverService.UpdateDriverAsync(id, driverDto);

        // If the update failed, return NotFound or a custom message
        if (!result)
        {
            return NotFound($"Driver with ID {id} not found.");
        }

        // If the update was successful, return NoContent to indicate successful update
        return NoContent();
    }
    catch (Exception ex)
    {
        // Catch any errors and return an Internal Server Error
        return StatusCode(500, $"Internal Server Error: {ex.Message}");
    }
}

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDriver(int id)
    {
        try
        {
            var driverExists = await _driverService.GetDriverByIdAsync(id);
            if (driverExists == null)
            {
                return NotFound();
            }

            await _driverService.DeleteDriverAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }
}
