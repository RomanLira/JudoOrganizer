using System.Linq;
using JudoOrganizer.Data;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Repository.Classes;
using JudoOrganizer.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JudoOrganizer.Service.Classes;

public class TournamentService : Repository<Tournament>, ITournamentService
{
    public TournamentService(ApplicationContext applicationContext) : base(applicationContext)
    {
        
    }

    public async Task<IEnumerable<Tournament>> GetAllTournamentsAsync() =>
        await GetAllAsync().Result.OrderBy(tournament => tournament.Name).ToListAsync();

    public async Task<Tournament?> GetTournamentAsync(int id) =>
        await GetAsync(tournament => tournament.Id.Equals(id)).Result.SingleOrDefaultAsync();

    public async Task CreateTournamentAsync(Tournament tournament)
    {
        await CreateAsync(tournament);
        await SaveChangesAsync();
    }

    public async Task UpdateTournamentAsync(int id, Tournament tournament)
    {
        var changedTournament = await GetTournamentAsync(id);
        await DeleteTournamentAsync(changedTournament.Id);
        await CreateTournamentAsync(tournament);
        await SaveChangesAsync();
    }

    public async Task DeleteTournamentAsync(int id)
    {
        var tournament = await GetTournamentAsync(id);
        await DeleteAsync(tournament);
        await SaveChangesAsync();
    }
}