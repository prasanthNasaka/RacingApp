using infinitemoto.DTOs;
using infinitemoto.Models;
using Microsoft.EntityFrameworkCore;

namespace infinitemoto.Services
{
    public class ScrutineerService : IScrutineerService
    {
        private readonly DummyProjectSqlContext _context;

        public ScrutineerService(DummyProjectSqlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ScrutineerresDto>> GetAllScrutineersAsync()
        {
            return await _context.Scrutineers
                .Select(s => new ScrutineerresDto
                {
                    ScrutineerId = s.ScrutineerId,
                    ScrutineerName = s.ScrutineerName
                })
                .ToListAsync();
        }

        public async Task<ScrutineerresDto?> GetScrutineerByIdAsync(int id)
        {
            var scrutineer = await _context.Scrutineers.FindAsync(id);
            if (scrutineer == null) return null;

            return new ScrutineerresDto
            {
                ScrutineerId = scrutineer.ScrutineerId,
                ScrutineerName = scrutineer.ScrutineerName
            };
        }

        public async Task<ScrutineerresDto> CreateScrutineerAsync(ScrutineerreqDto dto)
        {
            var newScrutineer = new Scrutineer
            {
                ScrutineerName = dto.ScrutineerName
            };

            _context.Scrutineers.Add(newScrutineer);
            await _context.SaveChangesAsync();

            return new ScrutineerresDto
            {
                ScrutineerId = newScrutineer.ScrutineerId,
                ScrutineerName = newScrutineer.ScrutineerName
            };
        }

        public async Task<ScrutineerresDto?> UpdateScrutineerAsync(int id, ScrutineerreqDto dto)
        {
            var existingScrutineer = await _context.Scrutineers.FindAsync(id);
            if (existingScrutineer == null) return null;

            // Update values
            existingScrutineer.ScrutineerName = dto.ScrutineerName;

            await _context.SaveChangesAsync();

            return new ScrutineerresDto
            {
                ScrutineerId = existingScrutineer.ScrutineerId,
                ScrutineerName = existingScrutineer.ScrutineerName
            };
        }


        public async Task<bool> DeleteScrutineerAsync(int id)
        {
            var scrutineer = await _context.Scrutineers.FindAsync(id);
            if (scrutineer == null) return false;

            _context.Scrutineers.Remove(scrutineer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
