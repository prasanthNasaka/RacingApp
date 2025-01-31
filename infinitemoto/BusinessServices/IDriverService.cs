using infinitemoto.DTOs;
using infinitemoto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Services;

public interface IDriverService
{
    Task<IEnumerable<DriverDto>> GetDriversAsync();

Task<Driver> CreateDriverAsync(DriverDto driverDto);
    Task<SearchResult> SearchDriversWithVehiclesAsync(string query);
    //Task<DriverDto?> GetDriverAsync(int id);
    //Task<Driver> CreateDriverAsync(DriverDto driverDto, IFormFile DriverPhotodata, IFormFile dlPhotoData, IFormFile fmsciLicPhotoData);

    //Task<Driver> CreateDriverAsync(DriverDto driverDto, IFormFile DriverPhotodata, IFormFile dlPhotoData, IFormFile fmsciLicPhotoData);

    //Task<Driver> CreateDriverAsync(DriverDto driverDto, IFormFile DriverPhotodata, IFormFile dlPhotoData, IFormFile fmsciLicPhotoData)

    Task<bool> UpdateDriverAsync(int id, DriverDto driverDto);
    Task<bool> DeleteDriverAsync(int id);
    Task<vehicaldetailsDTO?> GetDriverWithVehicleByIdAsync(int driverId);
    Task<List<DriverDto>> GetAllDriversAsync();
    Task<List<DriverDto>> SearchDriversAsync(string searchWord);
    //Task<List<DriverDto>> SearchDriversWithVehiclesAsync(string searchWord);

    
}
