using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClubsController : BaseController
{
    public ClubsController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("Club/{id}")]
    public async Task<IActionResult> GetClub(int id)
    {
        try
        {
            var club = await _repository.Club.GetClubAsync(id);
            return Ok(value: club);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllClubs()
    {
        try
        {
            var clubs = await _repository.Club.GetAllClubsAsync();
            return Ok(value: clubs);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
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
            return NotFound("Error!  " + ex.Message);
        }
    }
    
    [HttpGet("Club/{clubId}/Sportsmen")]
    public async Task<IActionResult> GetAllSportsmenForClub(int clubId)
    {
        try
        {
            var sportsmen = await _repository.Sportsman.GetAllSportsmenForClubAsync(clubId);
            return Ok(value: sportsmen);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpPost]  
    public async Task<IActionResult> CreateClub(Club club)
    {
        try
        {
            var clubs = await _repository.Club.GetAllClubsAsync();
            var checkClub = clubs.Any(c =>
                                c.Name == club.Name &&
                                c.CityId == club.CityId &&
                                c.Address == club.Address);
            if (checkClub)
                throw new Exception("Такой клуб уже существует!");
            club.Id = clubs.Count() + 1;
            await _repository.Club.CreateClubAsync(club);
            return CreatedAtAction(nameof(GetClub), new { id = club.Id }, club);
        }
        catch (Exception ex)
        {
            return BadRequest("Error! " + ex.InnerException?.Message);
        }
    }  

    [HttpPut]  
    public async Task<IActionResult> UpdateClub(Club club)
    {
        try
        {
            await _repository.Club.UpdateClubAsync(club.Id, club);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
    [HttpDelete("DeleteClub/{clubId}")]  
    public async Task<IActionResult> DeleteClub(int clubId)
    {
        try
        {
            var coaches = await _repository.Coach.GetAllCoachesForClubAsync(clubId);
            var sportsmen = await _repository.Sportsman.GetAllSportsmenForClubAsync(clubId);
            foreach (var coach in coaches)
            {
                var user = await _repository.User.GetUserAsync(coach.UserId);
                await _repository.User.DeleteUserAsync(user.Id);
                await _repository.Coach.DeleteCoachAsync(coach.Id);
            }

            foreach (var sportsman in sportsmen)
            {
                await _repository.Sportsman.DeleteSportsmanAsync(sportsman.Id);
            }
            
            await _repository.Club.DeleteClubAsync(clubId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Error!" + ex.Message);
        }
    }  
}