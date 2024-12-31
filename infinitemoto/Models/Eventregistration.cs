using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace infinitemoto.Models;

public partial class Eventregistration
{
    public int Eventid { get; set; }

    public required string Eventtype { get; set; }

    public string Eventname { get; set; } = null!;

    public DateTime Startdate { get; set; }

    public DateTime Enddate { get; set; }

    [Required]
    [RegularExpression("^(Active|InActive)$", ErrorMessage = "Value must be 'Active' or 'InActive'.")]

    public string Isactive { get; set; }

    public required string Banner { get; set; }

    [Required]
    [RegularExpression("^(Yes|No)$", ErrorMessage = "Value must be 'Yes' or 'No'.")]
    public string Showdashboard { get; set; }
}
