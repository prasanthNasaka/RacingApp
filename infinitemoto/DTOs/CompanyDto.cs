namespace infinitemoto.DTOs;


public interface ICompanyRequestDto
{
    string CompanyName { get; set; }
    string? Street { get; set; }
    string? City { get; set; }
    string? State { get; set; }
    int? Zip { get; set; }
    string? Country { get; set; }
    string? Website { get; set; }

    List<EmployeeRequestDto>? Employees { get; set; }
}

public class CompanyRequestDto : ICompanyRequestDto
{
    public string CompanyName { get; set; } = null!;
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public int? Zip { get; set; }
    public string? Country { get; set; }
    public string? Website { get; set; }

    public List<EmployeeRequestDto>? Employees { get; set; }
}


public interface ICompanyResponseDto
{
    int CompanyId { get; set; }
    string CompanyName { get; set; }
    string? City { get; set; }
    string? Country { get; set; }

    List<EmployeeResponseDto>? Employees { get; set; }
}

public class CompanyResponseDto : ICompanyResponseDto
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; } = null!;
    public string? City { get; set; }
    public string? Country { get; set; }

    public List<EmployeeResponseDto>? Employees { get; set; }
}

