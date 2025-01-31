using Microsoft.EntityFrameworkCore;
using infinitemoto.DTOs;
using infinitemoto.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface ITeamService
{
    Task<IEnumerable<TeamDto>> GetTeamsAsync();
    Task<TeamDto> GetTeamAsync(int id);
    Task<TeamDto> CreateTeamAsync(TeamDto teamDto);
    Task<bool> UpdateTeamAsync(int id, TeamDto teamDto);
    Task<bool> DeleteTeamAsync(int id);
}

public class TeamService : ITeamService
{
    private readonly DummyProjectSqlContext _context;

    public TeamService(DummyProjectSqlContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TeamDto>> GetTeamsAsync()
    {
        return await _context.Teams
            .Select(team => new TeamDto
            {
                TeamId = team.TeamId,
                TeamName = team.TeamName,
                Status = team.Status
            })
            .ToListAsync();
    }

    public async Task<TeamDto> GetTeamAsync(int id)
    {
        var team = await _context.Teams.FindAsync(id);
        if (team == null) return null;

        return new TeamDto
        {
            TeamId = team.TeamId,
            TeamName = team.TeamName,
            Status = team.Status
        };
    }

    public async Task<TeamDto> CreateTeamAsync(TeamDto teamDto)
    {
        var team = new Team
        {
            TeamName = teamDto.TeamName,
            Status = teamDto.Status
        };

        _context.Teams.Add(team);
        await _context.SaveChangesAsync();

        teamDto.TeamId = team.TeamId; // Set the ID from the saved entity

        return teamDto;
    }

    public async Task<bool> UpdateTeamAsync(int id, TeamDto teamDto)
    {
        var team = await _context.Teams.FindAsync(id);
        if (team == null) return false;

        team.TeamName = teamDto.TeamName;
        team.Status = teamDto.Status;

        _context.Entry(team).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteTeamAsync(int id)
    {
        var team = await _context.Teams.FindAsync(id);
        if (team == null) return false;

        _context.Teams.Remove(team);
        await _context.SaveChangesAsync();

        return true;
    }
}
