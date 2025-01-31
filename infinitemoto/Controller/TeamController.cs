using Microsoft.AspNetCore.Mvc;
using infinitemoto.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TeamsController : ControllerBase
{
    private readonly ITeamService _teamService;

    public TeamsController(ITeamService teamService)
    {
        _teamService = teamService;
    }

    // GET: api/Teams
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeamDto>>> GetTeams()
    {
        var teams = await _teamService.GetTeamsAsync();
        return Ok(teams);
    }

    // GET: api/Teams/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TeamDto>> GetTeam(int id)
    {
        var team = await _teamService.GetTeamAsync(id);

        if (team == null)
        {
            return NotFound();
        }

        return Ok(team);
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
            var createdTeam = await _teamService.CreateTeamAsync(teamDto);
            return CreatedAtAction(nameof(GetTeam), new { id = createdTeam.TeamId }, createdTeam);
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
            var result = await _teamService.UpdateTeamAsync(id, teamDto);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
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
            var result = await _teamService.DeleteTeamAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
