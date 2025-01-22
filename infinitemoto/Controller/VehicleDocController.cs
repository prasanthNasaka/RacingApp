using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using infinitemoto.Models;
using infinitemoto.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class VehicleDocController : ControllerBase
{
    private readonly DummyProjectSqlContext _context;

    public VehicleDocController(DummyProjectSqlContext context)
    {
        _context = context;
    }

    // GET: api/VehicleDoc
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VehicledocDto>>> GetVehicleDocs()
    {
        var vehicleDocs = await _context.Vehicledocs.Select(vd => new VehicledocDto
        {
            VehDocId = vd.VehDocId,
            DocType = vd.DocType,
            DocPath = vd.DocPath,
            VehicleId = vd.VehicleId
        }).ToListAsync();

        return Ok(vehicleDocs);
    }

    // GET: api/VehicleDoc/5
    [HttpGet("{id}")]
    public async Task<ActionResult<VehicledocDto>> GetVehicleDoc(int id)
    {
        var vehicleDoc = await _context.Vehicledocs.FindAsync(id);

        if (vehicleDoc == null)
        {
            return NotFound(new { message = $"Vehicle document with ID {id} not found." });
        }

        var vehicleDocDto = new VehicledocDto
        {
            VehDocId = vehicleDoc.VehDocId,
            DocType = vehicleDoc.DocType,
            DocPath = vehicleDoc.DocPath,
            VehicleId = vehicleDoc.VehicleId
        };

        return Ok(vehicleDocDto);
    }

    // POST: api/VehicleDoc
    [HttpPost]
    public async Task<ActionResult<VehicledocDto>> CreateVehicleDoc([FromBody] VehicledocDto vehicledocDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { message = "Invalid data.", errors = ModelState });
        }

        var vehicledoc = new Vehicledoc
        {
            DocType = vehicledocDto.DocType,
            DocPath = vehicledocDto.DocPath,
            VehicleId = vehicledocDto.VehicleId
        };

        _context.Vehicledocs.Add(vehicledoc);
        await _context.SaveChangesAsync();

        vehicledocDto.VehDocId = vehicledoc.VehDocId;

        return CreatedAtAction(nameof(GetVehicleDoc), new { id = vehicledoc.VehDocId }, vehicledocDto);
    }

    // PUT: api/VehicleDoc/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVehicleDoc(int id, [FromBody] VehicledocDto vehicledocDto)
    {
        if (id != vehicledocDto.VehDocId)
        {
            return BadRequest(new { message = "ID mismatch. Ensure the ID in the URL matches the request body." });
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(new { message = "Invalid data.", errors = ModelState });
        }

        var vehicleDoc = await _context.Vehicledocs.FindAsync(id);
        if (vehicleDoc == null)
        {
            return NotFound(new { message = $"Vehicle document with ID {id} not found for update." });
        }

        vehicleDoc.DocType = vehicledocDto.DocType;
        vehicleDoc.DocPath = vehicledocDto.DocPath;
        vehicleDoc.VehicleId = vehicledocDto.VehicleId;

        _context.Entry(vehicleDoc).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
            return Ok(new { message = "Vehicle document updated successfully.", data = vehicledocDto });
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Vehicledocs.Any(e => e.VehDocId == id))
            {
                return NotFound(new { message = "Vehicle document not found or has been deleted." });
            }
            return StatusCode(500, new { message = "An error occurred while updating the vehicle document. Please try again." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
        }
    }

    // DELETE: api/VehicleDoc/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehicleDoc(int id)
    {
        var vehicleDoc = await _context.Vehicledocs.FindAsync(id);
        if (vehicleDoc == null)
        {
            return NotFound(new { message = $"Vehicle document with ID {id} not found." });
        }

        _context.Vehicledocs.Remove(vehicleDoc);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
