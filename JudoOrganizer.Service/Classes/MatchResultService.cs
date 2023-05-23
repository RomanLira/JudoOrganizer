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
    
    public async Task<IEnumerable<MatchResult>> GetAllMatchResultsForTournamentResultAsync(int tournamentResultId) =>
        await GetAllAsync().Result.Where(matchResult => matchResult.TournamentResultId.Equals(tournamentResultId))
            .OrderBy(matchResult => matchResult.Id)
            .ToListAsync();

    public async Task<MatchResult?> GetMatchResultAsync(int id) =>
        await GetAsync(matchResult => matchResult.Id.Equals(id)).Result.SingleOrDefaultAsync();

    public async Task CreateMatchResultAsync(MatchResult matchResult)
    {
        await CreateAsync(matchResult);
        await SaveChangesAsync();
    }

    public async Task UpdateMatchResultAsync(int id, MatchResult matchResult)
    {
        var changedMatchResult = await GetMatchResultAsync(id);
        await DeleteMatchResultAsync(changedMatchResult.Id);
        await CreateMatchResultAsync(matchResult);
        await SaveChangesAsync();
    }

    public async Task DeleteMatchResultAsync(int id)
    {
        var matchResult = await GetMatchResultAsync(id);
        await DeleteAsync(matchResult);
        await SaveChangesAsync();
    }
}