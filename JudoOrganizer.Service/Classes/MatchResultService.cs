using System.Linq;
using JudoOrganizer.Data;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Repository.Classes;
using JudoOrganizer.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JudoOrganizer.Service.Classes;

public class MatchResultService : Repository<MatchResult>, IMatchResultService
{
    public MatchResultService(ApplicationContext applicationContext) : base(applicationContext)
    {
        
    }

    public async Task<IEnumerable<MatchResult>> GetAllMatchResultsAsync() =>
        await GetAllAsync().Result.OrderBy(matchResult => matchResult.Id).ToListAsync();

    public async Task<IEnumerable<MatchResult>> GetAllMatchResultsForSportsmanAsync(int sportsmanId) =>
        await GetAllAsync().Result.Where(matchResult => matchResult.WinnerId.Equals(sportsmanId))
            .OrderBy(matchResult => matchResult.Id)
            .ToListAsync();
    
    public async Task<MatchResult?> GetMatchResultAsync(int id) =>
        await GetAsync(matchResult => matchResult.Id.Equals(id)).Result.SingleOrDefaultAsync();
    
    public async Task<MatchResult?> GetMatchResultForMatchIdAsync(int matchId) =>
        await GetAsync(matchResult => matchResult.MatchId.Equals(matchId)).Result.SingleOrDefaultAsync();

    public async Task CreateMatchResultAsync(MatchResult matchResult)
    {
        await CreateAsync(matchResult);
        await SaveChangesAsync();
    }

    public async Task UpdateMatchResultAsync(int id, MatchResult matchResult)
    {
        var changedMatchResult = await GetMatchResultAsync(id);
        if (changedMatchResult != null)
        {
            changedMatchResult.Date = matchResult.Date;
            changedMatchResult.Round = matchResult.Round;
            changedMatchResult.WinnerId = matchResult.WinnerId;
            changedMatchResult.MatchId = matchResult.MatchId;

            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Данные не найдены.");
        }
    }


    public async Task DeleteMatchResultAsync(int id)
    {
        var matchResult = await GetMatchResultAsync(id);
        if (matchResult != null)
        {
            await DeleteAsync(matchResult);
            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Данные не найдены.");
        }
    }
}