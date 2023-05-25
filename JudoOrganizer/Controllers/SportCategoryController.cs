using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SportCategoryController : BaseController
{
    public SportCategoryController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("SportCategory")]
    public async Task<IActionResult> GetSportCategory(int id)
    {
        try
        {
            var sportCategory = await _repository.SportCategory.GetSportCategoryAsync(id);
            return Ok(value: sportCategory);
        }
        catch (Exception ex)
        {
            return NotFound("Sport category doesn't found");
        }
    }

    [HttpGet("SportCategories")]
    public async Task<IActionResult> GetAllSportCategories()
    {
        try
        {
            var sportCategories = await _repository.SportCategory.GetAllSportCategoriesAsync();
            return Ok(value: sportCategories);
        }
        catch (Exception ex)
        {
            return NotFound("No Sport categories found");
        }
    }

    [HttpPost("SportCategory")]  
    public async Task<IActionResult> CreateSportCategory(SportCategory sportCategory)
    {
        try
        {
            await _repository.SportCategory.CreateSportCategoryAsync(sportCategory);
            return Created(Url.RouteUrl(sportCategory.Id), sportCategory);
        }
        catch (Exception ex)
        {
            return BadRequest("Sport category already exists!");
        }
    }  
    [HttpPut("SportCategory")]  
    public async Task<IActionResult> UpdateSportCategory(SportCategory sportCategory)
    {
        try
        {
            await _repository.SportCategory.UpdateSportCategoryAsync(sportCategory.Id, sportCategory);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Sport category doesn't found");
        }
    }  
    [HttpDelete("SportCategory")]  
    public async Task<IActionResult> DeleteSportCategory(int sportCategoryId)
    {
        try
        {
            await _repository.SportCategory.DeleteSportCategoryAsync(sportCategoryId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Sport category doesn't found");
        }
    }  
}