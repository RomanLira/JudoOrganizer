using JudoOrganizer.Data;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Repository.Interfaces;
using JudoOrganizer.Repository.Classes;
using JudoOrganizer.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JudoOrganizer.Service.Classes;

public class CityService : Repository<City>, ICityService
{
    public CityService(ApplicationContext applicationContext) : base(applicationContext)
    {
        
    }

    public async Task<IEnumerable<City>> GetAllCitiesAsync() =>
        await GetAllAsync().Result.OrderBy(city => city.Name).ToListAsync();

    public async Task<IEnumerable<City>> GetAllCitiesForCountryAsync(int countryId) =>
        await GetAllAsync().Result.Where(city => city.CountryId.Equals(countryId)).OrderBy(city => city.Name)
            .ToListAsync();

    public async Task<City?> GetCityAsync(int id) =>
        await GetAsync(city => city.Id.Equals(id)).Result.SingleOrDefaultAsync();

    public async Task CreateCityAsync(City city)
    {
        await CreateAsync(city);
        await SaveChangesAsync();
    }

    public async Task UpdateCityAsync(int id, City city)
    {
        var changedCity = await GetCityAsync(id);
        if (changedCity != null)
        {
            changedCity.Name = city.Name;
            changedCity.CountryId = city.CountryId;

            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Город не найден.");
        }
    }


    public async Task DeleteCityAsync(int id)
    {
        var city = await GetCityAsync(id);
        if (city != null)
        {
            await DeleteAsync(city);
            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Город не найден.");
        }
    }
}