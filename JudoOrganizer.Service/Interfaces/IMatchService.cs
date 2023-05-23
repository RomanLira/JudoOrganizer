using JudoOrganizer.Data.Models;

namespace JudoOrganizer.Service.Interfaces;

public interface IMatchService
{
    Task<IEnumerable<Match>> GetAllMatchesAsync();
    Task<IEnumerable<Match>> GetAllMatchesForSportsmanAsync(int sportsmanId);
    Task<Match?> GetMatchAsync(int id);
    Task CreateMatchAsync(Match match);
    Task UpdateMatchAsync(int id, Match match);
    Task DeleteMatchAsync(int id);
}