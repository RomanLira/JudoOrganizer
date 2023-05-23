using JudoOrganizer.Data.Models;

namespace JudoOrganizer.Service.Interfaces;

public interface ICityService
{
    Task<IEnumerable<City>> GetAllCitiesAsync();
    Task<IEnumerable<City>> GetAllCitiesForCountryAsync(int countryId);
    Task<City?> GetCityAsync(int id);
    Task CreateCityAsync(City city);
    Task UpdateCityAsync(int id, City city);
    Task DeleteCityAsync(int id);
}