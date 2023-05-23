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

    [HttpGet(nameof(GetSportCategory))]
    public async Task<IActionResult> GetSportCategory(int id)
    {
        try
        {
            var sportCategory = await _repository.SportCategory.GetSportCategoryAsync(id);
            return Ok(sportCategory);
        }
        catch (Exception ex)
        {
            return BadRequest("Sport category doesn't found");
        }
    }

    [HttpGet(nameof(GetAllSportCategories))]
    public async Task<IActionResult> GetAllSportCategories()
    {
        try
        {
            var sportCategories = await _repository.SportCategory.GetAllSportCategoriesAsync();
            return Ok(sportCategories);
        }
        catch (Exception ex)
        {
            return BadRequest("No Sport categories found");
        }
    }

    [HttpPost(nameof(CreateSportCategory))]  
    public async Task<IActionResult> CreateSportCategory(SportCategory sportCategory)
    {
        try
        {
            await _repository.SportCategory.CreateSportCategoryAsync(sportCategory);
            return Ok("Sport category added");
        }
        catch (Exception ex)
        {
            return BadRequest("Sport category already exists!");
        }
    }  
    [HttpPut(nameof(UpdateSportCategory))]  
    public async Task<IActionResult> UpdateSportCategory(SportCategory sportCategory)
    {
        try
        {
            await _repository.SportCategory.UpdateSportCategoryAsync(sportCategory.Id, sportCategory);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return BadRequest("Sport category doesn't found");
        }
    }  
    [HttpDelete(nameof(DeleteSportCategory))]  
    public async Task<IActionResult> DeleteSportCategory(int sportCategoryId)
    {
        try
        {
            await _repository.SportCategory.DeleteSportCategoryAsync(sportCategoryId);
            return Ok("Sport category deleted");
        }
        catch (Exception ex)
        {
            return BadRequest("Sport category doesn't found");
        }
    }  
}