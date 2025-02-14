using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using infinitemoto.DTOs;
using infinitemoto.Services;

[ApiController]
[Route("api/companies")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCompanies()
    {
        var companies = await _companyService.GetAllCompanies();
        return Ok(companies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompanyById(int id)
    {
        var company = await _companyService.GetCompanyById(id);
        if (company == null) return NotFound();
        return Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] CompanyRequestDto requestDto)
    {
        var company = await _companyService.CreateCompanyWithEmployees(requestDto);
        return CreatedAtAction(nameof(GetCompanyById), new { id = company.CompanyId }, company);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompany(int id, [FromBody] CompanyRequestDto requestDto)
    {
        var updatedCompany = await _companyService.UpdateCompanyWithEmployees(id, requestDto);
        if (updatedCompany == null) return NotFound();
        return Ok(updatedCompany);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        var success = await _companyService.DeleteCompany(id);
        if (!success) return NotFound();
        return NoContent();
    }
}
