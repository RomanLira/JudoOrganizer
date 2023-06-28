using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoachesController : BaseController
{
    public CoachesController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("Coach/{id}")]
    public async Task<IActionResult> GetCoach(int id)
    {
        try
        {
            var coach = await _repository.Coach.GetCoachAsync(id);
            return Ok(value: coach);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpGet("CoachByUserId/{userId}")]
    public async Task<IActionResult> GetCoachByUserId(int userId)
    {
        try
        {
            var coach = await _repository.Coach.GetCoachByUserIdAsync(userId);
            return Ok(value: coach);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCoaches()
    {
        try
        {
            var coaches = await _repository.Coach.GetAllCoachesAsync();
            return Ok(value: coaches);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
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
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpPost]  
    public async Task<IActionResult> CreateCoach(Coach coach)
    {
        try
        {
            var coaches = await _repository.Coach.GetAllCoachesAsync();
            var checkCoach = coaches.Any(c =>
                                c.LastName == coach.LastName &&
                                c.FirstName == coach.FirstName &&
                                c.Patronymic == coach.Patronymic &&
                                c.Phone == coach.Phone &&
                                c.ClubId == coach.ClubId);
            if (checkCoach)
                throw new Exception("Такой тренер уже существует!");
            coach.Id = coaches.Count() + 1;
            await _repository.Coach.CreateCoachAsync(coach);
            return CreatedAtAction(nameof(GetCoach), new { id = coach.Id }, coach);
        }
        catch (Exception ex)
        {
            return BadRequest("Error! " + ex.Message);
        }
    }  

    [HttpPut]  
    public async Task<IActionResult> UpdateCoach(Coach coach)
    {
        try
        {
            await _repository.Coach.UpdateCoachAsync(coach.Id, coach);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  

    [HttpDelete("DeleteCoach/{coachId}")]  
    public async Task<IActionResult> DeleteCoach(int coachId)
    {
        try
        {
            var coach = await _repository.Coach.GetCoachAsync(coachId);
            var user = await _repository.User.GetUserAsync(coach.UserId);
            await _repository.User.DeleteUserAsync(user.Id);
            await _repository.Coach.DeleteCoachAsync(coachId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
}