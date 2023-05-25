using AutoMapper;
using JudoOrganizer.Data;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{
    public UserController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("User")]
    public async Task<IActionResult> GetUser(int id)
    {
        try
        {
            var user = await _repository.User.GetUserAsync(id);
            return Ok(value: user);
        }
        catch (Exception ex)
        {
            return NotFound("User doesn't found");
        }
    }

    [HttpGet("Users")]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            var users = await _repository.User.GetAllUsersAsync();
            return Ok(value: users);
        }
        catch (Exception ex)
        {
            return NotFound("No users found");
        }
    }

    [HttpPost("User")]  
    public async Task<IActionResult> CreateUser(User user)
    {
        try
        {
            await _repository.User.CreateUserAsync(user);
            return Created(Url.RouteUrl(user.Id), user);
        }
        catch (Exception ex)
        {
            return BadRequest("User already exists!");
        }
    }  
    [HttpPut("User")]  
    public async Task<IActionResult> UpdateUser(User user)
    {
        try
        {
            await _repository.User.UpdateUserAsync(user.Id, user);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("User doesn't found");
        }
    }  
    
    [HttpDelete("User")]  
    public async Task<IActionResult> DeleteUser(int userId)
    {
        try
        {
            await _repository.User.DeleteUserAsync(userId);
            return NoContent();
        }
        catch (Exception ex)
        {
           return NotFound("User doesn't found");
        }
    }  
}