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

    [HttpGet(nameof(GetClub))]
    public async Task<IActionResult> GetClub(int id)
    {
        try
        {
            var club = await _repository.Club.GetClubAsync(id);
            return Ok(club);
        }
        catch (Exception ex)
        {
            return BadRequest("Club doesn't found");
        }
    }

    [HttpGet(nameof(GetAllClubs))]
    public async Task<IActionResult> GetAllClubs()
    {
        try
        {
            var clubs = await _repository.Club.GetAllClubsAsync();
            return Ok(clubs);
        }
        catch (Exception ex)
        {
            return BadRequest("No clubs found");
        }
    }
    
    [HttpGet(nameof(GetAllCoachesForClub))]
    public async Task<IActionResult> GetAllCoachesForClub(int clubId)
    {
        try
        {
            var coaches = await _repository.Coach.GetAllCoachesForClubAsync(clubId);
            return Ok(coaches);
        }
        catch (Exception ex)
        {
            return BadRequest("No coaches found");
        }
    }
    
    [HttpGet(nameof(GetAllSportsmenForClub))]
    public async Task<IActionResult> GetAllSportsmenForClub(int clubId)
    {
        try
        {
            var sportsmen = await _repository.Sportsman.GetAllSportsmenForClubAsync(clubId);
            return Ok(sportsmen);
        }
        catch (Exception ex)
        {
            return BadRequest("No sportsmen found");
        }
    }

    [HttpPost(nameof(CreateClub))]  
    public async Task<IActionResult> CreateClub(Club club)
    {
        try
        {
            await _repository.Club.CreateClubAsync(club);
            return Ok("Club added");
        }
        catch (Exception ex)
        {
            return BadRequest("Club already exists!");
        }
    }  
    [HttpPut(nameof(UpdateClub))]  
    public async Task<IActionResult> UpdateClub(Club club)
    {
        try
        {
            await _repository.Club.UpdateClubAsync(club.Id, club);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return BadRequest("Club doesn't found");
        }
    }  
    [HttpDelete(nameof(DeleteClub))]  
    public async Task<IActionResult> DeleteClub(int clubId)
    {
        try
        {
            await _repository.Club.DeleteClubAsync(clubId);
            return Ok("Club deleted");
        }
        catch (Exception ex)
        {
            return BadRequest("Club doesn't found");
        }
    }  
}