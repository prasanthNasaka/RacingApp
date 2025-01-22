using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using infinitemoto.DTOs;
using infinitemoto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class VehiclesController : ControllerBase
{
    private readonly DummyProjectSqlContext _context;

    public VehiclesController(DummyProjectSqlContext context)
    {
        _context = context;
    }

    // GET: api/Vehicles
    [HttpGet]
    public async Task<ActionResult<IEnumerable<IVehicleDto>>> GetVehicles()
    {
        var vehicles = await _context.Vehicles.ToListAsync();

        var vehicleDtos = new List<VehicleDto>();
        foreach (var vehicle in vehicles)
        {
            vehicleDtos.Add(new VehicleDto
            {
                VehicleId = vehicle.VehicleId,
                RegNumb = vehicle.RegNumb,
                ChasisNumb = vehicle.ChasisNumb,
                FcUpto = vehicle.FcUpto?.ToString("dd-MM-yyyy"), // Convert DateOnly to string
                EngNumber = vehicle.EngNumber,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Cc = vehicle.Cc,
                VehicleOf = vehicle.VehicleOf,
                VehiclePhoto = vehicle.VehiclePhoto,
                Status = vehicle.Status
            });
        }

        return Ok(vehicleDtos);
    }

    // GET: api/Vehicles/5
    [HttpGet("{id}")]
    public async Task<ActionResult<IVehicleDto>> GetVehicle(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);

        if (vehicle == null)
        {
            return NotFound();
        }

        var vehicleDto = new VehicleDto
        {
            VehicleId = vehicle.VehicleId,
            RegNumb = vehicle.RegNumb,
            ChasisNumb = vehicle.ChasisNumb,
            FcUpto = vehicle.FcUpto?.ToString("dd-MM-yyyy"), // Convert DateOnly to string
            EngNumber = vehicle.EngNumber,
            Make = vehicle.Make,
            Model = vehicle.Model,
            Cc = vehicle.Cc,
            VehicleOf = vehicle.VehicleOf,
            VehiclePhoto = vehicle.VehiclePhoto,
            Status = vehicle.Status
        };

        return Ok(vehicleDto);
    }

    // POST: api/Vehicles
    [HttpPost]
    public async Task<ActionResult<IVehicleDto>> CreateVehicle([FromBody] VehicleDto vehicleDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var vehicle = new Vehicle
            {
                RegNumb = vehicleDto.RegNumb,
                ChasisNumb = vehicleDto.ChasisNumb,
                FcUpto = DateOnly.ParseExact(vehicleDto.FcUpto, "dd-MM-yyyy", null),
                EngNumber = vehicleDto.EngNumber,
                Make = vehicleDto.Make,
                Model = vehicleDto.Model,
                Cc = vehicleDto.Cc,
                VehicleOf = vehicleDto.VehicleOf,
                VehiclePhoto = vehicleDto.VehiclePhoto,
                Status = vehicleDto.Status
            };

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            vehicleDto.VehicleId = vehicle.VehicleId; // Set the ID after saving
            return CreatedAtAction(nameof(GetVehicle), new { id = vehicle.VehicleId }, vehicleDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // PUT: api/Vehicles/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVehicle(int id, [FromBody] VehicleDto vehicleDto)
    {
        if (id != vehicleDto.VehicleId)
        {
            return BadRequest(new { message = "ID mismatch. Ensure the ID in the URL matches the request body." });
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle == null)
        {
            return NotFound(new { message = $"Vehicle with ID {id} not found." });
        }

        try
        {
            vehicle.RegNumb = vehicleDto.RegNumb;
            vehicle.ChasisNumb = vehicleDto.ChasisNumb;
            vehicle.FcUpto = DateOnly.ParseExact(vehicleDto.FcUpto, "dd-MM-yyyy", null);
            vehicle.EngNumber = vehicleDto.EngNumber;
            vehicle.Make = vehicleDto.Make;
            vehicle.Model = vehicleDto.Model;
            vehicle.Cc = vehicleDto.Cc;
            vehicle.VehicleOf = vehicleDto.VehicleOf;
            vehicle.VehiclePhoto = vehicleDto.VehiclePhoto;
            vehicle.Status = vehicleDto.Status;

            _context.Entry(vehicle).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Vehicles.Any(e => e.VehicleId == id))
            {
                return NotFound(new { message = "Vehicle not found or has been deleted." });
            }
            throw;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // DELETE: api/Vehicles/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehicle(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle == null)
        {
            return NotFound();
        }

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
