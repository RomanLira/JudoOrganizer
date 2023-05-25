using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TournamentController : BaseController
{
    public TournamentController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("Tournament")]
    public async Task<IActionResult> GetTournament(int id)
    {
        try
        {
            var tournament = await _repository.Tournament.GetTournamentAsync(id);
            return Ok(value: tournament);
        }
        catch (Exception ex)
        {
            return NotFound("Tournament doesn't found");
        }
    }

    [HttpGet("Tournaments")]
    public async Task<IActionResult> GetAllTournaments()
    {
        try
        {
            var tournaments = await _repository.Tournament.GetAllTournamentsAsync();
            return Ok(value: tournaments);
        }
        catch (Exception ex)
        {
            return NotFound("No tournaments found");
        }
    }
    
    [HttpGet("Tournament/{tournamentId}/SportCategories")]
    public async Task<IActionResult> GetAllSportCategoriesForTournament(int tournamentId)
    {
        try
        {
            var sportCategories = await _repository.SportCategory.GetAllSportCategoriesForTournamentAsync(tournamentId);
            return Ok(value: sportCategories);
        }
        catch (Exception ex)
        {
            return NotFound("No sport categories found");
        }
    }

    [HttpPost("Tournament")]  
    public async Task<IActionResult> CreateTournament(Tournament tournament)
    {
        try
        {
            await _repository.Tournament.CreateTournamentAsync(tournament);
            return Created(Url.RouteUrl(tournament.Id), tournament);
        }
        catch (Exception ex)
        {
            return BadRequest("Tournament already exists!");
        }
    }  
    [HttpPut("Tournament")]  
    public async Task<IActionResult> UpdateTournament(Tournament tournament)
    {
        try
        {
            await _repository.Tournament.UpdateTournamentAsync(tournament.Id, tournament);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Tournament doesn't found");
        }
    }  
    [HttpDelete("Tournament")]  
    public async Task<IActionResult> DeleteTournament(int tournamentId)
    {
        try
        {
            await _repository.Tournament.DeleteTournamentAsync(tournamentId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Tournament doesn't found");
        }
    }  
}