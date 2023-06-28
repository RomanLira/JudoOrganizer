using JudoOrganizer.Data.Enums;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SportsmenController : BaseController
{
    public SportsmenController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("Sportsman/{id}")]
    public async Task<IActionResult> GetSportsman(int id)
    {
        try
        {
            var sportsman = await _repository.Sportsman.GetSportsmanAsync(id);
            return Ok(value: sportsman);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSportsmen()
    {
        try
        {
            var sportsmen = await _repository.Sportsman.GetAllSportsmenAsync();
            return Ok(value: sportsmen);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }
    
    [HttpGet("{pageIndex}&{pageSize}")]
    public async Task<IActionResult> GetAllSportsmenWithPagination(int pageIndex = 1, int pageSize = 10)
    {
        try
        {
            var sportsmen = await _repository.Sportsman.GetAllSportsmenWithPaginationAsync(pageIndex, pageSize);
            return Ok(value: sportsmen);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpGet("Sportsman/{sportsmanId}/MatchResults")]
    public async Task<IActionResult> GetAllMatchResultsForSportsman(int sportsmanId)
    {
        try
        {
            var matchResults = await _repository.MatchResult.GetAllMatchResultsForSportsmanAsync(sportsmanId);
            return Ok(value: matchResults);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpGet("Sportsman/{sportsmanId}/SportCategories")]
    public async Task<IActionResult> GetAllSportCategoriesForSportsman(int sportsmanId)
    {
        try
        {
            var sportsman = await _repository.Sportsman.GetSportsmanAsync(sportsmanId);
            var sportCategories = await _repository.SportCategory.GetAllSportCategoriesForSportsmanAsync(sportsman);
            return Ok(value: sportCategories);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpPost]  
    public async Task<IActionResult> CreateSportsman(Sportsman sportsman)
    {
        try
        {          
            var sportsmen = await _repository.Sportsman.GetAllSportsmenAsync();
            var checkSportsman = sportsmen.Any(s =>
                                s.LastName == sportsman.LastName &&
                                s.FirstName == sportsman.FirstName &&
                                s.Patronymic == sportsman.Patronymic &&
                                s.DateOfBirth == sportsman.DateOfBirth &&
                                s.Sex == sportsman.Sex &&
                                s.ClubId == sportsman.ClubId);
            if (checkSportsman)
                throw new Exception("Такой спортсмен уже существует!");
            sportsman.Id = sportsmen.Count() + 1;
            await _repository.Sportsman.CreateSportsmanAsync(sportsman);
            return CreatedAtAction(nameof(GetSportsman), new {id=sportsman.Id}, sportsman);
        }
        catch (Exception ex)
        {
            return BadRequest("Error! " + ex.Message + "InnerException " + ex.InnerException);
        }
    } 
    
    [HttpPut]  
    public async Task<IActionResult> UpdateSportsman(Sportsman sportsman)
    {
        try
        {
            await _repository.Sportsman.UpdateSportsmanAsync(sportsman.Id, sportsman);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
    [HttpDelete("DeleteSportsman/{sportsmanId}")]  
    public async Task<IActionResult> DeleteSportsman(int sportsmanId)
    {
        try
        {
            await _repository.Sportsman.DeleteSportsmanAsync(sportsmanId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
}