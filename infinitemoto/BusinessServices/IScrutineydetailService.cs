using infinitemoto.Models;
using infinitemoto.DTOs;
using Microsoft.EntityFrameworkCore;

namespace infinitemoto.Services
{
    public interface IScrutineydetailService
    {
        Task<IEnumerable<Scrutineydetail>> GetAllScrutineydetailsAsync();
        Task<Scrutineydetail?> GetScrutineydetailByIdAsync(int id);
        Task<Scrutineydetail> CreateScrutineydetailAsync(ScrutineydetailreqDto dto);
        Task<Scrutineydetail?> UpdateScrutineydetailAsync(int id, ScrutineydetailreqDto dto);
        Task<bool> DeleteScrutineydetailAsync(int id);
    }
}