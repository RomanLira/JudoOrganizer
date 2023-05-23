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

    [HttpGet(nameof(GetSportsman))]
    public async Task<IActionResult> GetSportsman(int id)
    {
        try
        {
            var sportsman = await _repository.Sportsman.GetSportsmanAsync(id);
            return Ok(sportsman);
        }
        catch (Exception ex)
        {
            return BadRequest("Sportsman doesn't found");
        }
    }

    [HttpGet(nameof(GetAllSportsmen))]
    public async Task<IActionResult> GetAllSportsmen()
    {
        try
        {
            var sportsmen = await _repository.Sportsman.GetAllSportsmenAsync();
            return Ok(sportsmen);
        }
        catch (Exception ex)
        {
            return BadRequest("No sportsmen found");
        }
    }
    
    [HttpGet(nameof(GetAllMatchesForSportsman))]
    public async Task<IActionResult> GetAllMatchesForSportsman(int sportsmanId)
    {
        try
        {
            var matches = await _repository.Match.GetAllMatchesForSportsmanAsync(sportsmanId);
            return Ok(matches);
        }
        catch (Exception ex)
        {
            return BadRequest("No matches found");
        }
    }
    
    [HttpGet(nameof(GetAllMatchResultsForSportsman))]
    public async Task<IActionResult> GetAllMatchResultsForSportsman(int sportsmanId)
    {
        try
        {
            var matchResults = await _repository.MatchResult.GetAllMatchResultsForSportsmanAsync(sportsmanId);
            return Ok(matchResults);
        }
        catch (Exception ex)
        {
            return BadRequest("No match results found");
        }
    }

    [HttpPost(nameof(CreateSportsman))]  
    public async Task<IActionResult> CreateSportsman(Sportsman sportsman)
    {
        try
        {
            await _repository.Sportsman.CreateSportsmanAsync(sportsman);
            return Ok("Sportsman added");
        }
        catch (Exception ex)
        {
            return BadRequest("Sportsman already exists!");
        }
    }  
    [HttpPut(nameof(UpdateSportsman))]  
    public async Task<IActionResult> UpdateSportsman(Sportsman sportsman)
    {
        try
        {
            await _repository.Sportsman.UpdateSportsmanAsync(sportsman.Id, sportsman);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return BadRequest("Sportsman doesn't found");
        }
    }  
    [HttpDelete(nameof(DeleteSportsman))]  
    public async Task<IActionResult> DeleteSportsman(int sportsmanId)
    {
        try
        {
            await _repository.Sportsman.DeleteSportsmanAsync(sportsmanId);
            return Ok("Sportsman deleted");
        }
        catch (Exception ex)
        {
            return BadRequest("Sportsman doesn't found");
        }
    }  
}