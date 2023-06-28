using AutoMapper;
using JudoOrganizer.Data;
using JudoOrganizer.Data.Enums;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Models;
using JudoOrganizer.Service.Classes;
using JudoOrganizer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace JudoOrganizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : BaseController
{
    public UsersController(IRepositoryManager repository) : base(repository)
    {
        
    }

    [HttpGet("User/{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        try
        {
            var user = await _repository.User.GetUserAsync(id);
            return Ok(value: user);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            var users = await _repository.User.GetAllUsersAsync();
            return Ok(value: users);
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }

    [HttpGet("GetCurrentUserRole")]
    public async Task<IActionResult> GetCurrentUserRole()
    {
        try
        {
            // Получение информации о текущем пользователе
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            // Получение роли пользователя по его идентификатору или другим способом
            var user = await _repository.User.GetUserAsync(userId);
            var userRole = user?.Role.ToString();

            if (string.IsNullOrEmpty(userRole))
            {
                return NotFound("Роль не найдена");
            }

            return Ok(new { Role = userRole });
        }
        catch (Exception ex)
        {
            return BadRequest("Ошибка при получении роли пользователя: " + ex.Message);
        }
    }

    [HttpGet("GetCurrentUserId")]
    public async Task<IActionResult> GetCurrentUserId()
    {
        try
        {
            // Получение информации о текущем пользователе
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            // Получение роли пользователя по его идентификатору или другим способом
            var user = await _repository.User.GetUserAsync(userId);
            var id = user?.Id;

            if (id == null)
            {
                return NotFound("Пользователь не найден");
            }

            return Ok(new { Id = userId});
        }
        catch (Exception ex)
        {
            return BadRequest("Ошибка при получении роли пользователя: " + ex.Message);
        }
    }

    [HttpGet("IsAuthenticated")]
    public IActionResult IsAuthenticated()
    {
        if (User.Identity.IsAuthenticated)
        {
            return Ok();
        }
        else
        {
            Response.Headers.Add("Cache-Control", "no-cache");
            return Unauthorized();
        }
    }

    [HttpPost]  
    public async Task<IActionResult> CreateUser(User user)
    {
        try
        {
            var users = await _repository.User.GetAllUsersAsync();
            var checkUser = users.Any(u =>
                                u.Login == user.Login);
            if (checkUser)
                throw new Exception("Такой пользователь уже существует!");
            user.Id = users.Count() + 1;
            user.Role = Role.Coach;
            await _repository.User.CreateUserAsync(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }
        catch (Exception ex)
        {
            return BadRequest("Error! " + ex.Message);
        }
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        try
        {
            var user = await _repository.User.GetUserByLoginAsync(model.Login);
            if (user == null || user.Password != model.Password)
            {
                return Unauthorized("Неправильный логин и/или пароль!");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                
            };

            await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

            return Ok(new { Role = user.Role });
        }
        catch (Exception ex)
        {
            return BadRequest("Error! " + ex.Message);
        }
    }

    [HttpPut]  
    public async Task<IActionResult> UpdateUser(User user)
    {
        try
        {
            await _repository.User.UpdateUserAsync(user.Id, user);
            return Ok("Update done");
        }
        catch (Exception ex)
        {
            return NotFound("Error! " + ex.Message);
        }
    }  
    
    [HttpDelete("DeleteUser/{userId}")]  
    public async Task<IActionResult> DeleteUser(int userId)
    {
        try
        {
            await _repository.User.DeleteUserAsync(userId);
            return NoContent();
        }
        catch (Exception ex)
        {
           return NotFound("Error! " + ex.Message);
        }
    }  
}