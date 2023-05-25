using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SportsmanController : BaseController
{
    public SportsmanController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("Sportsman")]
    public async Task<IActionResult> GetSportsman(int id)
    {
        try
        {
            var sportsman = await _repository.Sportsman.GetSportsmanAsync(id);
            return Ok(value: sportsman);
        }
        catch (Exception ex)
        {
            return NotFound("Sportsman doesn't found");
        }
    }

    [HttpGet("Sportsmen")]
    public async Task<IActionResult> GetAllSportsmen()
    {
        try
        {
            var sportsmen = await _repository.Sportsman.GetAllSportsmenAsync();
            return Ok(value: sportsmen);
        }
        catch (Exception ex)
        {
            return NotFound("No sportsmen found");
        }
    }
    
    [HttpGet("Sportsman/{sportsmanId}/Matches")]
    public async Task<IActionResult> GetAllMatchesForSportsman(int sportsmanId)
    {
        try
        {
            var matches = await _repository.Match.GetAllMatchesForSportsmanAsync(sportsmanId);
            return Ok(value: matches);
        }
        catch (Exception ex)
        {
            return NotFound("No matches found");
        }
    }
    
    [HttpGet("Sportsman/{sportsmanId}/MatchResults")]
    public async Task<IActionResult> GetAllMatchResultsForSportsman(int sportsmanId)
    {
        try
        {
            var matchResults = await _repository.MatchResult.GetAllMatchResultsForSportsmanAsync(sportsmanId);
            return Ok(value: matchResults);
        }
        catch (Exception ex)
        {
            return NotFound("No match results found");
        }
    }

    [HttpPost("Sportsman")]  
    public async Task<IActionResult> CreateSportsman(Sportsman sportsman)
    {
        try
        {
            await _repository.Sportsman.CreateSportsmanAsync(sportsman);
            return Created(Url.RouteUrl(sportsman.Id), sportsman);
        }
        catch (Exception ex)
        {
            return BadRequest("Sportsman already exists!");
        }
    }  
    [HttpPut("Sportsman")]  
    public async Task<IActionResult> UpdateSportsman(Sportsman sportsman)
    {
        try
        {
            await _repository.Sportsman.UpdateSportsmanAsync(sportsman.Id, sportsman);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Sportsman doesn't found");
        }
    }  
    [HttpDelete("Sportsman")]  
    public async Task<IActionResult> DeleteSportsman(int sportsmanId)
    {
        try
        {
            await _repository.Sportsman.DeleteSportsmanAsync(sportsmanId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Sportsman doesn't found");
        }
    }  
}