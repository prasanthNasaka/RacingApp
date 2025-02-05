using infinitemoto.DTOs;
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
            return await _context.VehicleDocs
                .Select(d => new VehicleDocDTO
                {
                    VehDocId = d.VehDocId,
                    DocType = d.DocType,
                    DocPath = d.DocPath,
                    VehicleId = d.VehicleId,
                    Status = d.Status,
                    Validtill = d.Validtill,
                    RcBookValidTill = d.RcBookValidTill,
                    InsuranceValidTill = d.InsuranceValidTill,
                    FitnessRequired = d.FitnessRequired,
                    FitnessCertificate = d.FitnessCertificate
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
                DocPath = vehicleDoc.DocPath,
                VehicleId = vehicleDoc.VehicleId,
                Status = vehicleDoc.Status,
                Validtill = vehicleDoc.Validtill,
                RcBookValidTill = vehicleDoc.RcBookValidTill,
                InsuranceValidTill = vehicleDoc.InsuranceValidTill,
                FitnessRequired = vehicleDoc.FitnessRequired,
                FitnessCertificate = vehicleDoc.FitnessCertificate
            };
        }

        public async Task AddVehicleDocAsync(VehicleDocDTO vehicleDocDto)
        {
            var vehicleDoc = new VehicleDoc
            {
                DocType = vehicleDocDto.DocType,
                DocPath = vehicleDocDto.DocPath,
                VehicleId = vehicleDocDto.VehicleId,
                Status = vehicleDocDto.Status,
                Validtill = vehicleDocDto.Validtill,
                RcBookValidTill = vehicleDocDto.RcBookValidTill,
                InsuranceValidTill = vehicleDocDto.InsuranceValidTill,
                FitnessRequired = vehicleDocDto.FitnessRequired,
                FitnessCertificate = vehicleDocDto.FitnessCertificate
            };

            _context.VehicleDocs.Add(vehicleDoc);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVehicleDocAsync(int vehicleDocId, VehicleDocDTO vehicleDocDto)
        {
            var vehicleDoc = await _context.VehicleDocs.FindAsync(vehicleDocId);
            if (vehicleDoc == null) throw new KeyNotFoundException("Vehicle document not found");

            vehicleDoc.DocType = vehicleDocDto.DocType;
            vehicleDoc.DocPath = vehicleDocDto.DocPath;
            vehicleDoc.Status = vehicleDocDto.Status;
            vehicleDoc.Validtill = vehicleDocDto.Validtill;
            vehicleDoc.RcBookValidTill = vehicleDocDto.RcBookValidTill;
            vehicleDoc.InsuranceValidTill = vehicleDocDto.InsuranceValidTill;
            vehicleDoc.FitnessRequired = vehicleDocDto.FitnessRequired;
            vehicleDoc.FitnessCertificate = vehicleDocDto.FitnessCertificate;

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
