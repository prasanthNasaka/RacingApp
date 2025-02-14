namespace infinitemoto.DTOs;


public interface IEmployeeRequestDto
{
    string? EmpName { get; set; }
    string? Email { get; set; }
    int? ComId { get; set; }
    //int? AccId { get; set; }
    int? Phone { get; set; }
    int? Age { get; set; }
    DateTime Dob { get; set; }
    string? Location { get; set; }
}

public class EmployeeRequestDto : IEmployeeRequestDto
{
    public string? EmpName { get; set; }
    public string? Email { get; set; }
    public int? ComId { get; set; }
    //public int? AccId { get; set; }
    public int? Phone { get; set; }
    public int? Age { get; set; }
    public DateTime Dob { get; set; }
    public string? Location { get; set; }
}

public interface IEmployeeResponseDto
{
    int EmpId { get; set; }
    string? EmpName { get; set; }
    string? Email { get; set; }
    int? ComId { get; set; }
}

public class EmployeeResponseDto : IEmployeeResponseDto
{
    public int EmpId { get; set; }
    public string? EmpName { get; set; }
    public string? Email { get; set; }
    public int? ComId { get; set; }
}
