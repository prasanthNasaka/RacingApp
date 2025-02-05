using System;
using System.Collections.Generic;

namespace infinitemoto.DTOs
{
    public interface ITeamDTO
    {
        int TeamId { get; set; }
        string TeamName { get; set; }
        bool Status { get; set; }
        //List<DriverDTO>? Drivers { get; set; }
    }

   public class TeamDTO : ITeamDTO
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; } = null!;
        public bool Status { get; set; }
        //public List<DriverDTO>? Drivers { get; set; } // Optional: Include driver details if needed
    }
    
}
