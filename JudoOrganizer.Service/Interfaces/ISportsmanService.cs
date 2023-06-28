using JudoOrganizer.Data.Models;

namespace JudoOrganizer.Service.Interfaces;

public interface ISportsmanService
{
    Task<IEnumerable<Sportsman>> GetAllSportsmenAsync();
    Task<IEnumerable<Sportsman>> GetAllSportsmenWithPaginationAsync(int pageIndex, int pageSize);
    Task<IEnumerable<Sportsman>> GetAllSportsmenForClubAsync(int clubId);
    Task<IEnumerable<Sportsman>> GetAllSportsmenForCoachAsync(int coachId);
    Task<Sportsman?> GetSportsmanAsync(int id);
    Task CreateSportsmanAsync(Sportsman sportsman);
    Task UpdateSportsmanAsync(int id, Sportsman sportsman);
    Task DeleteSportsmanAsync(int id);
}