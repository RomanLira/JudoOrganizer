using AutoMapper;
using JudoOrganizer.Data;
using JudoOrganizer.Data.Maps;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using JudoOrganizer.Service.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JudoOrganizer.Data.Enums;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitiesController : BaseController
{
    public CitiesController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("City/{id}")]
    public async Task<IActionResult> GetCity(int id)
    {
        try
        {
            var city = await _repository.City.GetCityAsync(id: id);
            return Ok(value: city);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCities()
    {
        try
        {
            var cities = await _repository.City.GetAllCitiesAsync();
            return Ok(value: cities);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
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
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpPost]  
    public async Task<IActionResult> CreateCity(City city)
    {
        try
        {
            var cities = await _repository.City.GetAllCitiesAsync();
            var checkCity = cities.Any(c =>
                                c.Name == city.Name &&
                                c.CountryId == city.CountryId);
            if (checkCity)
                throw new Exception("Такой город уже существует!");
            city.Id = cities.Count() + 1;
            await _repository.City.CreateCityAsync(city);
            return CreatedAtAction(nameof(GetCity), new { id = city.Id }, city);
        }
        catch (Exception ex)
        {
            return BadRequest("Error!  " + ex.Message);
        }
    }  
    
    [HttpPut]  
    public async Task<IActionResult> UpdateCity(City city)
    {
        try
        {
            await _repository.City.UpdateCityAsync(city.Id, city);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
    [HttpDelete("DeleteCity/{cityId}")]  
    public async Task<IActionResult> DeleteCity(int cityId)
    {
        try
        {
            await _repository.City.DeleteCityAsync(cityId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
}