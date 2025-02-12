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

        public async Task<IEnumerable<vehicleresDto>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles
                .Select(v => new vehicleresDto
                {
                    VehicleId = v.VehicleId,
                    RegNumb = v.RegNumb,
                    ChasisNumb = v.ChasisNumb,
                    //FcUpto = v.FcUpto.ToDateTime(TimeOnly.MinValue),
                    RcNum = v.RcNum,
                    IcNum = v.IcNum,
                    RcUpto = v.RcUpto,
                    IcUpto = v.IcUpto,
                    EngNumber = v.EngNumber,
                    Make = v.Make,
                    Model = v.Model,
                    Cc = v.Cc,
                    VehicleOf = v.VehicleOf,
                    VehiclePhoto = v.VehiclePhoto,// != null ? Convert.ToBase64String(v.VehiclePhoto) : null, // Convert byte[] to base64 string
                    RcImage = v.RcImage,//!= null ? Convert.ToBase64String(v.RcImage) : null, // Convert byte[] to base64 string
                    InsuranceImage = v.InsuranceImage,// != null ? Convert.ToBase64String(v.InsuranceImage) : null, // Convert byte[] to base64 string
                    //FcImage = v.FcImage,//!= null ? Convert.ToBase64String(v.FcImage) : null, // Convert byte[] to base64 string

                    Status = v.Status.HasValue && v.Status.Value ? EventStatus.active : EventStatus.Inactive
                }).ToListAsync();
        }

        public async Task<vehicleresDto?> GetVehicleByIdAsync(int vehicleId)
        {
            var vehicle = await _context.Vehicles.FindAsync(vehicleId);
            if (vehicle == null)
                return null;

            return new vehicleresDto
            {
                VehicleId = vehicle.VehicleId,
                RegNumb = vehicle.RegNumb,
                ChasisNumb = vehicle.ChasisNumb,
                // FcUpto = vehicle.FcUpto.ToDateTime(TimeOnly.MinValue),
                EngNumber = vehicle.EngNumber,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Cc = vehicle.Cc,
                RcNum = vehicle.RcNum,
                IcNum = vehicle.IcNum,
                RcUpto = vehicle.RcUpto,
                IcUpto = vehicle.IcUpto,
                VehicleOf = vehicle.VehicleOf,
                VehiclePhoto = vehicle.VehiclePhoto,// != null ? Convert.ToBase64String(v.VehiclePhoto) : null, // Convert byte[] to base64 string
                RcImage = vehicle.RcImage,//!= null ? Convert.ToBase64String(v.RcImage) : null, // Convert byte[] to base64 string
                InsuranceImage = vehicle.InsuranceImage,// != null ? Convert.ToBase64String(v.InsuranceImage) : null, // Convert byte[] to base64 string
                //FcImage = vehicle.FcImage//!= null ? Convert.ToBase64String(v.FcImage) : null, // Convert byte[] to base64 string
            };
        }

        public async Task<bool> AddVehicleAsync(VehicleDTO vehicleDto)
        {
            var vehicle = new Vehicle
            {
                RegNumb = vehicleDto.RegNumb,
                ChasisNumb = vehicleDto.ChasisNumb,
                //FcUpto = DateOnly.FromDateTime(vehicleDto.FcUpto),
                EngNumber = vehicleDto.EngNumber,
                Make = vehicleDto.Make,
                Model = vehicleDto.Model,
                Cc = vehicleDto.Cc,
                RcNum = vehicleDto.RcNum,
                IcNum = vehicleDto.IcNum,
                RcUpto = DateOnly.FromDateTime(vehicleDto.RcUpto),
                IcUpto = DateOnly.FromDateTime(vehicleDto.IcUpto),
                VehicleOf = vehicleDto.VehicleOf,
                Status = vehicleDto.Status == EventStatus.active ? true : (bool?)null
            };
            if (vehicleDto.VehiclePhoto != null)
            {
                vehicle.VehiclePhoto = Utils.saveImg(vehicleDto.VehiclePhoto, "VP");
            }
            if (vehicleDto.RcImage != null)
            {
                vehicle.RcImage = Utils.saveImg(vehicleDto.RcImage, "RC");
            }
            if (vehicleDto.InsuranceImage != null)
            {
                vehicle.InsuranceImage = Utils.saveImg(vehicleDto.InsuranceImage, "IC");
            }
            // if (vehicleDto.FcImage != null)
            // {
            //     vehicle.FcImage = Utils.saveImg(vehicleDto.FcImage, "FC");
            // }

            // ✅ Save vehicle first to generate VehicleId
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task UpdateVehicleAsync([FromForm] int vehicleId, VehicleDTO vehicleDto)
        {
            var vehicle = await _context.Vehicles.FindAsync(vehicleId);
            if (vehicle == null) throw new KeyNotFoundException("Vehicle not found");

            vehicle.RegNumb = vehicleDto.RegNumb;
            vehicle.ChasisNumb = vehicleDto.ChasisNumb;
            //vehicle.FcUpto = DateOnly.FromDateTime(vehicleDto.FcUpto);
            vehicle.EngNumber = vehicleDto.EngNumber;
            vehicle.Make = vehicleDto.Make;
            vehicle.Model = vehicleDto.Model;
            vehicle.Cc = vehicleDto.Cc;
            vehicle.RcNum = vehicleDto.RcNum;
            vehicle.IcNum = vehicleDto.IcNum;
            vehicle.RcUpto = DateOnly.FromDateTime(vehicleDto.RcUpto);
            vehicle.IcUpto = DateOnly.FromDateTime(vehicleDto.IcUpto);

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

        public async Task<IEnumerable<vehiclescrDto>> SearchVehiclesAsync(string? searchWord, int? vehicleOf = null)
        {
            var query = _context.Vehicles.AsQueryable();

            // Apply search filters
            if (!string.IsNullOrWhiteSpace(searchWord))
            {
                query = query.Where(v =>
                    v.RegNumb.Contains(searchWord) ||
                    v.ChasisNumb.Contains(searchWord) ||
                    v.EngNumber.Contains(searchWord) ||
                    v.Make.Contains(searchWord) ||
                    v.Model.Contains(searchWord) ||

                    v.Cc.Contains(searchWord)
                );
            }

            if (vehicleOf.HasValue)
            {
                query = query.Where(v => v.VehicleOf == vehicleOf.Value);
            }

            var vehicles = await query
                .Select(v => new vehiclescrDto
                {
                    RegNumb = v.RegNumb,
                    ChasisNumb = v.ChasisNumb,
                    EngNumber = v.EngNumber,
                    Make = v.Make,
                    Model = v.Model,
                    Cc = v.Cc,
                    VehiclePhoto = v.VehiclePhoto, 
                    //VehicleOf = v.VehicleOf
                })
                .ToListAsync();

            return vehicles; 

        }
    }
}

