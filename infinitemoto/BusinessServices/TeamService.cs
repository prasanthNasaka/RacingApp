using Microsoft.EntityFrameworkCore;
using infinitemoto.DTOs;
using infinitemoto.Models;
using System.Threading.Tasks;
using infinitemoto.Services;

public class TeamService : ITeamService
{
    private readonly DummyProjectSqlContext _context;

    public TeamService(DummyProjectSqlContext context)
    {
        _context = context;
    }

    // Create a new team
    public async Task AddTeamAsync(TeamDTO teamDto)
    {
        var team = new Team
        {
            TeamName = teamDto.TeamName,
            Status = teamDto.Status
        };

        _context.Teams.Add(team);
        await _context.SaveChangesAsync();
    }

    // Update an existing team
    public async Task UpdateTeamAsync(int teamId, TeamDTO teamDto)
    {
        var team = await _context.Teams.FindAsync(teamId);
        if (team == null) throw new KeyNotFoundException("Team not found");

        team.TeamName = teamDto.TeamName;
        team.Status = teamDto.Status;

        await _context.SaveChangesAsync();
    }

    // Delete an existing team
    public async Task DeleteTeamAsync(int teamId)
    {
        var team = await _context.Teams.FindAsync(teamId);
        if (team == null) throw new KeyNotFoundException("Team not found");

        _context.Teams.Remove(team);
        await _context.SaveChangesAsync();
    }

    // Get all teams
    public async Task<IEnumerable<TeamDTO>> GetAllTeamsAsync()
    {
        return await _context.Teams
            .Select(t => new TeamDTO
            {
                TeamId = t.TeamId,
                TeamName = t.TeamName,
                Status = t.Status
            })
            .ToListAsync();
    }

    // Get a team by its ID
    public async Task<TeamDTO?> GetTeamByIdAsync(int teamId)
    {
        var team = await _context.Teams
            .FirstOrDefaultAsync(t => t.TeamId == teamId);

        if (team == null)
            return null;

        return new TeamDTO
        {
            TeamId = team.TeamId,
            TeamName = team.TeamName,
            Status = team.Status
        };
    }
}
