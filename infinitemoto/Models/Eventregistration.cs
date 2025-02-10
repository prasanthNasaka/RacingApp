using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Eventregistration
{
    public int Eventid { get; set; }

    public string Eventtype { get; set; } = null!;

    public string Eventname { get; set; } = null!;

    public DateTime Startdate { get; set; }

    public DateTime Enddate { get; set; }

    public string Banner { get; set; } = null!;

    public int? Eventstatus { get; set; }

    public string Bankname { get; set; } = null!;

    public string Ifsccode { get; set; } = null!;

    public string Accountname { get; set; } = null!;

    public string Qrpath { get; set; } = null!;

    public int Companyid { get; set; }

    public virtual CompanyDetail Company { get; set; } = null!;

    public virtual ICollection<Eventcategory> Eventcategories { get; set; } = new List<Eventcategory>();
}
