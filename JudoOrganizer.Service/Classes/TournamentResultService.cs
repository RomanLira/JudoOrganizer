using System.Linq;
using JudoOrganizer.Data;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Repository.Classes;
using JudoOrganizer.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JudoOrganizer.Service.Classes;

public class TournamentResultService : Repository<TournamentResult>, ITournamentResultService
{
    public TournamentResultService(ApplicationContext applicationContext) : base(applicationContext)
    {
        
    }

    public async Task<IEnumerable<TournamentResult>> GetAllTournamentResultsAsync() =>
        await GetAllAsync().Result.OrderBy(tournamentResult => tournamentResult.Id).ToListAsync();

    public async Task<TournamentResult?> GetTournamentResultAsync(int id) =>
        await GetAsync(tournamentResult => tournamentResult.Id.Equals(id)).Result.SingleOrDefaultAsync();

    public async Task CreateTournamentResultAsync(TournamentResult tournamentResult)
    {
        await CreateAsync(tournamentResult);
        await SaveChangesAsync();
    }

    public async Task UpdateTournamentResultAsync(int id, TournamentResult tournamentResult)
    {
        var changedTournamentResult = await GetTournamentResultAsync(id);
        if (changedTournamentResult != null)
        {
            changedTournamentResult.Date = tournamentResult.Date;
            changedTournamentResult.TournamentId = tournamentResult.TournamentId;

            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Данные не найдены.");
        }
    }


    public async Task DeleteTournamentResultAsync(int id)
    {
        var tournamentResult = await GetTournamentResultAsync(id);
        if (tournamentResult != null)
        {
            await DeleteAsync(tournamentResult);
            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Данные не найдены.");
        }
    }
}