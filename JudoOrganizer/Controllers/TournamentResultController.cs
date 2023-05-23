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

    [HttpGet(nameof(GetTournamentResult))]
    public async Task<IActionResult> GetTournamentResult(int id)
    {
        try
        {
            var tournamentResult = await _repository.TournamentResult.GetTournamentResultAsync(id);
            return Ok(tournamentResult);
        }
        catch (Exception ex)
        {
            return BadRequest("Tournament result doesn't found");
        }
    }

    [HttpGet(nameof(GetAllTournamentResults))]
    public async Task<IActionResult> GetAllTournamentResults()
    {
        try
        {
            var tournamentResults = await _repository.TournamentResult.GetAllTournamentResultsAsync();
            return Ok(tournamentResults);
        }
        catch (Exception ex)
        {
            return BadRequest("No tournament results found");
        }
    }
    
    [HttpGet(nameof(GetAllMatchResultsForTournamentResult))]
    public async Task<IActionResult> GetAllMatchResultsForTournamentResult(int tournamentResultId)
    {
        try
        {
            var matchResults = await _repository.MatchResult.GetAllMatchResultsForTournamentResultAsync(tournamentResultId);
            return Ok(matchResults);
        }
        catch (Exception ex)
        {
            return BadRequest("No match results found");
        }
    }

    [HttpPost(nameof(CreateTournamentResult))]  
    public async Task<IActionResult> CreateTournamentResult(TournamentResult tournamentResult)
    {
        try
        {
            await _repository.TournamentResult.CreateTournamentResultAsync(tournamentResult);
            return Ok("Tournament result added");
        }
        catch (Exception ex)
        {
            return BadRequest("Tournament result already exists!");
        }
    }  
    [HttpPut(nameof(UpdateTournamentResult))]  
    public async Task<IActionResult> UpdateTournamentResult(TournamentResult tournamentResult)
    {
        try
        {
            await _repository.TournamentResult.UpdateTournamentResultAsync(tournamentResult.Id, tournamentResult);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return BadRequest("Tournament result doesn't found");
        }
    }  
    [HttpDelete(nameof(DeleteTournamentResult))]  
    public async Task<IActionResult> DeleteTournamentResult(int tournamentResultId)
    {
        try
        {
            await _repository.TournamentResult.DeleteTournamentResultAsync(tournamentResultId);
            return Ok("Tournament result deleted");
        }
        catch (Exception ex)
        {
            return BadRequest("Tournament result doesn't found");
        }
    }  
}