using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegistrationController : BaseController
{
    public RegistrationController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRegistration(int id)
    {
        try
        {
            var registration = await _repository.Registration.GetRegistrationAsync(id);
            return Ok(value: registration);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRegistrations()
    {
        try
        {
            var registrations = await _repository.Registration.GetAllRegistrationsAsync();
            return Ok(value: registrations);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }
    
    [HttpGet("{pageIndex}&{pageSize}")]
    public async Task<IActionResult> GetAllRegistrationsWithPagination(int pageIndex = 1, int pageSize = 10)
    {
        try
        {
            var registrations = await _repository.Registration.GetAllRegistrationsWithPaginationAsync(pageIndex, pageSize);
            return Ok(value: registrations);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }
    
    [HttpGet("Category/{categoryId}")]
    public async Task<IActionResult> GetAllSportsmenWithCategory(int categoryId)
    {
        try
        {
            var allRegistrations = await _repository.Registration.GetAllRegistrationsAsync();
            var registrations = allRegistrations.Where(registration => registration.SportCategoryId == categoryId);
            var sportsmen = registrations.Select(registration => registration.SportsmanId).ToList();
            return Ok(value: sportsmen);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }
    
    [HttpGet("Count/{categoryId}")]
    public async Task<IActionResult> GetSportsmenCountForCategory(int categoryId)
    {
        try
        {
            var registrations = await _repository.Registration.GetAllRegistrationsAsync();
            var count = registrations.Count(registration => registration.SportCategoryId == categoryId);
            return Ok(value: count);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpPost]  
    public async Task<IActionResult> CreateRegistration(Registration registration)
    {
        try
        {
            var registrations = await _repository.Registration.GetAllRegistrationsAsync();
            var checkRegistration = registrations.Any(r =>
                r.TournamentId == registration.TournamentId &&
                r.SportsmanId == registration.SportsmanId);
            if (checkRegistration)
                throw new Exception("Такой спортсмен уже зарегистрирован!");
            registration.Id = registrations.Count() + 1;
            await _repository.Registration.CreateRegistrationAsync(registration);
            return CreatedAtAction(nameof(GetRegistration), new {id=registration.Id}, registration);
        }
        catch (Exception ex)
        {
            return BadRequest("Error! " + ex.Message);
        }
    }  
    
    [HttpPut]  
    public async Task<IActionResult> UpdateRegistration(Registration registration)
    {
        try
        {
            await _repository.Registration.UpdateRegistrationAsync(registration.Id, registration);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
    
    [HttpDelete("DeleteRegistration/{registrationId}")]  
    public async Task<IActionResult> DeleteRegistration(int registrationId)
    {
        try
        {
            await _repository.Registration.DeleteRegistrationAsync(registrationId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
}