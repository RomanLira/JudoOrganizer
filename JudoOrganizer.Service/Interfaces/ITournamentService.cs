using JudoOrganizer.Data.Models;

namespace JudoOrganizer.Service.Interfaces;

public interface ITournamentService
{
    Task<IEnumerable<Tournament>> GetAllTournamentsAsync(); 
    Task<IEnumerable<Tournament>> GetAllTournamentsWithOpenedRegistrationAsync();
    Task<Tournament?> GetTournamentAsync(int id);
    Task CreateTournamentAsync(Tournament tournament);
    Task UpdateTournamentAsync(int id, Tournament tournament);
    Task UpdateTournamentRegistrationStatusAsync(int id);
    Task DeleteTournamentAsync(int id);
}