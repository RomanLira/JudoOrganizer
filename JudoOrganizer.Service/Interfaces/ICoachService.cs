using JudoOrganizer.Data.Models;

namespace JudoOrganizer.Service.Interfaces;

public interface ICoachService
{
    Task<IEnumerable<Coach>> GetAllCoachesAsync();
    Task<IEnumerable<Coach>> GetAllCoachesForClubAsync(int clubId);
    Task<Coach?> GetCoachAsync(int id);
    Task CreateCoachAsync(Coach coach);
    Task UpdateCoachAsync(int id, Coach coach);
    Task DeleteCoachAsync(int id);
}