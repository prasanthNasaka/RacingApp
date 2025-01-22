using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Eventcategory
{
    public int Eventid { get; set; }

    public string Eventname { get; set; } = null!;

    public string Category { get; set; } = null!;

    public int NumberOfLaps { get; set; }

    public int NumberOfParticipants { get; set; }

    public decimal EventPrice { get; set; }
}
