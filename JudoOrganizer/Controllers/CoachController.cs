using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoachController : BaseController
{
    public CoachController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("Coach")]
    public async Task<IActionResult> GetCoach(int id)
    {
        try
        {
            var coach = await _repository.Coach.GetCoachAsync(id);
            return Ok(value: coach);
        }
        catch (Exception ex)
        {
            return NotFound("Coach doesn't found");
        }
    }

    [HttpGet("Coaches")]
    public async Task<IActionResult> GetAllCoaches()
    {
        try
        {
            var coaches = await _repository.Coach.GetAllCoachesAsync();
            return Ok(value: coaches);
        }
        catch (Exception ex)
        {
            return NotFound("No coaches found");
        }
    }
    
    [HttpGet("Coach/{coachId}/Sportsmen")]
    public async Task<IActionResult> GetAllSportsmenForCoach(int coachId)
    {
        try
        {
            var sportsmen = await _repository.Sportsman.GetAllSportsmenForCoachAsync(coachId);
            return Ok(value: sportsmen);
        }
        catch (Exception ex)
        {
            return NotFound("No sportsmen found");
        }
    }

    [HttpPost("Coach")]  
    public async Task<IActionResult> CreateCoach(Coach coach)
    {
        try
        {
            await _repository.Coach.CreateCoachAsync(coach);
            return Created(Url.RouteUrl(coach.Id), coach);
        }
        catch (Exception ex)
        {
            return BadRequest("Coach already exists!");
        }
    }  
    [HttpPut("Coach")]  
    public async Task<IActionResult> UpdateCoach(Coach coach)
    {
        try
        {
            await _repository.Coach.UpdateCoachAsync(coach.Id, coach);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Coach doesn't found");
        }
    }  
    [HttpDelete("Coach")]  
    public async Task<IActionResult> DeleteCoach(int coachId)
    {
        try
        {
            await _repository.Coach.DeleteCoachAsync(coachId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Coach doesn't found");
        }
    }  
}