using infinitemoto.DTOs;
using infinitemoto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CompanyService : ICompanyService
{
    private readonly DummyProjectSqlContext _context;

    public CompanyService(DummyProjectSqlContext context)
    {
        _context = context;
    }

    public async Task<List<CompanyResponseDto>> GetAllCompanies()
    {
        return await _context.Companies
            .Include(c => c.Employees) // Include employees in response
            .Select(c => new CompanyResponseDto
            {
                CompanyId = c.CompanyId,
                CompanyName = c.CompanyName,
                City = c.City,
                Country = c.Country,
                Employees = c.Employees.Select(e => new EmployeeResponseDto
                {
                    EmpId = e.EmpId,
                    EmpName = e.EmpName,
                    Email = e.Email
                }).ToList()
            }).ToListAsync();
    }

    public async Task<CompanyResponseDto?> GetCompanyById(int companyId)
    {
        var company = await _context.Companies
            .Include(c => c.Employees) // Include employees
            .FirstOrDefaultAsync(c => c.CompanyId == companyId);

        if (company == null) return null;

        return new CompanyResponseDto
        {
            CompanyId = company.CompanyId,
            CompanyName = company.CompanyName,
            City = company.City,
            Country = company.Country,
            Employees = company.Employees.Select(e => new EmployeeResponseDto
            {
                EmpId = e.EmpId,
                EmpName = e.EmpName,
                Email = e.Email
            }).ToList()
        };
    }

    public async Task<CompanyResponseDto> CreateCompanyWithEmployees(CompanyRequestDto requestDto)
    {
        // Step 1: Create and save the company first
        var company = new Company
        {
            CompanyName = requestDto.CompanyName,
            Street = requestDto.Street,
            City = requestDto.City,
            State = requestDto.State,
            Zip = requestDto.Zip,
            Country = requestDto.Country,
            Website = requestDto.Website
        };

        _context.Companies.Add(company);
        await _context.SaveChangesAsync();

        // Step 2: Use the created company ID to add employees
        if (requestDto.Employees != null && requestDto.Employees.Count > 0)
        {
            var employees = requestDto.Employees.Select(e => new Employee
            {
                EmpName = e.EmpName,
                Email = e.Email,
                //AccId = e.AccId,
                Phone = e.Phone,
                Age = e.Age,
                Dob = DateOnly.FromDateTime(e.Dob),
                Location = e.Location,
                ComId = company.CompanyId // Link employee to the newly created company
            }).ToList();

            _context.Employees.AddRange(employees);
            await _context.SaveChangesAsync();
        }

        return await GetCompanyById(company.CompanyId);
    }

    public async Task<CompanyResponseDto?> UpdateCompanyWithEmployees(int companyId, CompanyRequestDto requestDto)
    {
        var company = await _context.Companies.Include(c => c.Employees).FirstOrDefaultAsync(c => c.CompanyId == companyId);
        if (company == null) return null;

        // Update company details
        company.CompanyName = requestDto.CompanyName;
        company.Street = requestDto.Street;
        company.City = requestDto.City;
        company.State = requestDto.State;
        company.Zip = requestDto.Zip;
        company.Country = requestDto.Country;
        company.Website = requestDto.Website;

        // Remove existing employees and add new ones
        // company.Employees.Clear();
        // var newEmployees = requestDto.Employees?.Select(e => new Employee
        // {
        //     EmpName = e.EmpName,
        //     Email = e.Email,
        //     AccId = e.AccId,
        //     Phone = e.Phone,
        //     Age = e.Age,
        //     Dob = e.Dob,
        //     Location = e.Location,
        //     ComId = company.CompanyId
        // }) ?? new List<Employee>();

        // foreach (var employee in newEmployees)
        // {
        //     company.Employees.Add(employee);
        // }

        await _context.SaveChangesAsync();
        return await GetCompanyById(company.CompanyId);
    }

    public async Task<bool> DeleteCompany(int companyId)
    {
        var company = await _context.Companies.Include(c => c.Employees).FirstOrDefaultAsync(c => c.CompanyId == companyId);
        if (company == null) return false;

        // Remove employees first (if they exist)
        if (company.Employees.Any())
        {
            _context.Employees.RemoveRange(company.Employees);
        }

        // Remove company
        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();
        return true;
    }
}
