using System;
using System.Collections.Generic;

namespace infinitemoto.DTOs;


public interface IEventCategoryCreateDto
{
    int EvtCatId { get; set; }

    string? EvtCategory { get; set; }

    int? NoOfVeh { get; set; }

    string? Status { get; set; }

    int Nooflaps { get; set; }

    int? Entryprice { get; set; }

    int? Wheelertype { get; set; }

    int? EventId { get; set; }
}

public class EventCategoryCreateDto : IEventCategoryCreateDto
{
     public int EvtCatId { get; set; }

    public string? EvtCategory { get; set; }

    public int? NoOfVeh { get; set; }

    public string? Status { get; set; }

    public int Nooflaps { get; set; }

    public int? Entryprice { get; set; }

    public int? Wheelertype { get; set; }

    public int? EventId { get; set; }

}


public interface IEventcategoriesgetDto
{
    int EvtCatId { get; set; }

    string? EvtCategory { get; set; }

    int? NoOfVeh { get; set; }

    string? Status { get; set; }

    int Nooflaps { get; set; }

    int? Entryprice { get; set; }

    int? Wheelertype { get; set; }

    int? EventId { get; set; }
}

public class EventCategorygetDto : IEventcategoriesgetDto
{
    public int EvtCatId { get; set; }

    public string? EvtCategory { get; set; }

    public int? NoOfVeh { get; set; }

    public string? Status { get; set; }

    public int Nooflaps { get; set; }

    public int? Entryprice { get; set; }

    public int? Wheelertype { get; set; }

    public int? EventId { get; set; }
}