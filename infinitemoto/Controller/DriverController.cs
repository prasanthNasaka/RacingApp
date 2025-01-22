using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using infinitemoto.DTOs;
using infinitemoto.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[Authorize]

public class DriversController : ControllerBase
{
    private readonly DummyProjectSqlContext _context;

    public DriversController(DummyProjectSqlContext context)
    {
        _context = context;
    }

    // GET: api/Drivers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DriverDto>>> GetDrivers()
    {
        var drivers = await _context.Drivers.ToListAsync();

        var driverDtos = drivers.Select(driver => new DriverDto
        {
            DriverId = driver.DriverId,
            Drivername = driver.Drivername,
            Phone = driver.Phone,
            Email = driver.Email,
            FmsciNumb = driver.FmsciNumb,
            FmsciValidTill = driver.FmsciValidTill?.ToString("dd-MM-yyyy"),
            DlNumb = driver.DlNumb,
            DlValidTill = driver.DlValidTill?.ToString("dd-MM-yyyy"),
            Dob = driver.Dob?.ToString("dd-MM-yyyy"),
            Bloodgroup = driver.Bloodgroup,
            Teammemberof = driver.Teammemberof,
            DriverPhoto = driver.DriverPhoto,
            Status = driver.Status
        }).ToList();

        return Ok(driverDtos);
    }

    // GET: api/Drivers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DriverDto>> GetDriver(int id)
    {
        var driver = await _context.Drivers.Include(d => d.TeammemberofNavigation)
                                           .FirstOrDefaultAsync(d => d.DriverId == id);

        if (driver == null)
        {
            return NotFound();
        }

        var driverDto = new DriverDto
        {
            DriverId = driver.DriverId,
            Drivername = driver.Drivername,
            Phone = driver.Phone,
            Email = driver.Email,
            FmsciNumb = driver.FmsciNumb,
            FmsciValidTill = driver.FmsciValidTill?.ToString("dd-MM-yyyy"),
            DlNumb = driver.DlNumb,
            DlValidTill = driver.DlValidTill?.ToString("dd-MM-yyyy"),
            Dob = driver.Dob?.ToString("dd-MM-yyyy"),
            Bloodgroup = driver.Bloodgroup,
            Teammemberof = driver.Teammemberof,
            DriverPhoto = driver.DriverPhoto,
            Status = driver.Status
        };

        return Ok(driverDto);
    }

    // POST: api/Drivers
    [HttpPost]
    public async Task<ActionResult<DriverDto>> CreateDriver([FromBody] DriverDto driverDto)
    {
        var driver = new Driver
        {
            Drivername = driverDto.Drivername,
            Phone = driverDto.Phone,
            Email = driverDto.Email,
            FmsciNumb = driverDto.FmsciNumb,
            FmsciValidTill = string.IsNullOrEmpty(driverDto.FmsciValidTill) ? (DateOnly?)null : DateOnly.ParseExact(driverDto.FmsciValidTill, "dd-MM-yyyy", null),
            DlNumb = driverDto.DlNumb,
            DlValidTill = string.IsNullOrEmpty(driverDto.DlValidTill) ? (DateOnly?)null : DateOnly.ParseExact(driverDto.DlValidTill, "dd-MM-yyyy", null),
            Dob = string.IsNullOrEmpty(driverDto.Dob) ? (DateOnly?)null : DateOnly.ParseExact(driverDto.Dob, "dd-MM-yyyy", null),
            Bloodgroup = driverDto.Bloodgroup,
            Teammemberof = driverDto.Teammemberof,
            DriverPhoto = driverDto.DriverPhoto,
            Status = driverDto.Status
        };

        _context.Drivers.Add(driver);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDriver), new { id = driver.DriverId }, driverDto);
    }

    // PUT: api/Drivers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDriver(int id, [FromBody] DriverDto driverDto)
    {
        var driver = await _context.Drivers.FindAsync(id);
        if (driver == null)
        {
            return NotFound();
        }

        driver.Drivername = driverDto.Drivername;
        driver.Phone = driverDto.Phone;
        driver.Email = driverDto.Email;
        driver.FmsciNumb = driverDto.FmsciNumb;
        driver.FmsciValidTill = string.IsNullOrEmpty(driverDto.FmsciValidTill) ? (DateOnly?)null : DateOnly.ParseExact(driverDto.FmsciValidTill, "dd-MM-yyyy", null);
        driver.DlNumb = driverDto.DlNumb;
        driver.DlValidTill = string.IsNullOrEmpty(driverDto.DlValidTill) ? (DateOnly?)null : DateOnly.ParseExact(driverDto.DlValidTill, "dd-MM-yyyy", null);
        driver.Dob = string.IsNullOrEmpty(driverDto.Dob) ? (DateOnly?)null : DateOnly.ParseExact(driverDto.Dob, "dd-MM-yyyy", null);
        driver.Bloodgroup = driverDto.Bloodgroup;
        driver.Teammemberof = driverDto.Teammemberof;
        driver.DriverPhoto = driverDto.DriverPhoto;
        driver.Status = driverDto.Status;

        _context.Entry(driver).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Drivers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDriver(int id)
    {
        var driver = await _context.Drivers.FindAsync(id);
        if (driver == null)
        {
            return NotFound();
        }

        _context.Drivers.Remove(driver);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
