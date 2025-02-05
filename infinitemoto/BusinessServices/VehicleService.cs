using infinitemoto.DTOs;
using infinitemoto.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infinitemoto.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly DummyProjectSqlContext _context;

        public VehicleService(DummyProjectSqlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleDTO>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles
                .Select(v => new VehicleDTO
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
                }).ToListAsync();
        }

        public async Task<VehicleDTO?> GetVehicleByIdAsync(int vehicleId)
        {
            var vehicle = await _context.Vehicles.FindAsync(vehicleId);
            if (vehicle == null)
                return null;

            return new VehicleDTO
            {
                VehicleId = vehicle.VehicleId,
                RegNumb = vehicle.RegNumb,
                ChasisNumb = vehicle.ChasisNumb,
                FcUpto = vehicle.FcUpto,
                EngNumber = vehicle.EngNumber,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Cc = vehicle.Cc,
                VehicleOf = vehicle.VehicleOf,
                VehiclePhoto = vehicle.VehiclePhoto,
                Status = vehicle.Status
            };
        }

        public async Task AddVehicleAsync(VehicleDTO vehicleDto)
        {
            var vehicle = new Vehicle
            {
                RegNumb = vehicleDto.RegNumb,
                ChasisNumb = vehicleDto.ChasisNumb,
                FcUpto = vehicleDto.FcUpto,
                EngNumber = vehicleDto.EngNumber,
                Make = vehicleDto.Make,
                Model = vehicleDto.Model,
                Cc = vehicleDto.Cc,
                VehicleOf = vehicleDto.VehicleOf,
                VehiclePhoto = vehicleDto.VehiclePhoto,
                Status = vehicleDto.Status
            };

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVehicleAsync(int vehicleId, VehicleDTO vehicleDto)
        {
            var vehicle = await _context.Vehicles.FindAsync(vehicleId);
            if (vehicle == null) throw new KeyNotFoundException("Vehicle not found");

            vehicle.RegNumb = vehicleDto.RegNumb;
            vehicle.ChasisNumb = vehicleDto.ChasisNumb;
            vehicle.FcUpto = vehicleDto.FcUpto;
            vehicle.EngNumber = vehicleDto.EngNumber;
            vehicle.Make = vehicleDto.Make;
            vehicle.Model = vehicleDto.Model;
            vehicle.Cc = vehicleDto.Cc;
            vehicle.VehicleOf = vehicleDto.VehicleOf;
            vehicle.VehiclePhoto = vehicleDto.VehiclePhoto;
            vehicle.Status = vehicleDto.Status;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteVehicleAsync(int vehicleId)
        {
            var vehicle = await _context.Vehicles.FindAsync(vehicleId);
            if (vehicle == null) throw new KeyNotFoundException("Vehicle not found");

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
        }
    }
}
