using JudoOrganizer.Data.Enums;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TournamentsController : BaseController
{
    public TournamentsController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("Tournament/{id}")]
    public async Task<IActionResult> GetTournament(int id)
    {
        try
        {
            var tournament = await _repository.Tournament.GetTournamentAsync(id);
            return Ok(value: tournament);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTournaments()
    {
        try
        {
            var tournaments = await _repository.Tournament.GetAllTournamentsAsync();
            return Ok(value: tournaments);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpGet("OpenedRegistration")]
    public async Task<IActionResult> GetAllTournamentsWithOpenedRegistration()
    {
        try
        {
            var tournaments = await _repository.Tournament.GetAllTournamentsWithOpenedRegistrationAsync();
            return Ok(value: tournaments);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
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
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpGet("Tournament/{tournamentId}/Registration/{pageIndex}&{pageSize}")]
    public async Task<IActionResult> GetAllRegistrationsForTournament(int tournamentId, int pageIndex = 1, int pageSize = 10)
    {
        try
        {
            var registrations = await _repository.Registration.GetAllRegistrationsForTournamentWithPaginationAsync(tournamentId, pageIndex, pageSize);
            return Ok(value: registrations);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpPost]  
    public async Task<IActionResult> CreateTournament(Tournament tournament)
    {
        try
        {
            var tournaments = await _repository.Tournament.GetAllTournamentsAsync();
            var checkTournament = tournaments.Any(t =>
                                t.Date == tournament.Date);
            if (checkTournament)
                throw new Exception("В этот день уже состоится турнир!");
            tournament.Id = tournaments.Count() + 1;
            tournament.RegistrationStatus = RegistrationStatus.Opened;
            await _repository.Tournament.CreateTournamentAsync(tournament);
            return CreatedAtAction(nameof(GetTournament), new {id=tournament.Id}, tournament);
        }
        catch (Exception ex)
        {
            return BadRequest("Error! " + ex.Message);
        }
    }  

    [HttpPut]  
    public async Task<IActionResult> UpdateTournament(Tournament tournament)
    {
        try
        {
            await _repository.Tournament.UpdateTournamentAsync(tournament.Id, tournament);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    } 
    
    [HttpPut("ChangeRegistrationStatus/{tournamentId}")]  
    public async Task<IActionResult> UpdateTournamentRegistrationStatus(int tournamentId)
    {
        try
        {
            await _repository.Tournament.UpdateTournamentRegistrationStatusAsync(tournamentId);
            return Ok("Status updated");
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    } 
    
    [HttpDelete("DeleteTournament/{tournamentId}")]  
    public async Task<IActionResult> DeleteTournament(int tournamentId)
    {
        try
        {
            await _repository.Tournament.DeleteTournamentAsync(tournamentId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
}