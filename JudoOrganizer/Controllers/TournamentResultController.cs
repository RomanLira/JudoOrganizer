using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TournamentResultController : BaseController
{
    public TournamentResultController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("TournamentResult")]
    public async Task<IActionResult> GetTournamentResult(int id)
    {
        try
        {
            var tournamentResult = await _repository.TournamentResult.GetTournamentResultAsync(id);
            return Ok(value: tournamentResult);
        }
        catch (Exception ex)
        {
            return NotFound("Tournament result doesn't found");
        }
    }

    [HttpGet("TournamentResults")]
    public async Task<IActionResult> GetAllTournamentResults()
    {
        try
        {
            var tournamentResults = await _repository.TournamentResult.GetAllTournamentResultsAsync();
            return Ok(value: tournamentResults);
        }
        catch (Exception ex)
        {
            return NotFound("No tournament results found");
        }
    }
    
    [HttpGet("TournamentResult/{tournamentResultId}/MatchResults")]
    public async Task<IActionResult> GetAllMatchResultsForTournamentResult(int tournamentResultId)
    {
        try
        {
            var matchResults = await _repository.MatchResult.GetAllMatchResultsForTournamentResultAsync(tournamentResultId);
            return Ok(value: matchResults);
        }
        catch (Exception ex)
        {
            return NotFound("No match results found");
        }
    }

    [HttpPost("TournamentResult")]  
    public async Task<IActionResult> CreateTournamentResult(TournamentResult tournamentResult)
    {
        try
        {
            await _repository.TournamentResult.CreateTournamentResultAsync(tournamentResult);
            return Created(Url.RouteUrl(tournamentResult.Id), tournamentResult);
        }
        catch (Exception ex)
        {
            return BadRequest("Tournament result already exists!");
        }
    }  
    [HttpPut("TournamentResult")]  
    public async Task<IActionResult> UpdateTournamentResult(TournamentResult tournamentResult)
    {
        try
        {
            await _repository.TournamentResult.UpdateTournamentResultAsync(tournamentResult.Id, tournamentResult);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Tournament result doesn't found");
        }
    }  
    [HttpDelete("TournamentResult")]  
    public async Task<IActionResult> DeleteTournamentResult(int tournamentResultId)
    {
        try
        {
            await _repository.TournamentResult.DeleteTournamentResultAsync(tournamentResultId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Tournament result doesn't found");
        }
    }  
}