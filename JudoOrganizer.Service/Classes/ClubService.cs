using System.Linq;
using JudoOrganizer.Data;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Repository.Classes;
using JudoOrganizer.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JudoOrganizer.Service.Classes;

public class ClubService : Repository<Club>, IClubService
{
    public ClubService(ApplicationContext applicationContext) : base(applicationContext)
    {
        
    }

    public async Task<IEnumerable<Club>> GetAllClubsAsync() =>
        await GetAllAsync().Result.OrderBy(club => club.Name).ToListAsync();

    public async Task<IEnumerable<Club>> GetAllClubsForCityAsync(int cityId) =>
        await GetAllAsync().Result.Where(club => club.CityId.Equals(cityId)).OrderBy(club => club.Name)
            .ToListAsync();

    public async Task<Club?> GetClubAsync(int id) =>
        await GetAsync(club => club.Id.Equals(id)).Result.SingleOrDefaultAsync();

    public async Task CreateClubAsync(Club club)
    {
        await CreateAsync(club);
        await SaveChangesAsync();
    }

    public async Task UpdateClubAsync(int id, Club club)
    {
        var changedClub = await GetClubAsync(id);
        await DeleteClubAsync(changedClub.Id);
        await CreateClubAsync(club);
        await SaveChangesAsync();
    }

    public async Task DeleteClubAsync(int id)
    {
        var club = await GetClubAsync(id);
        await DeleteAsync(club);
        await SaveChangesAsync();
    }
}