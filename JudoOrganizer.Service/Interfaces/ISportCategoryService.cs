using JudoOrganizer.Data.Models;

namespace JudoOrganizer.Service.Interfaces;

public interface ISportCategoryService
{
    Task<IEnumerable<SportCategory>> GetAllSportCategoriesAsync();
    Task<IEnumerable<SportCategory>> GetAllSportCategoriesForTournamentAsync(int tournamentId);
    Task<SportCategory?> GetSportCategoryAsync(int id);
    Task CreateSportCategoryAsync(SportCategory sportCategory);
    Task UpdateSportCategoryAsync(int id, SportCategory sportCategory);
    Task DeleteSportCategoryAsync(int id);
}