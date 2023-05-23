using JudoOrganizer.Data.Models;

namespace JudoOrganizer.Service.Interfaces;

public interface IClubService
{
    Task<IEnumerable<Club>> GetAllClubsAsync();
    Task<IEnumerable<Club>> GetAllClubsForCityAsync(int cityId);
    Task<Club?> GetClubAsync(int id);
    Task CreateClubAsync(Club club);
    Task UpdateClubAsync(int id, Club club);
    Task DeleteClubAsync(int id);
}