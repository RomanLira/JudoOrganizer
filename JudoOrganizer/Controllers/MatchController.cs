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

    [HttpGet(nameof(GetMatch))]
    public async Task<IActionResult> GetMatch(int id)
    {
        try
        {
            var match = await _repository.Match.GetMatchAsync(id);
            return Ok(match);
        }
        catch (Exception ex)
        {
            return BadRequest("Match doesn't found");
        }
    }

    [HttpGet(nameof(GetAllMatches))]
    public async Task<IActionResult> GetAllMatches()
    {
        try
        {
            var matches = await _repository.Match.GetAllMatchesAsync();
            return Ok(matches);
        }
        catch (Exception ex)
        {
            return BadRequest("No matches found");
        }
    }

    [HttpPost(nameof(CreateMatch))]  
    public async Task<IActionResult> CreateMatch(Match match)
    {
        try
        {
            await _repository.Match.CreateMatchAsync(match);
            return Ok("Match added");
        }
        catch (Exception ex)
        {
            return BadRequest("Match already exists!");
        }
    }  
    [HttpPut(nameof(UpdateMatch))]  
    public async Task<IActionResult> UpdateMatch(Match match)
    {
        try
        {
            await _repository.Match.UpdateMatchAsync(match.Id, match);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return BadRequest("Match doesn't found");
        }
    }  
    [HttpDelete(nameof(DeleteMatch))]  
    public async Task<IActionResult> DeleteMatch(int matchId)
    {
        try
        {
            await _repository.Match.DeleteMatchAsync(matchId);
            return Ok("Match deleted");
        }
        catch (Exception ex)
        {
            return BadRequest("Match doesn't found");
        }
    }  
}