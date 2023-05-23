using JudoOrganizer.Data.Models;

namespace JudoOrganizer.Service.Interfaces;

public interface ICountryService
{
    Task<IEnumerable<Country>> GetAllCountriesAsync();
    Task<Country?> GetCountryAsync(int id);
    Task CreateCountryAsync(Country country);
    Task UpdateCountryAsync(int id, Country country);
    Task DeleteCountryAsync(int id);
}