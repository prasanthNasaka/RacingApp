using infinitemoto.Models;
using infinitemoto.DTOs;
using Microsoft.EntityFrameworkCore;

namespace infinitemoto.Services
{
   

    public class ScrutineydetailService : IScrutineydetailService
    {
        private readonly DummyProjectSqlContext _context;

        public ScrutineydetailService(DummyProjectSqlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Scrutineydetail>> GetAllScrutineydetailsAsync()
        {
            return await _context.Scrutineydetails.Include(s => s.Reg).Include(s => s.Scrutineyrule).ToListAsync();
        }

        public async Task<Scrutineydetail?> GetScrutineydetailByIdAsync(int id)
        {
            return await _context.Scrutineydetails
                .Include(s => s.Reg)
                .Include(s => s.Scrutineyrule)
                .FirstOrDefaultAsync(s => s.ScrutineydetailsId == id);
        }

        public async Task<Scrutineydetail> CreateScrutineydetailAsync(ScrutineydetailreqDto dto)
        {
            // Validate RegId and ScrutineyruleId before inserting
            var regExists = await _context.Registrations.AnyAsync(r => r.RegId == dto.RegId);
            var ruleExists = await _context.Scrutinyrules.AnyAsync(r => r.ScrutinyrulesId == dto.ScrutineyruleId);

            if (!regExists || !ruleExists)
                throw new Exception("Invalid RegId or ScrutineyruleId.");

            var newScrutineydetail = new Scrutineydetail
            {
                ScrutineyruleId = dto.ScrutineyruleId,
                Status = dto.Status,
                Comment = dto.Comment,
                RegId = dto.RegId
            };

            _context.Scrutineydetails.Add(newScrutineydetail);
            await _context.SaveChangesAsync();
            return newScrutineydetail;
        }

         // 🔹 Update Scrutineydetail
        public async Task<Scrutineydetail?> UpdateScrutineydetailAsync(int id, ScrutineydetailreqDto dto)
        {
            var existingScrutineydetail = await _context.Scrutineydetails.FindAsync(id);
            if (existingScrutineydetail == null) return null;

            // Validate foreign keys
            var regExists = await _context.Registrations.AnyAsync(r => r.RegId == dto.RegId);
            var ruleExists = await _context.Scrutinyrules.AnyAsync(r => r.ScrutinyrulesId == dto.ScrutineyruleId);

            if (!regExists || !ruleExists)
                throw new Exception("Invalid RegId or ScrutineyruleId.");

            existingScrutineydetail.ScrutineyruleId = dto.ScrutineyruleId;
            existingScrutineydetail.Status = dto.Status;
            existingScrutineydetail.Comment = dto.Comment;
            existingScrutineydetail.RegId = dto.RegId;

            await _context.SaveChangesAsync();
            return existingScrutineydetail;
        }

        public async Task<bool> DeleteScrutineydetailAsync(int id)
        {
            var scrutineydetail = await _context.Scrutineydetails.FindAsync(id);
            if (scrutineydetail == null) return false;

            _context.Scrutineydetails.Remove(scrutineydetail);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
