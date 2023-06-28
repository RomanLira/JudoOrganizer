using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MatchesController : BaseController
{
    public MatchesController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("Match/{id}")]
    public async Task<IActionResult> GetMatch(int id)
    {
        try
        {
            var match = await _repository.Match.GetMatchAsync(id);
            return Ok(value: match);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMatches()
    {
        try
        {
            var matches = await _repository.Match.GetAllMatchesAsync();
            return Ok(value: matches);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpPost]  
    public async Task<IActionResult> CreateMatch(Match match)
    {
        try
        {
            Random rand = new Random();
            bool flag = false;
            var matches = await _repository.Match.GetAllMatchesAsync();
            while (flag != true)
            {
                int id = rand.Next(1, 1000000);
                if (matches.FirstOrDefault(m => m.Id == id) == null)
                {
                    match.Id = id;
                    flag = true;
                }
            }
            await _repository.Match.CreateMatchAsync(match);
            return CreatedAtAction(nameof(GetMatch), new {id=match.Id}, match);
        }
        catch (Exception ex)
        {
            return BadRequest("Error! " + ex.Message + ex.InnerException);
        }
    } 

    [HttpPut]  
    public async Task<IActionResult> UpdateMatch(Match match)
    {
        try
        {
            await _repository.Match.UpdateMatchAsync(match.Id, match);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
    [HttpDelete("DeleteMatch/{matchId}")]  
    public async Task<IActionResult> DeleteMatch(int matchId)
    {
        try
        {
            await _repository.Match.DeleteMatchAsync(matchId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
}