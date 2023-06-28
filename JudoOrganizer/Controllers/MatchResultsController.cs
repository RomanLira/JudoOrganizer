using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MatchResultsController : BaseController
{
    public MatchResultsController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("MatchResult/{id}")]
    public async Task<IActionResult> GetMatchResult(int id)
    {
        try
        {
            var matchResult = await _repository.MatchResult.GetMatchResultAsync(id);
            return Ok(value: matchResult);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }
    
    [HttpGet("MatchResult/{matchId}")]
    public async Task<IActionResult> GetMatchResultForMatchId(int matchId)
    {
        try
        {
            var matchResult = await _repository.MatchResult.GetMatchResultForMatchIdAsync(matchId);
            return Ok(value: matchResult);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMatchResults()
    {
        try
        {
            var matchResults = await _repository.MatchResult.GetAllMatchResultsAsync();
            return Ok(value: matchResults);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpPost]  
    public async Task<IActionResult> CreateMatchResult(MatchResult matchResult)
    {
        try
        {
            var matchResults = await _repository.MatchResult.GetAllMatchResultsAsync();
            matchResult.Id = matchResults.Count() + 1;
            await _repository.MatchResult.CreateMatchResultAsync(matchResult);
            return CreatedAtAction(nameof(GetMatchResult), new {id=matchResult.Id}, matchResult);
        }
        catch (Exception ex)
        {
            return BadRequest("Error! " + ex.Message);
        }
    }  
    [HttpPut]  
    public async Task<IActionResult> UpdateMatchResult(MatchResult matchResult)
    {
        try
        {
            await _repository.MatchResult.UpdateMatchResultAsync(matchResult.Id, matchResult);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
    [HttpDelete("DeleteMatchResult/{matchResultId}")]  
    public async Task<IActionResult> DeleteMatchResult(int matchResultId)
    {
        try
        {
            await _repository.MatchResult.DeleteMatchResultAsync(matchResultId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
}