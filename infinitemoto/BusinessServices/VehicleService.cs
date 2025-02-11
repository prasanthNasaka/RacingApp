using infinitemoto.DTOs;
using infinitemoto.LookUps;
using infinitemoto.Models;
using Microsoft.AspNetCore.Mvc;
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
                    FcUpto = v.FcUpto.ToDateTime(TimeOnly.MinValue),
                    EngNumber = v.EngNumber,
                    Make = v.Make,
                    Model = v.Model,
                    Cc = v.Cc,
                    VehicleOf = v.VehicleOf,
                    //VehiclePhoto = v.VehiclePhoto,
                    Status = v.Status.HasValue && v.Status.Value ? EventStatus.active : EventStatus.Inactive
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
                FcUpto = vehicle.FcUpto.ToDateTime(TimeOnly.MinValue),
                EngNumber = vehicle.EngNumber,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Cc = vehicle.Cc,
                VehicleOf = vehicle.VehicleOf,
                // VehiclePhoto = vehicle.VehiclePhoto,
                Status = vehicle.Status.HasValue && vehicle.Status.Value ? EventStatus.active : EventStatus.Inactive
            };
        }

   public async Task AddVehicleAsync(VehicleDTO vehicleDto)
{
    var vehicle = new Vehicle
    {
        RegNumb = vehicleDto.RegNumb,
        ChasisNumb = vehicleDto.ChasisNumb,
        FcUpto = DateOnly.FromDateTime(vehicleDto.FcUpto),
        EngNumber = vehicleDto.EngNumber,
        Make = vehicleDto.Make,
        Model = vehicleDto.Model,
        Cc = vehicleDto.Cc,
        VehicleOf = vehicleDto.VehicleOf,
        Status = vehicleDto.Status == EventStatus.active ? true : (bool?)null
    };

    // ✅ Save vehicle first to generate VehicleId
    _context.Vehicles.Add(vehicle);
    await _context.SaveChangesAsync();

    // ✅ Save vehicle documents if provided
    if (vehicleDto.VehicleDoc != null && vehicleDto.VehicleDoc.Any())
    {
        var vehicleDocs = vehicleDto.VehicleDoc.Select(vd => new VehicleDoc
        {
            DocType = vd.DocType,
            VehicleId = vehicle.VehicleId, // ✅ Associate with the newly created vehicle
            Status = vd.Status.ToString(),
            Validtill = DateOnly.FromDateTime(vd.Validtill),
            DocImage = vd.DocImage != null ? Utils.saveImg(vd.DocImage, "DP") : null
        }).ToList();

        _context.VehicleDocs.AddRange(vehicleDocs);
        await _context.SaveChangesAsync();
    }
}

        public async Task UpdateVehicleAsync([FromForm]int vehicleId, VehicleDTO vehicleDto)
        {
            var vehicle = await _context.Vehicles.FindAsync(vehicleId);
            if (vehicle == null) throw new KeyNotFoundException("Vehicle not found");

            vehicle.RegNumb = vehicleDto.RegNumb;
            vehicle.ChasisNumb = vehicleDto.ChasisNumb;
            vehicle.FcUpto = DateOnly.FromDateTime(vehicleDto.FcUpto);
            vehicle.EngNumber = vehicleDto.EngNumber;
            vehicle.Make = vehicleDto.Make;
            vehicle.Model = vehicleDto.Model;
            vehicle.Cc = vehicleDto.Cc;
            vehicle.VehicleOf = vehicleDto.VehicleOf;
            vehicle.Status = vehicleDto.Status == EventStatus.active ? true : (bool?)null;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteVehicleAsync(int vehicleId)
        {
            var vehicle = await _context.Vehicles.FindAsync(vehicleId);
            if (vehicle == null) throw new KeyNotFoundException("Vehicle not found");

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<VehicleDTO>> SearchVehiclesAsync (string? searchWord, int? vehicleOf = null, bool? status = null)
    {
        var query = _context.Vehicles
                            .Include(v => v.VehicleDoc)  
                            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchWord))
        {
            query = query.Where(v => v.Make.Contains(searchWord) || v.Model.Contains(searchWord) || v.RegNumb.ToString().Contains(searchWord));
        }

        if (vehicleOf.HasValue)
        {
            query = query.Where(v => v.VehicleOf == vehicleOf.Value);
        }

        var vehicles = await query
                            .Select(v => new VehicleDTO
                            {
                                VehicleId = v.VehicleId,
                                RegNumb = v.RegNumb,
                                ChasisNumb = v.ChasisNumb,
                                Make = v.Make,
                                Model = v.Model,
                                VehicleOf = v.VehicleOf,
                                
                            })
                            .ToListAsync();

        return vehicles;
    }

        // public Task AddVehicleAsync(VehicleDTO vehicleDto)
        // {
        //     throw new NotImplementedException();
        // }
    }
}
