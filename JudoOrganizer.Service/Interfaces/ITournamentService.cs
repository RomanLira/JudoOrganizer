using JudoOrganizer.Data.Models;

namespace JudoOrganizer.Service.Interfaces;

public interface ITournamentService
{
    Task<IEnumerable<Tournament>> GetAllTournamentsAsync();
    Task<Tournament?> GetTournamentAsync(int id);
    Task CreateTournamentAsync(Tournament tournament);
    Task UpdateTournamentAsync(int id, Tournament tournament);
    Task DeleteTournamentAsync(int id);
}