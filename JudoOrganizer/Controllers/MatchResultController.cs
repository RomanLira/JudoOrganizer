using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MatchResultController : BaseController
{
    public MatchResultController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("MatchResult")]
    public async Task<IActionResult> GetMatchResult(int id)
    {
        try
        {
            var matchResult = await _repository.MatchResult.GetMatchResultAsync(id);
            return Ok(value: matchResult);
        }
        catch (Exception ex)
        {
            return NotFound("Match result doesn't found");
        }
    }

    [HttpGet("MatchResults")]
    public async Task<IActionResult> GetAllMatchResults()
    {
        try
        {
            var matchResults = await _repository.MatchResult.GetAllMatchResultsAsync();
            return Ok(value: matchResults);
        }
        catch (Exception ex)
        {
            return NotFound("No match results found");
        }
    }

    [HttpPost("MatchResult")]  
    public async Task<IActionResult> CreateMatchResult(MatchResult matchResult)
    {
        try
        {
            await _repository.MatchResult.CreateMatchResultAsync(matchResult);
            return Created(Url.RouteUrl(matchResult.Id), matchResult);
        }
        catch (Exception ex)
        {
            return BadRequest("Match result already exists!");
        }
    }  
    [HttpPut("MatchResult")]  
    public async Task<IActionResult> UpdateMatchResult(MatchResult matchResult)
    {
        try
        {
            await _repository.MatchResult.UpdateMatchResultAsync(matchResult.Id, matchResult);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Match result doesn't found");
        }
    }  
    [HttpDelete("MatchResult")]  
    public async Task<IActionResult> DeleteMatchResult(int matchResultId)
    {
        try
        {
            await _repository.MatchResult.DeleteMatchResultAsync(matchResultId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Match result doesn't found");
        }
    }  
}