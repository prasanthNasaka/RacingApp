using infinitemoto.DTOs;
using infinitemoto.LookUps;
using infinitemoto.Models;
using infinitemoto.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class DriverService : IDriverService
{
    private readonly DummyProjectSqlContext _context;

    public DriverService(DummyProjectSqlContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DriverDto>> GetDriversAsync()
    {
        var drivers = await _context.Drivers.ToListAsync();
        return drivers.Select(driver => new DriverDto
        {
            DriverId = driver.DriverId,
            Drivername = driver.Drivername,
            Phone = driver.Phone,
            Email = driver.Email,
            FmsciNumb = driver.FmsciNumb,
            FmsciValidTill = driver.FmsciValidTill,
            DlNumb = driver.DlNumb,
            DlValidTill = driver.DlValidTill,
            Dob = driver.Dob,
            Bloodgroup = driver.Bloodgroup,
            Teammemberof = driver.Teammemberof,
            DriverPhoto = driver.DriverPhoto,
            DlPhoto = driver.DlPhoto,
            FmsciLicPhoto = driver.FmsciLicPhoto,
            Status = driver.Status
        }).ToList();
    }

    public async Task<List<DriverDto>> GetAllDriversAsync()
    {
        var drivers = await _context.Drivers.ToListAsync();

        return drivers.Select(driver => new DriverDto
        {
            DriverId = driver.DriverId,
            Drivername = driver.Drivername,
            Phone = driver.Phone,
            Email = driver.Email,
            FmsciNumb = driver.FmsciNumb,
            FmsciValidTill = driver.FmsciValidTill,
            DlNumb = driver.DlNumb,
            DlValidTill = driver.DlValidTill,
            Dob = driver.Dob,
            Bloodgroup = driver.Bloodgroup,
            Teammemberof = driver.Teammemberof,
            DriverPhoto = driver.DriverPhoto,
            DlPhoto = driver.DlPhoto,
            FmsciLicPhoto = driver.FmsciLicPhoto,
            Status = driver.Status
        }).ToList();
    }
    public async Task<DriverDto?> GetDriverAsync(int id)
    {
        var driver = await _context.Drivers.Include(d => d.TeammemberofNavigation)
                                           .FirstOrDefaultAsync(d => d.DriverId == id);
        if (driver == null) return null;

        return new DriverDto
        {
            DriverId = driver.DriverId,
            Drivername = driver.Drivername,
            Phone = driver.Phone,
            Email = driver.Email,
            FmsciNumb = driver.FmsciNumb,
            FmsciValidTill = driver.FmsciValidTill,
            DlNumb = driver.DlNumb,
            DlValidTill = driver.DlValidTill,
            Dob = driver.Dob,
            Bloodgroup = driver.Bloodgroup,
            Teammemberof = driver.Teammemberof,
            DriverPhoto = driver.DriverPhoto,
            DlPhoto = driver.DlPhoto,
            FmsciLicPhoto = driver.FmsciLicPhoto,
            Status = driver.Status
        };
    }

    public async Task<Driver> CreateDriverAsync(DriverDto driverDto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(); // Start a transaction
        try
        {
            // Create Driver first
            var driver = new Driver
            {
                Drivername = driverDto.Drivername,
                Phone = driverDto.Phone,
                Email = driverDto.Email,
                FmsciNumb = driverDto.FmsciNumb,
                FmsciValidTill = driverDto.FmsciValidTill,
                DlNumb = driverDto.DlNumb,
                DlValidTill = driverDto.DlValidTill,
                Dob = driverDto.Dob,
                Bloodgroup = driverDto.Bloodgroup,
                Teammemberof = driverDto.Teammemberof,
                DriverPhoto = driverDto.DriverPhoto,
                DlPhoto = driverDto.DlPhoto,
                FmsciLicPhoto = driverDto.FmsciLicPhoto,
                Status = driverDto.Status
            };

            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync(); // Save driver first to get DriverId

            // Check if there are vehicles to create
            if (driverDto.Vehicles != null && driverDto.Vehicles.Any())
            {
                var vehicles = driverDto.Vehicles.Select(vehicleDto => new Vehicle
                {
                    RegNumb = vehicleDto.RegNumb,
                    ChasisNumb = vehicleDto.ChasisNumb,
                    FcUpto = vehicleDto.FcUpto,
                    EngNumber = vehicleDto.EngNumber,
                    Make = vehicleDto.Make,
                    Model = vehicleDto.Model,
                    Cc = vehicleDto.Cc,
                    VehicleOf = driver.DriverId, // Assign the newly created DriverId
                    VehiclePhoto = vehicleDto.VehiclePhoto,
                    Status = vehicleDto.Status
                }).ToList();

                _context.Vehicles.AddRange(vehicles);
                await _context.SaveChangesAsync();
            }

            await transaction.CommitAsync(); // Commit transaction if everything is successful
            return driver;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(); // Rollback if any error occurs
            throw new Exception("Error while creating driver and vehicles: " + ex.Message);
        }
    }


    public async Task<bool> UpdateDriverAsync(int id, DriverDto driverDto)
    {
        var driver = await _context.Drivers.FindAsync(id);
        if (driver == null) return false;

        driver.Drivername = driverDto.Drivername;
        driver.Phone = driverDto.Phone;
        driver.Email = driverDto.Email;
        driver.FmsciNumb = driverDto.FmsciNumb;
        driver.FmsciValidTill = driverDto.FmsciValidTill;
        driver.DlNumb = driverDto.DlNumb;
        driver.DlValidTill = driverDto.DlValidTill;
        driver.Dob = driverDto.Dob;
        driver.Bloodgroup = driverDto.Bloodgroup;
        driver.Teammemberof = driverDto.Teammemberof;
        driver.DriverPhoto = driverDto.DriverPhoto;
        driver.DlPhoto = driverDto.DlPhoto;
        driver.FmsciLicPhoto = driverDto.FmsciLicPhoto;
        driver.Status = driverDto.Status;

        _context.Entry(driver).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteDriverAsync(int id)
    {
        var driver = await _context.Drivers.FindAsync(id);
        if (driver == null) return false;

        _context.Drivers.Remove(driver);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<vehicaldetailsDTO?> GetDriverWithVehicleByIdAsync(int driverId)
    {
        var driver = await _context.Drivers.Include(d => d.Vehicles)
                                           .FirstOrDefaultAsync(d => d.DriverId == driverId);
        if (driver == null) return null;

        return new vehicaldetailsDTO
        {
            driver = new DriverDto
            {
                DriverId = driver.DriverId,
                Drivername = driver.Drivername,
                Phone = driver.Phone,
                Email = driver.Email,
                FmsciNumb = driver.FmsciNumb,
                FmsciValidTill = driver.FmsciValidTill,
                DlNumb = driver.DlNumb,
                DlValidTill = driver.DlValidTill,
                Dob = driver.Dob,
                Bloodgroup = driver.Bloodgroup,
                Status = driver.Status
            },
            vehicle = driver.Vehicles.Select(v => new VehicleDto
            {
                VehicleId = v.VehicleId,
                RegNumb = v.RegNumb,
                ChasisNumb = v.ChasisNumb,
                FcUpto = v.FcUpto,
                EngNumber = v.EngNumber,
                Make = v.Make,
                Model = v.Model,
                Cc = v.Cc,
                VehiclePhoto = v.VehiclePhoto,
                Status = v.Status
            }).ToList()
        };
    }

    public async Task<IEnumerable<DriverDto>> SearchDriversWithVehiclesAsync(string? searchWord)
    {
        var drivers = await _context.Drivers
            .Where(d => string.IsNullOrEmpty(searchWord) || d.Drivername.Contains(searchWord))
            .Select(d => new DriverDto
            {
                DriverId = d.DriverId,
                Drivername = d.Drivername,
                Vehicles = d.Vehicles.Select(v => new VehicleDto
                {
                    VehicleId = v.VehicleId,
                    RegNumb = v.RegNumb,
                    ChasisNumb = v.ChasisNumb,
                    FcUpto = v.FcUpto,
                    EngNumber = v.EngNumber,
                    Make = v.Make,
                    Model = v.Model,
                    Cc = v.Cc,
                    VehicleOf = v.VehicleOf,
                    VehiclePhoto = v.VehiclePhoto,
                    Status = v.Status
                }).ToList()
            })
            .ToListAsync();

        return drivers;
    }

    Task<SearchResult> IDriverService.SearchDriversWithVehiclesAsync(string query)
    {
        throw new NotImplementedException();
    }

    public Task<List<DriverDto>> SearchDriversAsync(string searchWord)
    {
        throw new NotImplementedException();
    }

    public byte[] DecodeBase64(string base64String)
    {
        try
        {
            return Convert.FromBase64String(base64String);
        }
        catch (FormatException ex)
        {
            // Handle the exception gracefully
            // Log the error or return a default value
            return null;  // or you can return a default byte array
        }
    }
}
