using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using infinitemoto.DTOs;
using infinitemoto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TeamsController : ControllerBase
{
    private readonly DummyProjectSqlContext _context;

    public TeamsController(DummyProjectSqlContext context)
    {
        _context = context;
    }

    // GET: api/Teams
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeamDto>>> GetTeams()
    {
        var teams = await _context.Teams.Select(team => new TeamDto
        {
            TeamId = team.TeamId,
            TeamName = team.TeamName,
            Status = team.Status
        }).ToListAsync();

        return Ok(teams);
    }

    // GET: api/Teams/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TeamDto>> GetTeam(int id)
    {
        var team = await _context.Teams.FindAsync(id);

        if (team == null)
        {
            return NotFound();
        }

        var teamDto = new TeamDto
        {
            TeamId = team.TeamId,
            TeamName = team.TeamName,
            Status = team.Status
        };

        return Ok(teamDto);
    }

    // POST: api/Teams
    [HttpPost]
    public async Task<ActionResult<TeamDto>> CreateTeam([FromBody] TeamDto teamDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var team = new Team
            {
                TeamName = teamDto.TeamName,
                Status = teamDto.Status
            };

            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            teamDto.TeamId = team.TeamId; // Set the ID from the saved entity

            return CreatedAtAction(nameof(GetTeam), new { id = team.TeamId }, teamDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // PUT: api/Teams/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeam(int id, [FromBody] TeamDto teamDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            team.TeamName = teamDto.TeamName;
            team.Status = teamDto.Status;

            _context.Entry(team).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Teams.Any(e => e.TeamId == id))
            {
                return NotFound();
            }
            throw;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // DELETE: api/Teams/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeam(int id)
    {
        try
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
