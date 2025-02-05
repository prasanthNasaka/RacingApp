using Microsoft.AspNetCore.Mvc;
using infinitemoto.DTOs;
using infinitemoto.Services;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TeamsController : ControllerBase
{
    private readonly ITeamService _teamService;

    public TeamsController(ITeamService teamService)
    {
        _teamService = teamService;
    }

    // GET: api/teams
    [HttpGet]
    public async Task<IActionResult> GetAllTeams()
    {
        var teams = await _teamService.GetAllTeamsAsync();
        return Ok(teams);
    }

    // GET: api/teams/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeamById(int id)
    {
        var team = await _teamService.GetTeamByIdAsync(id);
        if (team == null)
            return NotFound();

        return Ok(team);
    }

    // POST: api/teams
    [HttpPost]
    public async Task<IActionResult> CreateTeam([FromBody] TeamDTO teamDto)
    {
        if (teamDto == null)
            return BadRequest("Team data is required");

        await _teamService.AddTeamAsync(teamDto);
        return CreatedAtAction(nameof(GetTeamById), new { id = teamDto.TeamId }, teamDto);
    }

    // PUT: api/teams/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeam(int id, [FromBody] TeamDTO teamDto)
    {
        if (teamDto == null)
            return BadRequest("Team data is required");

        await _teamService.UpdateTeamAsync(id, teamDto);
        return NoContent();  // No content to return after successful update
    }

    // DELETE: api/teams/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeam(int id)
    {
        await _teamService.DeleteTeamAsync(id);
        return NoContent();  // Return 204 No Content after successful deletion
    }
}
