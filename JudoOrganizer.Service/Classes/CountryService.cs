using JudoOrganizer.Data;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Repository.Classes;
using JudoOrganizer.Repository.Interfaces;
using JudoOrganizer.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JudoOrganizer.Service.Classes;

public class CountryService : Repository<Country>, ICountryService
{
    public CountryService(ApplicationContext applicationContext) : base(applicationContext)
    {
        
    }

    public async Task<IEnumerable<Country>> GetAllCountriesAsync() =>
        await GetAllAsync().Result.OrderBy(country => country.Name).ToListAsync();

    public async Task<Country?> GetCountryAsync(int id) =>
        await GetAsync(country => country.Id.Equals(id)).Result.SingleOrDefaultAsync();

    public async Task CreateCountryAsync(Country country)
    {
        await CreateAsync(country);
        await SaveChangesAsync();
    }

    public async Task UpdateCountryAsync(int id, Country country)
    {
        var changedCountry = await GetCountryAsync(id);
        await DeleteCountryAsync(changedCountry.Id);
        await CreateCountryAsync(country);
        await SaveChangesAsync();
    }

    public async Task DeleteCountryAsync(int id)
    {
        var country = await GetCountryAsync(id);
        await DeleteAsync(country);
        await SaveChangesAsync();
    }
}