using infinitemoto.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace infinitemoto.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleDto>> GetAllVehiclesAsync();
        Task<VehicleDto> GetVehicleByIdAsync(int vehicleId);
        Task<IEnumerable<VehicleDto>> CreateVehicleAsync(List<VehicleDto> vehicleDto, int DriverId);
        Task<bool> UpdateVehicleAsync(int vehicleId, List<VehicleDto> vehicleDto);
        Task<bool> DeleteVehicleAsync(int vehicleId);
    }

    
}


