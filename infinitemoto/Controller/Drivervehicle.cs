// using Microsoft.AspNetCore.Mvc;
// using infinitemoto.BusinessServices;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// [Route("api/[controller]")]
// [ApiController]
// public class DrivervehicleController : ControllerBase
// {
//     private readonly IDriverService _driverService;

//     public DrivervehicleController(IDriverService driverService)
//     {
//         _driverService = driverService;
//     }

//     /// <summary>
//     /// Get a specific driver along with their vehicle by ID
//     /// </summary>
//     /// <param name="driverId"></param>
//     /// <returns>Driver with Vehicle Details</returns>
//     [HttpGet("{driverId}")]
//     public async Task<IActionResult> GetDriverWithVehicle(int driverId)
//     {
//         var driverDetails = await _driverService.GetDriverWithVehicleByIdAsync(driverId) as Driver;

//         if (driverDetails == null)
//         {
//             return NotFound(new { Message = "Driver not found" });
//         }

//         return Ok(driverDetails);
//     }

//     /// <summary>
//     /// Get all drivers
//     /// </summary>
//     /// <returns>List of all drivers</returns>
//     [HttpGet]
//     public async Task<IActionResult> GetAllDrivers()
//     {
//         var drivers = await _driverService.GetAllDriversAsync();
//         return Ok(drivers);
//     }
// }
