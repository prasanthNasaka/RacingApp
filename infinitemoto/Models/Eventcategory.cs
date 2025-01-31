using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Eventcategory
{
    public int EvtCatId { get; set; }

    public int? EvtCategory { get; set; }

    public int? NoOfParticipants { get; set; }

    public string? Status { get; set; }

    public virtual Eventregistration? EvtCategoryNavigation { get; set; }
}
