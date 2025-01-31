using System;
using System.Collections.Generic;

namespace infinitemoto.DTOs
{
    public interface ITeamDto
    {
        int TeamId { get; set; }
        string TeamName { get; set; }
        bool Status { get; set; }
        //ICollection<DriverDto> Drivers { get; set; }
    }


    public class TeamDto : ITeamDto
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public bool Status { get; set; }
        //public ICollection<DriverDto> Drivers { get; set; } = new List<DriverDto>();  // If you want to include drivers associated with the team
    }

    // DriverDto to be used inside TeamDto
    
}
