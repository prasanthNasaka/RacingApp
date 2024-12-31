using System;
using System.Collections.Generic;

namespace infinitemoto.DTOs;


public interface IEventregistrationDto
{
    int Eventid { get; set; }
    string Eventtype { get; set; }
    string Eventname { get; set; }
    DateTime Startdate { get; set; }
    DateTime Enddate { get; set; }
    string Isactive { get; set; }
    string Banner { get; set; }
    string Showdashboard { get; set; }
}

public class EventregistrationDto : IEventregistrationDto
{
    public int Eventid { get; set; }

    public string Eventtype { get; set; }

    public string Eventname { get; set; } = null!;

    public DateTime Startdate { get; set; }

    public DateTime Enddate { get; set; }

    public string Isactive { get; set; }

    public string Banner { get; set; }

    public string Showdashboard { get; set; }
}
