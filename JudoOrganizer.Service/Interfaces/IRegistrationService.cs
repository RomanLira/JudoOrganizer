using JudoOrganizer.Data.Models;

namespace JudoOrganizer.Service.Interfaces;

public interface IRegistrationService
{
    Task<IEnumerable<Registration>> GetAllRegistrationsAsync();
    Task<IEnumerable<Registration>> GetAllRegistrationsForTournamentAsync(int tournamentId);
    Task<IEnumerable<Registration>> GetAllRegistrationsWithPaginationAsync(int pageIndex, int pageSize);
    Task<IEnumerable<Registration>> GetAllRegistrationsForTournamentWithPaginationAsync(int tournamentId, int pageIndex, int pageSize);
    Task<Registration?> GetRegistrationAsync(int id);
    Task CreateRegistrationAsync(Registration registration);
    Task UpdateRegistrationAsync(int id, Registration registration);
    Task DeleteRegistrationAsync(int id);
}