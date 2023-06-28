using JudoOrganizer.Data;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Repository.Interfaces;
using JudoOrganizer.Repository.Classes;
using JudoOrganizer.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JudoOrganizer.Service.Classes;

public class UserService : Repository<User>, IUserService
{
    public UserService(ApplicationContext applicationContext) : base(applicationContext)
    {
        
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync() =>
        await GetAllAsync().Result.OrderBy(user => user.Login).ToListAsync();

    public async Task<User?> GetUserAsync(int id) =>
        await GetAsync(user => user.Id.Equals(id)).Result.SingleOrDefaultAsync();

    public async Task<User?> GetUserByLoginAsync(string login) =>
        await GetAsync(user => user.Login.Equals(login)).Result.SingleOrDefaultAsync();

    public async Task CreateUserAsync(User user)
    {
        await CreateAsync(user);
        await SaveChangesAsync();
    }

    public async Task UpdateUserAsync(int id, User user)
    {
        var changedUser = await GetUserAsync(id);
        if (changedUser != null)
        {
            changedUser.Login = user.Login;
            changedUser.Email = user.Email;
            changedUser.Password = user.Password;
            changedUser.Role = user.Role;

            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Пользователь не найден.");
        }
    }


    public async Task DeleteUserAsync(int id)
    {
        var user = await GetUserAsync(id);
        if (user != null)
        {
            await DeleteAsync(user);
            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Пользователь не найден.");
        }
    }
}