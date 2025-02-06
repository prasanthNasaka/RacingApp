using infinitemoto.DTOs;
using infinitemoto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDriverService
{
    Task<IEnumerable<Driver>> GetAllDriversAsync();
    Task<Driver> GetDriverByIdAsync(int driverId);
    Task<bool> AddDriverAsync(DriverDTO driverDto);
    Task<bool> UpdateDriverAsync(int id, DriverDTO driverDto);
    Task<bool> DeleteDriverAsync(int driverId);

    Task<IEnumerable<DriverDTO>> SearchDriversWithVehiclesAsync(string? searchWord);
}
