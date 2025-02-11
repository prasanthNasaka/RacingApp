using infinitemoto.DTOs;
using infinitemoto.LookUps;
using infinitemoto.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infinitemoto.Services
{
    public class VehicleDocService : IVehicleDocService
    {
        private readonly DummyProjectSqlContext _context;

        public VehicleDocService(DummyProjectSqlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleDocDTO>> GetAllVehicleDocsAsync()
        {
            var vehicleDoc = new VehicleDocDTO();
            return await _context.VehicleDocs
                .Select(d => new VehicleDocDTO
                {
                    VehDocId = d.VehDocId,
                    DocType = d.DocType,
                    VehicleId = d.VehicleId,
                    Status = Enum.Parse<EventStatus>(d.Status),
                    Validtill = d.Validtill.ToDateTime(TimeOnly.MinValue),
                }).ToListAsync();
        }

        public async Task<VehicleDocDTO?> GetVehicleDocByIdAsync(int vehicleDocId)
        {
            var vehicleDoc = await _context.VehicleDocs.FindAsync(vehicleDocId);
            if (vehicleDoc == null)
                return null;

            return new VehicleDocDTO
            {
                VehDocId = vehicleDoc.VehDocId,
                DocType = vehicleDoc.DocType,
                VehicleId = vehicleDoc.VehicleId,
                Status = Enum.Parse<EventStatus>(vehicleDoc.Status),
                Validtill = vehicleDoc.Validtill.ToDateTime(TimeOnly.MinValue),
             };
        }

        public async Task AddVehicleDocAsync(VehicleDocDTO vehicleDocDto)
        {
            var vehicleDoc = new VehicleDoc
            {
                DocType = vehicleDocDto.DocType,
                VehicleId = vehicleDocDto.VehicleId,
                Status = vehicleDocDto.Status.ToString(),
                Validtill = DateOnly.FromDateTime(vehicleDocDto.Validtill),
            };
            if(vehicleDocDto.DocImage != null)
            {
                vehicleDoc.DocImage = Utils.saveImg(vehicleDocDto.DocImage, "DP");
            }
       

            _context.VehicleDocs.Add(vehicleDoc);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVehicleDocAsync(int vehicleDocId, VehicleDocDTO vehicleDocDto)
        {
            var vehicleDoc = await _context.VehicleDocs.FindAsync(vehicleDocId);
            if (vehicleDoc == null) throw new KeyNotFoundException("Vehicle document not found");

            vehicleDoc.DocType = vehicleDocDto.DocType;
            vehicleDoc.Status = vehicleDocDto.Status.ToString();
            vehicleDoc.Validtill = DateOnly.FromDateTime(vehicleDocDto.Validtill);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVehicleDocAsync(int vehicleDocId)
        {
            var vehicleDoc = await _context.VehicleDocs.FindAsync(vehicleDocId);
            if (vehicleDoc == null) throw new KeyNotFoundException("Vehicle document not found");

            _context.VehicleDocs.Remove(vehicleDoc);
            await _context.SaveChangesAsync();
        }
    }
    }


