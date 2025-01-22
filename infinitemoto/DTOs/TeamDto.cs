using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public interface ITeamDto
{
    int TeamId { get; set; }
    string? TeamName { get; set; }
    bool? Status { get; set; }

     //Team? team { get; set; }

    //ICollection<Driver> Drivers { get; set; }
}

    public partial class TeamDto : ITeamDto
    {
        public int TeamId { get; set; }

        public string? TeamName { get; set; }
 
        public bool? Status { get; set; }

       // public Team? team { get; set; }


       // public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();
    }
