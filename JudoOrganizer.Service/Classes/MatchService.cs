using System.Linq;
using JudoOrganizer.Data;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Repository.Classes;
using JudoOrganizer.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JudoOrganizer.Service.Classes;

public class MatchService : Repository<Match>, IMatchService
{
    public MatchService(ApplicationContext applicationContext) : base(applicationContext)
    {
        
    }

    public async Task<IEnumerable<Match>> GetAllMatchesAsync() =>
        await GetAllAsync().Result.OrderBy(match => match.Id).ToListAsync();
    
    public async Task<IEnumerable<Match>> GetAllMatchesForSportCategoryAsync(int sportCategoryId) =>
        await GetAllAsync().Result.Where(match => match.SportCategoryId.Equals(sportCategoryId)).OrderBy(match => match.Id).ToListAsync();

    public async Task<Match?> GetMatchAsync(int id) =>
        await GetAsync(match => match.Id.Equals(id)).Result.SingleOrDefaultAsync();

    public async Task CreateMatchAsync(Match match)
    {
        await CreateAsync(match);
        await SaveChangesAsync();
    }

    public async Task UpdateMatchAsync(int id, Match match)
    {
        var changedMatch = await GetMatchAsync(id);
        if (changedMatch != null)
        {
            changedMatch.Number = match.Number;
            changedMatch.Rivals = match.Rivals;
            changedMatch.TournamentId = match.TournamentId;
            changedMatch.SportCategoryId = match.SportCategoryId;
            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Данные не найдены.");
        }
    }


    public async Task DeleteMatchAsync(int id)
    {
        var match = await GetMatchAsync(id);
        if (match != null)
        {
            await DeleteAsync(match);
            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Данные не найдены.");
        }
    }
}