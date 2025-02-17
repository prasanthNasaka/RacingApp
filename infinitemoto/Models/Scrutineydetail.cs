using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Scrutineydetail
{
    public int ScrutineydetailsId { get; set; }

    public int ScrutineyruleId { get; set; }

    public string Status { get; set; } = null!;

    public string? Comment { get; set; }

    public int RegId { get; set; }

    public virtual Registration Reg { get; set; } = null!;

    public virtual Scrutinyrule Scrutineyrule { get; set; } = null!;
}
