using System;
using System.Collections.Generic;

namespace infinitemoto.DTOs;


public interface IEventregistrationReqDto
{
    //int Eventid { get; set; }

    string Eventtype { get; set; }

    string Eventname { get; set; }

    DateTime Startdate { get; set; }

    DateTime Enddate { get; set; }

    string Isactive { get; set; }

    IFormFile Banner { get; set; }

    string Showdashboard { get; set; }

    int? Eventstatus { get; set; }

    string Bankname { get; set; }

    string Ifsccode { get; set; }

    string Accountname { get; set; }
    string Accountnum { get; set; }


    IFormFile Qrpath { get; set; }

    int Companyid { get; set; }
}

public class EventregistrationReqDto : IEventregistrationReqDto
{

     //public int Eventid { get; set; }

    public string Eventtype { get; set; } = null!;

    public string Eventname { get; set; } = null!;

    public DateTime Startdate { get; set; }

    public DateTime Enddate { get; set; }

    public string Isactive { get; set; } = null!;

    public IFormFile Banner { get; set; } = null!;

    public string Showdashboard { get; set; } = null!;

    public int? Eventstatus { get; set; }

    public string Bankname { get; set; } = null!;

    public string Ifsccode { get; set; } = null!;

    public string Accountname { get; set; } = null!;

    public string Accountnum { get; set; } = null!;


    public IFormFile Qrpath { get; set; } = null!;

    public int Companyid { get; set; }
    
}

public interface IEventregistrationResDto
{
    int Eventid { get; set; }

    string Eventtype { get; set; }

    string Eventname { get; set; }

    DateTime Startdate { get; set; }

    DateTime Enddate { get; set; }

    string Isactive { get; set; }

    string Banner { get; set; }

    string Showdashboard { get; set; }

    int? Eventstatus { get; set; }

    string Bankname { get; set; }

    string Ifsccode { get; set; }

    string Accountname { get; set; }
    string Accountnum { get; set; }


    string Qrpath { get; set; }

    int Companyid { get; set; }
}

public class EventregistrationResDto : IEventregistrationResDto
{

     public int Eventid { get; set; }

    public string Eventtype { get; set; } = null!;

    public string Eventname { get; set; } = null!;

    public DateTime Startdate { get; set; }

    public DateTime Enddate { get; set; }

    public string Isactive { get; set; } = null!;

    public string Banner { get; set; } = null!;

    public string Showdashboard { get; set; } = null!;

    public int? Eventstatus { get; set; }

    public string Bankname { get; set; } = null!;

    public string Ifsccode { get; set; } = null!;

    public string Accountname { get; set; } = null!;

    public string Accountnum { get; set; } = null!;


    public string Qrpath { get; set; } = null!;

    public int Companyid { get; set; }
    
}
