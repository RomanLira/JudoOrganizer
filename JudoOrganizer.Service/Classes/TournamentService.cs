using System.Linq;
using JudoOrganizer.Data;
using JudoOrganizer.Data.Enums;
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
        await GetAllAsync().Result.OrderByDescending(tournament => tournament.Date).ToListAsync();

    public async Task<IEnumerable<Tournament>> GetAllTournamentsWithOpenedRegistrationAsync() =>
        await GetAllAsync().Result.Where(tournament => tournament.RegistrationStatus.Equals(RegistrationStatus.Opened))
            .OrderBy(tournament => tournament.Name)
            .ToListAsync();

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
        if (changedTournament != null)
        {
            changedTournament.Name = tournament.Name;
            changedTournament.Organizer = tournament.Organizer;
            changedTournament.Date = tournament.Date;
            changedTournament.Place = tournament.Place;
            changedTournament.RegistrationStatus = tournament.RegistrationStatus;

            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Турнир не найден.");
        }
    }
    
    public async Task UpdateTournamentRegistrationStatusAsync(int id)
    {
        var changedTournament = await GetTournamentAsync(id);
        if (changedTournament != null)
        {
            changedTournament.RegistrationStatus = RegistrationStatus.Closed;
            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Турнир не найден.");
        }
    }


    public async Task DeleteTournamentAsync(int id)
    {
        var tournament = await GetTournamentAsync(id);
        if (tournament != null)
        {
            await DeleteAsync(tournament);
            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Турнир не найден.");
        }
    }
}