using System;
using System.Collections.Generic;
namespace infinitemoto.DTOs;

public interface IVehicledocDto
{
    int VehDocId { get; set; }
    string? DocType { get; set; }
    string? DocPath { get; set; }
    int? VehicleId { get; set; }
    //VehicleDto? Vehicle { get; set; }
}

public class VehicledocDto : IVehicledocDto
{
    public int VehDocId { get; set; }

    public string? DocType { get; set; }

    public string? DocPath { get; set; }

    public int? VehicleId { get; set; }

   // public virtual VehicleDto? Vehicle { get; set; }
}