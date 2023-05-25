using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClubController : BaseController
{
    public ClubController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("Club")]
    public async Task<IActionResult> GetClub(int id)
    {
        try
        {
            var club = await _repository.Club.GetClubAsync(id);
            return Ok(value: club);
        }
        catch (Exception ex)
        {
            return NotFound("Club doesn't found");
        }
    }

    [HttpGet("Clubs")]
    public async Task<IActionResult> GetAllClubs()
    {
        try
        {
            var clubs = await _repository.Club.GetAllClubsAsync();
            return Ok(value: clubs);
        }
        catch (Exception ex)
        {
            return NotFound("No clubs found");
        }
    }
    
    [HttpGet("Club/{clubId}/Coaches")]
    public async Task<IActionResult> GetAllCoachesForClub(int clubId)
    {
        try
        {
            var coaches = await _repository.Coach.GetAllCoachesForClubAsync(clubId);
            return Ok(value: coaches);
        }
        catch (Exception ex)
        {
            return NotFound("No coaches found");
        }
    }
    
    [HttpGet("Clubs/{clubId}/Sportsmen")]
    public async Task<IActionResult> GetAllSportsmenForClub(int clubId)
    {
        try
        {
            var sportsmen = await _repository.Sportsman.GetAllSportsmenForClubAsync(clubId);
            return Ok(value: sportsmen);
        }
        catch (Exception ex)
        {
            return NotFound("No sportsmen found");
        }
    }

    [HttpPost("Club")]  
    public async Task<IActionResult> CreateClub(Club club)
    {
        try
        {
            await _repository.Club.CreateClubAsync(club);
            return Created(Url.RouteUrl(club.Id), club);
        }
        catch (Exception ex)
        {
            return BadRequest("Club already exists!");
        }
    }  
    [HttpPut("Club")]  
    public async Task<IActionResult> UpdateClub(Club club)
    {
        try
        {
            await _repository.Club.UpdateClubAsync(club.Id, club);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Club doesn't found");
        }
    }  
    [HttpDelete("Club")]  
    public async Task<IActionResult> DeleteClub(int clubId)
    {
        try
        {
            await _repository.Club.DeleteClubAsync(clubId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Club doesn't found");
        }
    }  
}