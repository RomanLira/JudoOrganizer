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

    [HttpGet(nameof(GetCoach))]
    public async Task<IActionResult> GetCoach(int id)
    {
        try
        {
            var coach = await _repository.Coach.GetCoachAsync(id);
            return Ok(coach);
        }
        catch (Exception ex)
        {
            return BadRequest("Coach doesn't found");
        }
    }

    [HttpGet(nameof(GetAllCoaches))]
    public async Task<IActionResult> GetAllCoaches()
    {
        try
        {
            var coaches = await _repository.Coach.GetAllCoachesAsync();
            return Ok(coaches);
        }
        catch (Exception ex)
        {
            return BadRequest("No coaches found");
        }
    }
    
    [HttpGet(nameof(GetAllSportsmenForCoach))]
    public async Task<IActionResult> GetAllSportsmenForCoach(int coachId)
    {
        try
        {
            var sportsmen = await _repository.Sportsman.GetAllSportsmenForCoachAsync(coachId);
            return Ok(sportsmen);
        }
        catch (Exception ex)
        {
            return BadRequest("No sportsmen found");
        }
    }

    [HttpPost(nameof(CreateCoach))]  
    public async Task<IActionResult> CreateCoach(Coach coach)
    {
        try
        {
            await _repository.Coach.CreateCoachAsync(coach);
            return Ok("Coach added");
        }
        catch (Exception ex)
        {
            return BadRequest("Coach already exists!");
        }
    }  
    [HttpPut(nameof(UpdateCoach))]  
    public async Task<IActionResult> UpdateCoach(Coach coach)
    {
        try
        {
            await _repository.Coach.UpdateCoachAsync(coach.Id, coach);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return BadRequest("Coach doesn't found");
        }
    }  
    [HttpDelete(nameof(DeleteCoach))]  
    public async Task<IActionResult> DeleteCoach(int coachId)
    {
        try
        {
            await _repository.Coach.DeleteCoachAsync(coachId);
            return Ok("Coach deleted");
        }
        catch (Exception ex)
        {
            return BadRequest("Coach doesn't found");
        }
    }  
}