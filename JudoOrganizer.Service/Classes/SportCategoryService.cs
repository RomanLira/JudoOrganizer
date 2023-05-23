using System.Linq;
using JudoOrganizer.Data;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Repository.Classes;
using JudoOrganizer.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JudoOrganizer.Service.Classes;

public class SportCategoryService : Repository<SportCategory>, ISportCategoryService
{
    public SportCategoryService(ApplicationContext applicationContext) : base(applicationContext)
    {
        
    }

    public async Task<IEnumerable<SportCategory>> GetAllSportCategoriesAsync() =>
        await GetAllAsync().Result.OrderBy(sportCategory => sportCategory.Id).ToListAsync();

    public async Task<IEnumerable<SportCategory>> GetAllSportCategoriesForTournamentAsync(int tournamentId) =>
        await GetAllAsync().Result.Where(sportCategory => sportCategory.TournamentId.Equals(tournamentId))
            .OrderBy(sportCategory => sportCategory.Id)
            .ToListAsync();

    public async Task<SportCategory?> GetSportCategoryAsync(int id) =>
        await GetAsync(sportCategory => sportCategory.Id.Equals(id)).Result.SingleOrDefaultAsync();

    public async Task CreateSportCategoryAsync(SportCategory sportCategory)
    {
        await CreateAsync(sportCategory);
        await SaveChangesAsync();
    }

    public async Task UpdateSportCategoryAsync(int id, SportCategory sportCategory)
    {
        var changedSportCategory = await GetSportCategoryAsync(id);
        await DeleteSportCategoryAsync(changedSportCategory.Id);
        await CreateSportCategoryAsync(sportCategory);
        await SaveChangesAsync();
    }

    public async Task DeleteSportCategoryAsync(int id)
    {
        var sportCategory = await GetSportCategoryAsync(id);
        await DeleteAsync(sportCategory);
        await SaveChangesAsync();
    }
}