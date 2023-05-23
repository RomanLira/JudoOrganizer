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

    [HttpGet(nameof(GetCity))]
    public async Task<IActionResult> GetCity(int id)
    {
        try
        {
            var city = await _repository.City.GetCityAsync(id);
            return Ok(city);
        }
        catch (Exception ex)
        {
            return BadRequest("City doesn't found");
        }
    }

    [HttpGet(nameof(GetAllCities))]
    public async Task<IActionResult> GetAllCities()
    {
        try
        {
            var cities = await _repository.City.GetAllCitiesAsync();
            return Ok(cities);
        }
        catch (Exception ex)
        {
            return BadRequest("No cities found");
        }
    }
    
    [HttpGet(nameof(GetAllClubsForCity))]
    public async Task<IActionResult> GetAllClubsForCity(int cityId)
    {
        try
        {
            var clubs = await _repository.Club.GetAllClubsForCityAsync(cityId);
            return Ok(clubs);
        }
        catch (Exception ex)
        {
            return BadRequest("No clubs found");
        }
    }

    [HttpPost(nameof(CreateCity))]  
    public async Task<IActionResult> CreateCity(City city)
    {
        try
        {
            await _repository.City.CreateCityAsync(city);
            return Ok("City added");
        }
        catch (Exception ex)
        {
            return BadRequest("City already exists!");
        }
    }  
    [HttpPut(nameof(UpdateCity))]  
    public async Task<IActionResult> UpdateCity(City city)
    {
        try
        {
            await _repository.City.UpdateCityAsync(city.Id, city);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return BadRequest("City doesn't found");
        }
    }  
    [HttpDelete(nameof(DeleteCity))]  
    public async Task<IActionResult> DeleteCity(int cityId)
    {
        try
        {
            await _repository.City.DeleteCityAsync(cityId);
            return Ok("City deleted");
        }
        catch (Exception ex)
        {
            return BadRequest("City doesn't found");
        }
    }  
}