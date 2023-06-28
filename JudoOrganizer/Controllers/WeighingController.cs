using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeighingController : BaseController
{
    public WeighingController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWeighing(int id)
    {
        try
        {
            var weighing = await _repository.Weighing.GetWeighingAsync(id);
            return Ok(value: weighing);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWeighing()
    {
        try
        {
            var weighing = await _repository.Weighing.GetAllWeighingAsync();
            return Ok(value: weighing);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpPost]  
    public async Task<IActionResult> CreateWeighing(Weighing weighing)
    {
        try
        {
            var listOfWeighing = await _repository.Weighing.GetAllWeighingAsync();
            weighing.Id = listOfWeighing.Count() + 1;
            await _repository.Weighing.CreateWeighingAsync(weighing);
            return CreatedAtAction(nameof(GetWeighing), new { id = weighing.Id }, weighing);
        }
        catch (Exception ex)
        {
            return BadRequest("Error! " + ex.Message);
        }
    }  
    
    [HttpPut]  
    public async Task<IActionResult> UpdateWeighing(Weighing weighing)
    {
        try
        {
            await _repository.Weighing.UpdateWeighingAsync(weighing.Id, weighing);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
    
    [HttpDelete("DeleteWeighing/{weighingId}")]  
    public async Task<IActionResult> DeleteWeighing(int weighingId)
    {
        try
        {
            await _repository.Weighing.DeleteWeighingAsync(weighingId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
}