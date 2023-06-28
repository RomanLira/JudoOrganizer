using JudoOrganizer.Data.Models;

namespace JudoOrganizer.Service.Interfaces;

public interface IMatchService
{
    Task<IEnumerable<Match>> GetAllMatchesAsync();
    Task<IEnumerable<Match>> GetAllMatchesForSportCategoryAsync(int sportCategoryId);
    Task<Match?> GetMatchAsync(int id);
    Task CreateMatchAsync(Match match);
    Task UpdateMatchAsync(int id, Match match);
    Task DeleteMatchAsync(int id);
}