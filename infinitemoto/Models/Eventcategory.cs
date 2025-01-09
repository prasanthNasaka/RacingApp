using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace infinitemoto.Models;

public partial class Eventcategory
{
    [Key]
    public int Eventid { get; set; }

    public string Eventname { get; set; } = null!;
    [Required]
    [RegularExpression("^(1600cc|1800cc)$", ErrorMessage = "Value must be '1600cc' or '1800cc'.")]

    public string Category { get; set; } = null!;

    public int NumberOfLaps { get; set; }
[Required]
    [RegularExpression("^(1|2)$", ErrorMessage = "Value must be '1' or '2'.")]
    public int NumberOfParticipants { get; set; }

    public decimal EventPrice { get; set; }
}