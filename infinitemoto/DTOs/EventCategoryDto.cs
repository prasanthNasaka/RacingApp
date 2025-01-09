using System;
using System.Collections.Generic;

namespace infinitemoto.DTOs;


public interface IEventCategoryDto
{
    int Eventid { get; set; }
    string Eventname { get; set; }
    string Category { get; set; }
    int NumberOfLaps { get; set; }
    int NumberOfParticipants { get; set; }
    decimal EventPrice { get; set; }
}

public class EventCategoryDto : IEventCategoryDto
{
    public int Eventid { get; set; }

    public string Eventname { get; set; } = null!;

    public string Category { get; set; } = null!;

    public int NumberOfLaps { get; set; }

    public int NumberOfParticipants { get; set; }

    public decimal EventPrice { get; set; }
}