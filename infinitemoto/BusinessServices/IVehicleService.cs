using infinitemoto.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace infinitemoto.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleDTO>> GetAllVehiclesAsync();
        Task<VehicleDTO?> GetVehicleByIdAsync(int vehicleId);
        Task AddVehicleAsync(VehicleDTO vehicleDto);
        Task UpdateVehicleAsync(int vehicleId, VehicleDTO vehicleDto);
        Task DeleteVehicleAsync(int vehicleId);
    }
}
