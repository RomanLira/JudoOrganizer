using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : BaseController
{
    public CountryController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("Country")]
    public async Task<IActionResult> GetCountry(int id)
    {
        try
        {
            var country = await _repository.Country.GetCountryAsync(id);
            return Ok(value: country);
        }
        catch (Exception ex)
        {
            return NotFound("Country doesn't found");
        }
    }

    [HttpGet("Countries")]
    public async Task<IActionResult> GetAllCountries()
    {
        try
        {
            var countries = await _repository.Country.GetAllCountriesAsync();
            return Ok(value: countries);
        }
        catch (Exception ex)
        {
            return NotFound("No countries found");
        }
    }
    
    [HttpGet("Country/{countryId}/Cities")]
    public async Task<IActionResult> GetAllCitiesForCountry(int countryId)
    {
        try
        {
            var cities = await _repository.City.GetAllCitiesForCountryAsync(countryId);
            return Ok(value: cities);
        }
        catch (Exception ex)
        {
            return NotFound("No cities found");
        }
    }

    [HttpPost("Country")]  
    public async Task<IActionResult> CreateCountry(Country country)
    {
        try
        {
            await _repository.Country.CreateCountryAsync(country);
            return Created(Url.RouteUrl(country.Id), country);
        }
        catch (Exception ex)
        {
            return BadRequest("Country already exists!");
        }
    }  
    [HttpPut("Country")]  
    public async Task<IActionResult> UpdateCountry(Country country)
    {
        try
        {
            await _repository.Country.UpdateCountryAsync(country.Id, country);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Country doesn't found");
        }
    }  
    [HttpDelete("Country")]  
    public async Task<IActionResult> DeleteCountry(int countryId)
    {
        try
        {
            await _repository.Country.DeleteCountryAsync(countryId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Country doesn't found");
        }
    }  
}