using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : BaseController
{
    public CountriesController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("Country/{id}")]
    public async Task<IActionResult> GetCountry(int id)
    {
        try
        {
            var country = await _repository.Country.GetCountryAsync(id);
            return Ok(value: country);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCountries()
    {
        try
        {
            var countries = await _repository.Country.GetAllCountriesAsync();
            return Ok(value: countries);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
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
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpPost]  
    public async Task<IActionResult> CreateCountry(Country country)
    {
        try
        {
            var countries = await _repository.Country.GetAllCountriesAsync();
            var checkCountry = countries.Any(c =>
                                c.Name == country.Name);
            if (checkCountry)
                throw new Exception("Такая страна уже существует!");
            country.Id = countries.Count() + 1;
            await _repository.Country.CreateCountryAsync(country);
            return CreatedAtAction(nameof(GetCountry), new { id = country.Id }, country);
        }
        catch (Exception ex)
        {
            return BadRequest("Error! " + ex.Message);
        }
    }  
    [HttpPut]  
    public async Task<IActionResult> UpdateCountry(Country country)
    {
        try
        {
            await _repository.Country.UpdateCountryAsync(country.Id, country);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
    [HttpDelete("DeleteCountry/{countryId}")]  
    public async Task<IActionResult> DeleteCountry(int countryId)
    {
        try
        {
            await _repository.Country.DeleteCountryAsync(countryId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
}