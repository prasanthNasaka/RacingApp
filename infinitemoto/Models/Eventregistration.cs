using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Eventregistration
{
    public int Eventid { get; set; }

    public int Eventtype { get; set; }

    public string Eventname { get; set; } = null!;

    public DateOnly Startdate { get; set; }

    public DateOnly Enddate { get; set; }

    public short Isactive { get; set; }

    public short Showdashboard { get; set; }
}
