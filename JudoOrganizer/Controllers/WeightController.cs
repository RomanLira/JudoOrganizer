using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeightController : BaseController
{
    public WeightController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("Weight")]
    public async Task<IActionResult> GetWeight(int id)
    {
        try
        {
            var weight = await _repository.Weight.GetWeightAsync(id);
            return Ok(value: weight);
        }
        catch (Exception ex)
        {
            return NotFound("Weight doesn't found");
        }
    }

    [HttpGet("Weights")]
    public async Task<IActionResult> GetAllWeights()
    {
        try
        {
            var weights = await _repository.Weight.GetAllWeightsAsync();
            return Ok(value: weights);
        }
        catch (Exception ex)
        {
            return NotFound("No weights found");
        }
    }

    [HttpPost("Weight")]  
    public async Task<IActionResult> CreateWeight(Weight weight)
    {
        try
        {
            await _repository.Weight.CreateWeightAsync(weight);
            return Created(Url.RouteUrl(weight.Id), weight);
        }
        catch (Exception ex)
        {
            return BadRequest("Weight already exists!");
        }
    }  
    [HttpPut("Weight")]  
    public async Task<IActionResult> UpdateWeight(Weight weight)
    {
        try
        {
            await _repository.Weight.UpdateWeightAsync(weight.Id, weight);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Weight doesn't found");
        }
    }  
    [HttpDelete("Weight")]  
    public async Task<IActionResult> DeleteWeight(int weightId)
    {
        try
        {
            await _repository.Weight.DeleteWeightAsync(weightId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Weight doesn't found");
        }
    }  
}