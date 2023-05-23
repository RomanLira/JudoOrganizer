using System.Linq;
using JudoOrganizer.Data;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Repository.Classes;
using JudoOrganizer.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JudoOrganizer.Service.Classes;

public class SportsmanService : Repository<Sportsman>, ISportsmanService
{
    public SportsmanService(ApplicationContext applicationContext) : base(applicationContext)
    {
        
    }

    public async Task<IEnumerable<Sportsman>> GetAllSportsmenAsync() =>
        await GetAllAsync().Result.OrderBy(sportsman =>
            sportsman.LastName + sportsman.FirstName + sportsman.Patronymic).ToListAsync();

    public async Task<IEnumerable<Sportsman>> GetAllSportsmenForClubAsync(int clubId) =>
        await GetAllAsync().Result.Where(sportsman => sportsman.ClubId.Equals(clubId)).
            OrderBy(sportsman => sportsman.LastName + sportsman.FirstName + sportsman.Patronymic)
            .ToListAsync();
    
    public async Task<IEnumerable<Sportsman>> GetAllSportsmenForCoachAsync(int coachId) =>
        await GetAllAsync().Result.Where(sportsman => sportsman.CoachId.Equals(coachId)).
            OrderBy(sportsman => sportsman.LastName + sportsman.FirstName + sportsman.Patronymic)
            .ToListAsync();

    public async Task<Sportsman?> GetSportsmanAsync(int id) =>
        await GetAsync(sportsman => sportsman.Id.Equals(id)).Result.SingleOrDefaultAsync();

    public async Task CreateSportsmanAsync(Sportsman sportsman)
    {
        await CreateAsync(sportsman);
        await SaveChangesAsync();
    }

    public async Task UpdateSportsmanAsync(int id, Sportsman sportsman)
    {
        var changedSportsman = await GetSportsmanAsync(id);
        await DeleteSportsmanAsync(changedSportsman.Id);
        await CreateSportsmanAsync(sportsman);
        await SaveChangesAsync();
    }

    public async Task DeleteSportsmanAsync(int id)
    {
        var sportsman = await GetSportsmanAsync(id);
        await DeleteAsync(sportsman);
        await SaveChangesAsync();
    }
}