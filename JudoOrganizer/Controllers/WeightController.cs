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

    [HttpGet(nameof(GetWeight))]
    public async Task<IActionResult> GetWeight(int id)
    {
        try
        {
            var weight = await _repository.Weight.GetWeightAsync(id);
            return Ok(weight);
        }
        catch (Exception ex)
        {
            return BadRequest("Weight doesn't found");
        }
    }

    [HttpGet(nameof(GetAllWeights))]
    public async Task<IActionResult> GetAllWeights()
    {
        try
        {
            var weights = await _repository.Weight.GetAllWeightsAsync();
            return Ok(weights);
        }
        catch (Exception ex)
        {
            return BadRequest("No weights found");
        }
    }

    [HttpPost(nameof(CreateWeight))]  
    public async Task<IActionResult> CreateWeight(Weight weight)
    {
        try
        {
            await _repository.Weight.CreateWeightAsync(weight);
            return Ok("Weight added");
        }
        catch (Exception ex)
        {
            return BadRequest("Weight already exists!");
        }
    }  
    [HttpPut(nameof(UpdateWeight))]  
    public async Task<IActionResult> UpdateWeight(Weight weight)
    {
        try
        {
            await _repository.Weight.UpdateWeightAsync(weight.Id, weight);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return BadRequest("Weight doesn't found");
        }
    }  
    [HttpDelete(nameof(DeleteWeight))]  
    public async Task<IActionResult> DeleteWeight(int weightId)
    {
        try
        {
            await _repository.Weight.DeleteWeightAsync(weightId);
            return Ok("Weight deleted");
        }
        catch (Exception ex)
        {
            return BadRequest("Weight doesn't found");
        }
    }  
}