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
            FmsciValidTill =  DateOnly.FromDateTime(driverDto.FmsciValidTill),
            DlNumb = driverDto.DlNumb,
            DlValidTill =  DateOnly.FromDateTime(driverDto.DlValidTill),
            Dob =  DateOnly.FromDateTime(driverDto.Dob),
            Bloodgroup = driverDto.BloodGroup,
            Teammemberof = driverDto.TeamMemberOf,
           // DriverPhoto = driverDto.DriverPhoto,
            Status = driverDto.Status,            
        };
            if(driverDto.DriverPhoto != null)
            {
                driver.DriverPhoto = Utils.saveImg( driverDto.DriverPhoto,"DP");
            }
            if(driverDto.DlPhoto != null)
            {
                driver.DlPhoto = Utils.saveImg( driverDto.DlPhoto,"DL");
            }
            if(driverDto.FmsciLicPhoto != null)
            {
                driver.FmsciLicPhoto = Utils.saveImg(driverDto.FmsciLicPhoto,"FM");
            }
        
        _context.Drivers.Add(driver);
        await _context.SaveChangesAsync();
        return true;
    }

    // private string saveImg(IFormFile img, string  ImgFor)
    // {
    //    /// Save image to the server
    //    /// 
    //     string upLoadPath    = Path.Combine(Directory.GetCurrentDirectory(), "Images");
    //     if(!Directory.Exists(upLoadPath))
    //     {
    //        Directory.CreateDirectory(upLoadPath);
    //     }
         
    //     string fileName = ImgFor + "_" + Guid.NewGuid().ToString() + Path.GetExtension(img.FileName);
    //     string filePath = Path.Combine(upLoadPath, fileName);
    //     using(var stream = new FileStream(filePath, FileMode.Create))
    //     {
    //             img.CopyTo(stream);
    //     }
    //     return fileName;
    // }

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
        existingDriver.FmsciValidTill =  DateOnly.FromDateTime( driverDto.FmsciValidTill);
        existingDriver.DlNumb = driverDto.DlNumb;
        existingDriver.DlValidTill =  DateOnly.FromDateTime(driverDto.DlValidTill);
        existingDriver.Dob =  DateOnly.FromDateTime(driverDto.Dob);
        existingDriver.Bloodgroup = driverDto.BloodGroup;
        existingDriver.Teammemberof = driverDto.TeamMemberOf;
        //existingDriver.DriverPhoto = driverDto.DriverPhoto;
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

    public async Task<IEnumerable<DriverSrcResDTO>> SearchDriversWithVehiclesAsync(string? searchWord)
    {
        // Query drivers and include their associated vehicles (if applicable)
        var query = _context.Drivers
                            .Include(d => d.TeammemberofNavigation) // Include the team if needed
                            .AsQueryable();

        // If a search word is provided, filter the drivers by their name
        if (!string.IsNullOrWhiteSpace(searchWord))
        {
            query = query.Where(d => d.Drivername.Contains(searchWord));
        }

        // Execute the query asynchronously and map the results to DTOs
        var drivers = await query
                            .Select(d => new DriverSrcResDTO
                            {
                                DriverId = d.DriverId,
                                DriverName = d.Drivername,
                                Phone = d.Phone,
                               // Email = d.Email,
                                FmsciNumb = d.FmsciNumb,
                                //FmsciValidTill = d.FmsciValidTill,
                                DlNumb = d.DlNumb,
                                DriverPhoto= d.DriverPhoto
                                                        })
                            .ToListAsync();

        return drivers;
    }
    
}
