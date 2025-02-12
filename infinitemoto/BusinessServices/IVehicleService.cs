using infinitemoto.DTOs;
using infinitemoto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace infinitemoto.Services
{
    public interface IVehicleService
    {
       Task<IEnumerable<vehicleresDto>> GetAllVehiclesAsync();
        Task<vehicleresDto?> GetVehicleByIdAsync(int vehicleId);
       
        //Task AddVehicleAsync(VehicleDTO vehicleDto, List<VehicleDocDTO> vehicleDocDto);
        Task<bool> AddVehicleAsync(VehicleDTO vehicleDto);
        Task UpdateVehicleAsync(int vehicleId, VehicleDTO vehicleDto);
        Task DeleteVehicleAsync(int vehicleId);

        //Task<IEnumerable<VehicleDTO>> SearchVehiclesAsync (string? searchWord, int? vehicleOf = null, bool? status = null);
        Task<IEnumerable<vehiclescrDto>> SearchVehiclesAsync(string? searchWord, int? vehicleOf = null);
    }
}
