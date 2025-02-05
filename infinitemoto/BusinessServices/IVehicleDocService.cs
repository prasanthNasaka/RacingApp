using infinitemoto.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace infinitemoto.Services
{
    public interface IVehicleDocService
    {
        Task<IEnumerable<VehicleDocDTO>> GetAllVehicleDocsAsync();
        Task<VehicleDocDTO?> GetVehicleDocByIdAsync(int vehicleDocId);
        Task AddVehicleDocAsync(VehicleDocDTO vehicleDocDto);
        Task UpdateVehicleDocAsync(int vehicleDocId, VehicleDocDTO vehicleDocDto);
        Task DeleteVehicleDocAsync(int vehicleDocId);
    }
}
