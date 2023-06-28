using System.Linq;
using JudoOrganizer.Data;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Repository.Classes;
using JudoOrganizer.Service.Interfaces;
using JudoOrganizer.Service.Classes;
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
        if (changedClub != null)
        {
            changedClub.Name = club.Name;
            changedClub.Address = club.Address;
            changedClub.CityId = club.CityId;

            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Клуб не найден.");
        }
    }


    public async Task DeleteClubAsync(int id)
    {
        var club = await GetClubAsync(id);
        if (club != null)
        {
            await DeleteAsync(club);
            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Клуб не найден.");
        }
    }
}