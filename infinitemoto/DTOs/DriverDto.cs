using System;
using System.Collections.Generic;
using infinitemoto.LookUps;
using infinitemoto.Models;

namespace infinitemoto.DTOs;

public interface IDriverDTO
{
    int DriverId { get; set; }
    string DriverName { get; set; }
    string Phone { get; set; }
    string Email { get; set; }
    string FmsciNumb { get; set; }
    DateTime FmsciValidTill { get; set; }
    string DlNumb { get; set; }
    DateTime DlValidTill { get; set; }
    DateTime Dob { get; set; }
    string BloodGroup { get; set; }
    int TeamMemberOf { get; set; }
    IFormFile DriverPhoto { get; set; }
    IFormFile DlPhoto { get; set; }
    IFormFile FmsciLicPhoto { get; set; }
    bool Status { get; set; }
    string? TeamName { get; set; } // Optional: Include team name for display
   //  List<DriverImgDTO> DriverImg { get; set; }
}

public class DriverDTO : IDriverDTO
{
    public int DriverId { get; set; }
    public string DriverName { get; set; } = null!;
    public string Phone { get; set; } 
    public string Email { get; set; } = null!;
    public string FmsciNumb { get; set; } 
    public DateTime FmsciValidTill { get; set; }
    public string DlNumb { get; set; }
    public DateTime DlValidTill { get; set; }
    public DateTime Dob { get; set; }
    public string BloodGroup { get; set; } = null!;
    public int TeamMemberOf { get; set; }
    public IFormFile DriverPhoto { get; set; } = null!;
    public IFormFile DlPhoto { get; set; } = null!;
    public IFormFile FmsciLicPhoto { get; set; } =  null!;
    public bool Status { get; set; }
    public string? TeamName { get; set; } // Optional: Include team name for display
    // public List<DriverImgDTO> DriverImg { get; set; }
}


public interface IDriverImgDTO
{
   
    string? ImgFor { get; set; }
    IFormFile? Image { get; set; }
}

public class DriverImgDTO : IDriverImgDTO
{
    public string? ImgFor { get; set; }
    public IFormFile? Image { get; set; }
}