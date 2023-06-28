using JudoOrganizer.Data.Models;

namespace JudoOrganizer.Service.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User?> GetUserAsync(int id);
    Task<User?> GetUserByLoginAsync(string login);
    Task CreateUserAsync(User user);
    Task UpdateUserAsync(int id, User user);
    Task DeleteUserAsync(int id);
}