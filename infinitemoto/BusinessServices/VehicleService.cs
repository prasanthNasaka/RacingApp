using infinitemoto.DTOs;
using infinitemoto.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        // Get all vehicles
        public async Task<IEnumerable<VehicleDto>> GetAllVehiclesAsync()
        {
            var vehicles = await _context.Vehicles
                .Include(v => v.VehicleOfNavigation) // Load the associated driver details
                .ToListAsync();

            var vehicleDtos = new List<VehicleDto>();
            foreach (var vehicle in vehicles)
            {
                vehicleDtos.Add(new VehicleDto
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
                    Status = vehicle.Status,
                    // VehicleOfNavigation = vehicle.VehicleOfNavigation != null ? new DriverDto
                    // {
                    //     DriverId = vehicle.VehicleOfNavigation.DriverId,
                    //     DriverName = vehicle.VehicleOfNavigation.DriverName,
                    //     // Add other driver properties here
                    // } : null
                });
            }

            return vehicleDtos;
        }

        // Get a vehicle by ID
        public async Task<VehicleDto> GetVehicleByIdAsync(int vehicleId)
        {
            var vehicle = await _context.Vehicles
                .Include(v => v.VehicleOfNavigation)
                .FirstOrDefaultAsync(v => v.VehicleId == vehicleId);

            if (vehicle == null)
            {
                return null;
            }

            return new VehicleDto
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
                Status = vehicle.Status,
                // VehicleOfNavigation = vehicle.VehicleOfNavigation != null ? new DriverDto
                // {
                //     DriverId = vehicle.VehicleOfNavigation.DriverId,
                //     DriverName = vehicle.VehicleOfNavigation.DriverName,
                //     // Add other driver properties here
                // } : null
            };
        }

        // Create a new vehicle
       
        public async Task<IEnumerable<VehicleDto>> CreateVehicleAsync(List<VehicleDto> vehicleDtos, int DriverId)
        {
            var vehicles = new List<Vehicle>();

            // Iterate over each vehicleDto to create a corresponding vehicle object
            foreach (var vehicleDto in vehicleDtos)
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
                    VehicleOf = DriverId,
                    VehiclePhoto = vehicleDto.VehiclePhoto,
                    Status = vehicleDto.Status
                };

                vehicles.Add(vehicle); // Add each created vehicle to the list
            }

            // Add all vehicles to the context at once
            await _context.Vehicles.AddRangeAsync(vehicles);
            await _context.SaveChangesAsync();

            // Set the created IDs in the vehicleDtos
            for (int i = 0; i < vehicleDtos.Count; i++)
            {
                vehicleDtos[i].VehicleId = vehicles[i].VehicleId; // Set the created ID from the saved entity
            }

            return vehicleDtos; // Return the list of created VehicleDtos
        }


        // Update an existing vehicle
        public async Task<bool> UpdateVehicleAsync(int vehicleId, List<VehicleDto> vehicleDtos)
        {
            var vehicle = await _context.Vehicles.FindAsync(vehicleId);
            if (vehicle == null)
            {
                return false;
            }
            foreach (var vehicleDto in vehicleDtos)
            {
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


                _context.Entry(vehicle).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();

            return true;
        }

        // Delete a vehicle
        public async Task<bool> DeleteVehicleAsync(int vehicleId)
        {
            var vehicle = await _context.Vehicles.FindAsync(vehicleId);
            if (vehicle == null)
            {
                return false;
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return true;
        }

        public Task<VehicleDto> CreateVehicleAsync(VehicleDto vehicleDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleDto>> CreateVehicleAsync(List<VehicleDto> vehicleDto)
        {
            throw new NotImplementedException();
        }

        // public Task<IEnumerable<VehicleDto>> CreateVehicleAsync(List<VehicleDto> vehicleDto, int DriverId)
        // {
        //     throw new NotImplementedException();
        // }
    }

    // Get a vehicle by ID
    // public async Task<vehicaldetailsDTO> GetVehicleByIdAsync()
    // {
    //     var vehicle = await _context.Vehicles
    //         .Include(v => v.VehicleOfNavigation)
    //         .FirstOrDefaultAsync(v => v.driverIDd == driverIDd);

    //     if (vehicle == null)
    //     {
    //         return null;
    //     }

    //     return new VehicleDto
    //     {
    //         VehicleId = vehicle.VehicleId,
    //         RegNumb = vehicle.RegNumb,
    //         ChasisNumb = vehicle.ChasisNumb,
    //         FcUpto = vehicle.FcUpto,
    //         EngNumber = vehicle.EngNumber,
    //         Make = vehicle.Make,
    //         Model = vehicle.Model,
    //         Cc = vehicle.Cc,
    //         VehicleOf = vehicle.VehicleOf,
    //         VehiclePhoto = vehicle.VehiclePhoto,
    //         Status = vehicle.Status,
    //         VehicleOfNavigation = vehicle.VehicleOfNavigation != null ? new DriverDto
    //         {
    //             DriverId = vehicle.VehicleOfNavigation.DriverId,
    //             DriverName = vehicle.VehicleOfNavigation.DriverName,
    //             // Add other driver properties here
    //         } : null
    //     };
    // }
}
