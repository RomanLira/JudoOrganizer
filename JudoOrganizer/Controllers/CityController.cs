using AutoMapper;
using JudoOrganizer.Data;
using JudoOrganizer.Data.Maps;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using JudoOrganizer.Service.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CityController : BaseController
{
    public CityController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("City")]
    public async Task<IActionResult> GetCity(int id)
    {
        try
        {
            var city = await _repository.City.GetCityAsync(id: id);
            return Ok(value: city);
        }
        catch (Exception ex)
        {
            return NotFound("City doesn't found");
        }
    }

    [HttpGet("Cities")]
    public async Task<IActionResult> GetAllCities()
    {
        try
        {
            var cities = await _repository.City.GetAllCitiesAsync();
            return Ok(value: cities);
        }
        catch (Exception ex)
        {
            return NotFound("No cities found");
        }
    }
    
    [HttpGet("City/{cityId}/Clubs")]
    public async Task<IActionResult> GetAllClubsForCity(int cityId)
    {
        try
        {
            var clubs = await _repository.Club.GetAllClubsForCityAsync(cityId);
            return Ok(value: clubs);
        }
        catch (Exception ex)
        {
            return NotFound("No clubs found");
        }
    }

    [HttpPost("City")]  
    public async Task<IActionResult> CreateCity(City city)
    {
        try
        {
            await _repository.City.CreateCityAsync(city);
            return Created(Url.RouteUrl(city.Id), city);
        }
        catch (Exception ex)
        {
            return BadRequest("City already exists!");
        }
    }  
    [HttpPut("City")]  
    public async Task<IActionResult> UpdateCity(City city)
    {
        try
        {
            await _repository.City.UpdateCityAsync(city.Id, city);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("City doesn't found");
        }
    }  
    [HttpDelete("City")]  
    public async Task<IActionResult> DeleteCity(int cityId)
    {
        try
        {
            await _repository.City.DeleteCityAsync(cityId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("City doesn't found");
        }
    }  
}