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

    [HttpGet(nameof(GetCountry))]
    public async Task<IActionResult> GetCountry(int id)
    {
        try
        {
            var country = await _repository.Country.GetCountryAsync(id);
            return Ok(country);
        }
        catch (Exception ex)
        {
            return BadRequest("Country doesn't found");
        }
    }

    [HttpGet(nameof(GetAllCountries))]
    public async Task<IActionResult> GetAllCountries()
    {
        try
        {
            var countries = await _repository.Country.GetAllCountriesAsync();
            return Ok(countries);
        }
        catch (Exception ex)
        {
            return BadRequest("No countries found");
        }
    }
    
    [HttpGet(nameof(GetAllCitiesForCountry))]
    public async Task<IActionResult> GetAllCitiesForCountry(int countryId)
    {
        try
        {
            var cities = await _repository.City.GetAllCitiesForCountryAsync(countryId);
            return Ok(cities);
        }
        catch (Exception ex)
        {
            return BadRequest("No cities found");
        }
    }

    [HttpPost(nameof(CreateCountry))]  
    public async Task<IActionResult> CreateCountry(Country country)
    {
        try
        {
            await _repository.Country.CreateCountryAsync(country);
            return Ok("Country added");
        }
        catch (Exception ex)
        {
            return BadRequest("Country already exists!");
        }
    }  
    [HttpPut(nameof(UpdateCountry))]  
    public async Task<IActionResult> UpdateCountry(Country country)
    {
        try
        {
            await _repository.Country.UpdateCountryAsync(country.Id, country);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return BadRequest("Country doesn't found");
        }
    }  
    [HttpDelete(nameof(DeleteCountry))]  
    public async Task<IActionResult> DeleteCountry(int countryId)
    {
        try
        {
            await _repository.Country.DeleteCountryAsync(countryId);
            return Ok("Country deleted");
        }
        catch (Exception ex)
        {
            return BadRequest("Country doesn't found");
        }
    }  
}