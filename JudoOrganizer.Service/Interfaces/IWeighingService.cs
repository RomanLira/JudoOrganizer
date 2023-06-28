using JudoOrganizer.Data.Models;

namespace JudoOrganizer.Service.Interfaces;

public interface IWeighingService
{
    Task<IEnumerable<Weighing>> GetAllWeighingAsync();
    Task<IEnumerable<Weighing>> GetAllWeighingForTournamentAsync(int tournamentId);
    Task<Weighing?> GetWeighingAsync(int id);
    Task CreateWeighingAsync(Weighing weighing);
    Task UpdateWeighingAsync(int id, Weighing weighing);
    Task DeleteWeighingAsync(int id);
}