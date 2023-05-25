using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MatchController : BaseController
{
    public MatchController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("Match")]
    public async Task<IActionResult> GetMatch(int id)
    {
        try
        {
            var match = await _repository.Match.GetMatchAsync(id);
            return Ok(value: match);
        }
        catch (Exception ex)
        {
            return NotFound("Match doesn't found");
        }
    }

    [HttpGet("Matches")]
    public async Task<IActionResult> GetAllMatches()
    {
        try
        {
            var matches = await _repository.Match.GetAllMatchesAsync();
            return Ok(value: matches);
        }
        catch (Exception ex)
        {
            return NotFound("No matches found");
        }
    }

    [HttpPost("Match")]  
    public async Task<IActionResult> CreateMatch(Match match)
    {
        try
        {
            await _repository.Match.CreateMatchAsync(match);
            return Created(Url.RouteUrl(match.Id), match);
        }
        catch (Exception ex)
        {
            return BadRequest("Match already exists!");
        }
    }  
    [HttpPut("Match")]  
    public async Task<IActionResult> UpdateMatch(Match match)
    {
        try
        {
            await _repository.Match.UpdateMatchAsync(match.Id, match);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Match doesn't found");
        }
    }  
    [HttpDelete("Match")]  
    public async Task<IActionResult> DeleteMatch(int matchId)
    {
        try
        {
            await _repository.Match.DeleteMatchAsync(matchId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Match doesn't found");
        }
    }  
}