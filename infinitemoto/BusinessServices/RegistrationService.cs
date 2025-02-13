using infinitemoto.DTOs;
using infinitemoto.Models;
using Microsoft.EntityFrameworkCore;

namespace infinitemoto.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly DummyProjectSqlContext _context;

        public RegistrationService(DummyProjectSqlContext context)
        {
            _context = context;
        }

        public async Task<RegistrationresDto> CreateRegistrationAsync(RegistrationreqDto dto)
        {
            var registration = new Registration
            {
                VechId = dto.VechId,
                DriverId = dto.DriverId,
                EventId = dto.EventId,
                EventcategoryId = dto.EventcategoryId,
                ContestantNo = dto.ContestantNo,
                AmountPaid = dto.AmountPaid,
                ReferenceNo = dto.ReferenceNo,
                // RaceStatus = dto.RaceStatus,
                // ScrutinyDone = dto.ScrutinyDone.HasValue
                //                                         ? DateTime.SpecifyKind(dto.ScrutinyDone.Value, DateTimeKind.Unspecified)
                //                                         : null,
                // AddDate = dto.AddDate.HasValue
                //                                         ? DateTime.SpecifyKind(dto.AddDate.Value, DateTimeKind.Unspecified)
                //                                         : DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified),
                // AddBy = dto.AddBy,
                // UpdatedBy = dto.UpdatedBy
            };

            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();

            return new RegistrationresDto
            {
                RegId = registration.RegId,
                VechId = registration.VechId,
                DriverId = registration.DriverId,
                EventId = registration.EventId,
                EventcategoryId = registration.EventcategoryId,
                ContestantNo = registration.ContestantNo,
                AmountPaid = registration.AmountPaid,
                ReferenceNo = registration.ReferenceNo,
                // RaceStatus = registration.RaceStatus,
                // ScrutinyDone = registration.ScrutinyDone,
                // AddDate = registration.AddDate,
                // AddBy = registration.AddBy,
                // UpdatedBy = registration.UpdatedBy
            };
        }

        public async Task<IEnumerable<RegistrationresDto>> GetAllRegistrationsAsync()
        {
            var registrations = await _context.Registrations.ToListAsync();

            return registrations.Select(r => new RegistrationresDto
            {
                RegId = r.RegId,
                VechId = r.VechId,
                DriverId = r.DriverId,
                EventId = r.EventId,
                EventcategoryId = r.EventcategoryId,
                ContestantNo = r.ContestantNo,
                AmountPaid = r.AmountPaid,
                ReferenceNo = r.ReferenceNo,
                // RaceStatus = r.RaceStatus,
                // ScrutinyDone = r.ScrutinyDone,
                // AddDate = r.AddDate,
                // AddBy = r.AddBy,
                // UpdatedBy = r.UpdatedBy
            });
        }

        public async Task<RegistrationresDto?> GetRegistrationByIdAsync(int id)
        {
            var registration = await _context.Registrations.FirstOrDefaultAsync(r => r.RegId == id);

            if (registration == null) return null;

            return new RegistrationresDto
            {
                RegId = registration.RegId,
                VechId = registration.VechId,
                DriverId = registration.DriverId,
                EventId = registration.EventId,
                EventcategoryId = registration.EventcategoryId,
                ContestantNo = registration.ContestantNo,
                AmountPaid = registration.AmountPaid,
                ReferenceNo = registration.ReferenceNo,
                // RaceStatus = registration.RaceStatus,
                // ScrutinyDone = registration.ScrutinyDone,
                // AddDate = registration.AddDate,
                // AddBy = registration.AddBy,
                // UpdatedBy = registration.UpdatedBy 
            };
        }
    }
}
