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

    [HttpGet(nameof(GetMatchResult))]
    public async Task<IActionResult> GetMatchResult(int id)
    {
        try
        {
            var matchResult = await _repository.MatchResult.GetMatchResultAsync(id);
            return Ok(matchResult);
        }
        catch (Exception ex)
        {
            return BadRequest("Match result doesn't found");
        }
    }

    [HttpGet(nameof(GetAllMatchResults))]
    public async Task<IActionResult> GetAllMatchResults()
    {
        try
        {
            var matchResults = await _repository.MatchResult.GetAllMatchResultsAsync();
            return Ok(matchResults);
        }
        catch (Exception ex)
        {
            return BadRequest("No match results found");
        }
    }

    [HttpPost(nameof(CreateMatchResult))]  
    public async Task<IActionResult> CreateMatchResult(MatchResult matchResult)
    {
        try
        {
            await _repository.MatchResult.CreateMatchResultAsync(matchResult);
            return Ok("Match result added");
        }
        catch (Exception ex)
        {
            return BadRequest("Match result already exists!");
        }
    }  
    [HttpPut(nameof(UpdateMatchResult))]  
    public async Task<IActionResult> UpdateMatchResult(MatchResult matchResult)
    {
        try
        {
            await _repository.MatchResult.UpdateMatchResultAsync(matchResult.Id, matchResult);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return BadRequest("Match result doesn't found");
        }
    }  
    [HttpDelete(nameof(DeleteMatchResult))]  
    public async Task<IActionResult> DeleteMatchResult(int matchResultId)
    {
        try
        {
            await _repository.MatchResult.DeleteMatchResultAsync(matchResultId);
            return Ok("Match result deleted");
        }
        catch (Exception ex)
        {
            return BadRequest("Match result doesn't found");
        }
    }  
}