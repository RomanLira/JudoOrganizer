using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeightsController : BaseController
{
    public WeightsController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("Weight/{id}")]
    public async Task<IActionResult> GetWeight(int id)
    {
        try
        {
            var weight = await _repository.Weight.GetWeightAsync(id);
            return Ok(value: weight);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWeights()
    {
        try
        {
            var weights = await _repository.Weight.GetAllWeightsAsync();
            return Ok(value: weights);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpPost]  
    public async Task<IActionResult> CreateWeight(Weight weight)
    {
        try
        {
            var weights = await _repository.Weight.GetAllWeightsAsync();
            var checkWeight = weights.Any(w =>
                                w.WeightValue == weight.WeightValue);
            if (checkWeight)
                throw new Exception("Такой вес уже существует!");
            weight.Id = weights.Count() + 1;
            await _repository.Weight.CreateWeightAsync(weight);
            return CreatedAtAction(nameof(GetWeight), new {id=weight.Id}, weight);
        }
        catch (Exception ex)
        {
            return BadRequest("Error! " + ex.Message);
        }
    }  
    [HttpPut]  
    public async Task<IActionResult> UpdateWeight(Weight weight)
    {
        try
        {
            await _repository.Weight.UpdateWeightAsync(weight.Id, weight);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
    [HttpDelete("DeleteWeight/{weightId}")]  
    public async Task<IActionResult> DeleteWeight(int weightId)
    {
        try
        {
            await _repository.Weight.DeleteWeightAsync(weightId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
}