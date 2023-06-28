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

    public async Task<IEnumerable<SportCategory>> GetAllSportCategoriesForSportsmanAsync(Sportsman sportsman) =>
        await GetAllAsync().Result.Where(sportCategory => sportCategory.Sex.Equals(sportsman.Sex) && sportCategory.DateOfBirth.Equals(sportsman.DateOfBirth))
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
        if (changedSportCategory != null)
        {
            changedSportCategory.Sex = sportCategory.Sex;
            changedSportCategory.DateOfBirth = sportCategory.DateOfBirth;
            changedSportCategory.TournamentId = sportCategory.TournamentId;
            changedSportCategory.WeightId = sportCategory.WeightId;

            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Данные не найдены.");
        }
    }


    public async Task DeleteSportCategoryAsync(int id)
    {
        var sportCategory = await GetSportCategoryAsync(id);
        if (sportCategory != null)
        {
            await DeleteAsync(sportCategory);
            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Данные не найдены.");
        }
    }
}