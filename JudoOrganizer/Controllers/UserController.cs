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

    [HttpGet(nameof(GetUser))]
    public async Task<IActionResult> GetUser(int id)
    {
        try
        {
            var user = await _repository.User.GetUserAsync(id);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest("User doesn't found");
        }
    }

    [HttpGet(nameof(GetAllUsers))]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            var users = await _repository.User.GetAllUsersAsync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest("No users found");
        }
    }

    [HttpPost(nameof(CreateUser))]  
    public async Task<IActionResult> CreateUser(User user)
    {
        try
        {
            await _repository.User.CreateUserAsync(user);
            return Ok("User added");
        }
        catch (Exception ex)
        {
            return BadRequest("User already exists!");
        }
    }  
    [HttpPut(nameof(UpdateUser))]  
    public async Task<IActionResult> UpdateUser(User user)
    {
        try
        {
            await _repository.User.UpdateUserAsync(user.Id, user);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return BadRequest("User doesn't found");
        }
    }  
    
    [HttpDelete(nameof(DeleteUser))]  
    public async Task<IActionResult> DeleteUser(int userId)
    {
        try
        {
            await _repository.User.DeleteUserAsync(userId);
            return Ok("User deleted");
        }
        catch (Exception ex)
        {
           return BadRequest("User doesn't found");
        }
    }  
}