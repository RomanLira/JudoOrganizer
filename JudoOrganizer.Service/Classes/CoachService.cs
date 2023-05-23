using System.Linq;
using JudoOrganizer.Data;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Repository.Classes;
using JudoOrganizer.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JudoOrganizer.Service.Classes;

public class CoachService : Repository<Coach>, ICoachService
{
    public CoachService(ApplicationContext applicationContext) : base(applicationContext)
    {
        
    }

    public async Task<IEnumerable<Coach>> GetAllCoachesAsync() =>
        await GetAllAsync().Result.OrderBy(coach => coach.LastName + coach.FirstName + coach.Patronymic)
            .ToListAsync();

    public async Task<IEnumerable<Coach>> GetAllCoachesForClubAsync(int clubId) =>
        await GetAllAsync().Result.Where(coach => coach.ClubId.Equals(clubId))
            .OrderBy(coach => coach.LastName + coach.FirstName + coach.Patronymic)
            .ToListAsync();

    public async Task<Coach?> GetCoachAsync(int id) =>
        await GetAsync(coach => coach.Id.Equals(id)).Result.SingleOrDefaultAsync();

    public async Task CreateCoachAsync(Coach coach)
    {
        await CreateAsync(coach);
        await SaveChangesAsync();
    }

    public async Task UpdateCoachAsync(int id, Coach coach)
    {
        var changedCoach = await GetCoachAsync(id);
        await DeleteCoachAsync(changedCoach.Id);
        await CreateCoachAsync(coach);
        await SaveChangesAsync();
    }

    public async Task DeleteCoachAsync(int id)
    {
        var coach = await GetCoachAsync(id);
        await DeleteAsync(coach);
        await SaveChangesAsync();
    }
}