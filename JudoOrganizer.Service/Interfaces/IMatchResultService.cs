using JudoOrganizer.Data.Models;

namespace JudoOrganizer.Service.Interfaces;

public interface IMatchResultService
{
    Task<IEnumerable<MatchResult>> GetAllMatchResultsAsync();
    Task<IEnumerable<MatchResult>> GetAllMatchResultsForSportsmanAsync(int sportsmanId);
    Task<MatchResult?> GetMatchResultAsync(int id);
    Task<MatchResult?> GetMatchResultForMatchIdAsync(int matchId);
    Task CreateMatchResultAsync(MatchResult matchResult);
    Task UpdateMatchResultAsync(int id, MatchResult matchResult);
    Task DeleteMatchResultAsync(int id);
}