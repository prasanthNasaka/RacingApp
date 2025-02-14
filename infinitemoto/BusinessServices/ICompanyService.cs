using infinitemoto.DTOs;
using infinitemoto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICompanyService
{
    Task<List<CompanyResponseDto>> GetAllCompanies();
Task<CompanyResponseDto?> GetCompanyById(int companyId);
    Task<CompanyResponseDto> CreateCompanyWithEmployees(CompanyRequestDto requestDto);
    Task<CompanyResponseDto?> UpdateCompanyWithEmployees(int companyId, CompanyRequestDto requestDto);
    Task<bool> DeleteCompany(int companyId);
}
