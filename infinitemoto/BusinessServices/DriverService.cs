using infinitemoto.DTOs;
using infinitemoto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DriverService : IDriverService
{
    private readonly DummyProjectSqlContext _context;

    public DriverService(DummyProjectSqlContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Driver>> GetAllDriversAsync()
    {
        return await _context.Drivers.Include(d => d.TeammemberofNavigation).ToListAsync();
    }

    public async Task<Driver> GetDriverByIdAsync(int driverId)
    {
        return await _context.Drivers.Include(d => d.TeammemberofNavigation).FirstOrDefaultAsync(d => d.DriverId == driverId);
    }

    public async Task<bool> AddDriverAsync(DriverDTO driverDto)
    {
        if (string.IsNullOrEmpty(driverDto.DriverName))
        {
            throw new Exception("Driver name is required.");
        }

        if (await _context.Drivers.AnyAsync(d => d.FmsciNumb == driverDto.FmsciNumb))
        {
            throw new Exception("FMSCI Number must be unique.");
        }

        var driver = new Driver
        {
            Drivername = driverDto.DriverName,
            Phone = driverDto.Phone,
            Email = driverDto.Email,
            FmsciNumb = driverDto.FmsciNumb,
            FmsciValidTill = driverDto.FmsciValidTill,
            DlNumb = driverDto.DlNumb,
            DlValidTill = driverDto.DlValidTill,
            Dob = driverDto.Dob,
            Bloodgroup = driverDto.BloodGroup,
            Teammemberof = driverDto.TeamMemberOf,
            DriverPhoto = driverDto.DriverPhoto,
            Status = driverDto.Status
        };

        _context.Drivers.Add(driver);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateDriverAsync(int id, DriverDTO driverDto)
    {
        var existingDriver = await _context.Drivers.FindAsync(id);
        if (existingDriver == null)
        {
            throw new Exception("Driver not found.");
        }

        // Update driver properties from DTO
        existingDriver.Drivername = driverDto.DriverName;
        existingDriver.Phone = driverDto.Phone;
        existingDriver.Email = driverDto.Email;
        existingDriver.FmsciNumb = driverDto.FmsciNumb;
        existingDriver.FmsciValidTill = driverDto.FmsciValidTill;
        existingDriver.DlNumb = driverDto.DlNumb;
        existingDriver.DlValidTill = driverDto.DlValidTill;
        existingDriver.Dob = driverDto.Dob;
        existingDriver.Bloodgroup = driverDto.BloodGroup;
        existingDriver.Teammemberof = driverDto.TeamMemberOf;
        existingDriver.DriverPhoto = driverDto.DriverPhoto;
        existingDriver.Status = driverDto.Status;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteDriverAsync(int driverId)
    {
        var driver = await _context.Drivers.FindAsync(driverId);
        if (driver == null)
        {
            throw new Exception("Driver not found.");
        }

        _context.Drivers.Remove(driver);
        await _context.SaveChangesAsync();
        return true;
    }
}
