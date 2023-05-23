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

    [HttpGet(nameof(GetTournament))]
    public async Task<IActionResult> GetTournament(int id)
    {
        try
        {
            var tournament = await _repository.Tournament.GetTournamentAsync(id);
            return Ok(tournament);
        }
        catch (Exception ex)
        {
            return BadRequest("Tournament doesn't found");
        }
    }

    [HttpGet(nameof(GetAllTournaments))]
    public async Task<IActionResult> GetAllTournaments()
    {
        try
        {
            var tournaments = await _repository.Tournament.GetAllTournamentsAsync();
            return Ok(tournaments);
        }
        catch (Exception ex)
        {
            return BadRequest("No tournaments found");
        }
    }
    
    [HttpGet(nameof(GetAllSportCategoriesForTournament))]
    public async Task<IActionResult> GetAllSportCategoriesForTournament(int tournamentId)
    {
        try
        {
            var sportCategories = await _repository.SportCategory.GetAllSportCategoriesForTournamentAsync(tournamentId);
            return Ok(sportCategories);
        }
        catch (Exception ex)
        {
            return BadRequest("No sport categories found");
        }
    }

    [HttpPost(nameof(CreateTournament))]  
    public async Task<IActionResult> CreateTournament(Tournament tournament)
    {
        try
        {
            await _repository.Tournament.CreateTournamentAsync(tournament);
            return Ok("Tournament added");
        }
        catch (Exception ex)
        {
            return BadRequest("Tournament already exists!");
        }
    }  
    [HttpPut(nameof(UpdateTournament))]  
    public async Task<IActionResult> UpdateTournament(Tournament tournament)
    {
        try
        {
            await _repository.Tournament.UpdateTournamentAsync(tournament.Id, tournament);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return BadRequest("Tournament doesn't found");
        }
    }  
    [HttpDelete(nameof(DeleteTournament))]  
    public async Task<IActionResult> DeleteTournament(int tournamentId)
    {
        try
        {
            await _repository.Tournament.DeleteTournamentAsync(tournamentId);
            return Ok("Tournament deleted");
        }
        catch (Exception ex)
        {
            return BadRequest("Tournament doesn't found");
        }
    }  
}