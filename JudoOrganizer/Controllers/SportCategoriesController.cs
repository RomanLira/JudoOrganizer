using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SportCategoriesController : BaseController
{
    public SportCategoriesController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("SportCategory/{id}")]
    public async Task<IActionResult> GetSportCategory(int id)
    {
        try
        {
            var sportCategory = await _repository.SportCategory.GetSportCategoryAsync(id);
            return Ok(value: sportCategory);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSportCategories()
    {
        try
        {
            var sportCategories = await _repository.SportCategory.GetAllSportCategoriesAsync();
            return Ok(value: sportCategories);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }
    
    [HttpGet("sportCategory/{sportCategoryId}/matches")]
    public async Task<IActionResult> GetAllMatchesForSportCategory(int sportCategoryId)
    {
        try
        {
            var matches = await _repository.Match.GetAllMatchesForSportCategoryAsync(sportCategoryId);
            return Ok(value: matches);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpPost]  
    public async Task<IActionResult> CreateSportCategory(SportCategory sportCategory)
    {
        try
        {
            var sportCategories = await _repository.SportCategory.GetAllSportCategoriesAsync();
            var checkSportCategory = sportCategories.Any(sc =>
                                sc.WeightId == sportCategory.WeightId &&
                                sc.Sex == sportCategory.Sex &&
                                sc.DateOfBirth == sportCategory.DateOfBirth &&
                                sc.TournamentId == sportCategory.TournamentId);
            if (checkSportCategory)
                throw new Exception("Такая категория уже существует!");
            sportCategory.Id = sportCategories.Count() + 1;
            await _repository.SportCategory.CreateSportCategoryAsync(sportCategory);
            return CreatedAtAction(nameof(GetSportCategory), new {id= sportCategory.Id}, sportCategory);
        }
        catch (Exception ex)
        {
            return BadRequest("Error! " + ex.Message + " Inner Exception: " + ex.InnerException?.Message);
        }
    }  

    [HttpPut]  
    public async Task<IActionResult> UpdateSportCategory(SportCategory sportCategory)
    {
        try
        {
            await _repository.SportCategory.UpdateSportCategoryAsync(sportCategory.Id, sportCategory);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
    [HttpDelete("DeleteSportCategories/{sportCategoryId}")]  
    public async Task<IActionResult> DeleteSportCategory(int sportCategoryId)
    {
        try
        {
            await _repository.SportCategory.DeleteSportCategoryAsync(sportCategoryId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
}