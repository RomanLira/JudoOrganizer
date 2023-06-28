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
            sportsman.ClubId + sportsman.CoachId + sportsman.LastName + sportsman.FirstName + sportsman.Patronymic).ToListAsync();

    public async Task<IEnumerable<Sportsman>> GetAllSportsmenForClubAsync(int clubId) =>
        await GetAllAsync().Result.Where(sportsman => sportsman.ClubId.Equals(clubId)).
            OrderBy(sportsman => sportsman.LastName + sportsman.FirstName + sportsman.Patronymic)
            .ToListAsync();
    
    public async Task<IEnumerable<Sportsman>> GetAllSportsmenWithPaginationAsync(int pageIndex, int pageSize)
    {
        try
        {
            var sportsmen = await GetAllAsync();
            var pagedSportsmen = sportsmen.OrderBy(sportsman =>
                    sportsman.ClubId + sportsman.CoachId + sportsman.LastName + sportsman.FirstName +
                    sportsman.Patronymic)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
            return pagedSportsmen.ToList();
        }
        catch(Exception ex)
        {
            throw new Exception("Error! " + ex.Message);
        }
    }
    
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
        if (changedSportsman != null)
        {
            changedSportsman.LastName = sportsman.LastName;
            changedSportsman.FirstName = sportsman.FirstName;
            changedSportsman.Patronymic = sportsman.Patronymic;
            changedSportsman.DateOfBirth = sportsman.DateOfBirth;
            changedSportsman.Sex = sportsman.Sex; 
            changedSportsman.ClubId = sportsman.ClubId;
            changedSportsman.CoachId = sportsman.CoachId;

            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Спортсмен не найден.");
        }
    }


    public async Task DeleteSportsmanAsync(int id)
    {
        var sportsman = await GetSportsmanAsync(id);
        if (sportsman != null)
        {
            await DeleteAsync(sportsman);
            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Спортсмен не найден.");
        }
    }
}