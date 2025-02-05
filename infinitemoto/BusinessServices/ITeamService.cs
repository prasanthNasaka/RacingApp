using infinitemoto.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace infinitemoto.Services
{
    public interface ITeamService
    {
        // Method to add a new team
        Task AddTeamAsync(TeamDTO teamDto);

        // Method to update an existing team
        Task UpdateTeamAsync(int teamId, TeamDTO teamDto);

        // Method to delete a team
        Task DeleteTeamAsync(int teamId);

        // Method to get all teams
        Task<IEnumerable<TeamDTO>> GetAllTeamsAsync();

        // Method to get a team by its ID
        Task<TeamDTO?> GetTeamByIdAsync(int teamId);
    }
}
