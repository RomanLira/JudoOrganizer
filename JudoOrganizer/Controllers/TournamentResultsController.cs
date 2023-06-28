using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TournamentResultsController : BaseController
{
    public TournamentResultsController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("TournamentResult/{id}")]
    public async Task<IActionResult> GetTournamentResult(int id)
    {
        try
        {
            var tournamentResult = await _repository.TournamentResult.GetTournamentResultAsync(id);
            return Ok(value: tournamentResult);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTournamentResults()
    {
        try
        {
            var tournamentResults = await _repository.TournamentResult.GetAllTournamentResultsAsync();
            return Ok(value: tournamentResults);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpPost]  
    public async Task<IActionResult> CreateTournamentResult(TournamentResult tournamentResult)
    {
        try
        {
            var tournamentResults = await _repository.TournamentResult.GetAllTournamentResultsAsync();
            tournamentResult.Id = tournamentResults.Count() + 1;
            await _repository.TournamentResult.CreateTournamentResultAsync(tournamentResult);
            return CreatedAtAction(nameof(GetTournamentResult), new {id=tournamentResult.Id}, tournamentResult);
        }
        catch (Exception ex)
        {
            return BadRequest("Error! " + ex.Message);
        }
    }  

    [HttpPut]  
    public async Task<IActionResult> UpdateTournamentResult(TournamentResult tournamentResult)
    {
        try
        {
            await _repository.TournamentResult.UpdateTournamentResultAsync(tournamentResult.Id, tournamentResult);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
    [HttpDelete("DeleteTournamentResult/{tournamentResultId}")]  
    public async Task<IActionResult> DeleteTournamentResult(int tournamentResultId)
    {
        try
        {
            await _repository.TournamentResult.DeleteTournamentResultAsync(tournamentResultId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
}