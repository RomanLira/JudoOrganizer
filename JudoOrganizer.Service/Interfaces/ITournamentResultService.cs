using JudoOrganizer.Data.Models;

namespace JudoOrganizer.Service.Interfaces;

public interface ITournamentResultService
{
    Task<IEnumerable<TournamentResult>> GetAllTournamentResultsAsync();
    Task<TournamentResult?> GetTournamentResultAsync(int id);
    Task CreateTournamentResultAsync(TournamentResult tournamentResult);
    Task UpdateTournamentResultAsync(int id, TournamentResult tournamentResult);
    Task DeleteTournamentResultAsync(int id);
}