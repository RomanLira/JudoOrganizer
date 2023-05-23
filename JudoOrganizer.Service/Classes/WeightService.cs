using System.Linq;
using JudoOrganizer.Data;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Repository.Classes;
using JudoOrganizer.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JudoOrganizer.Service.Classes;

public class WeightService : Repository<Weight>, IWeightService
{
    public WeightService(ApplicationContext applicationContext) : base(applicationContext)
    {
        
    }

    public async Task<IEnumerable<Weight>> GetAllWeightsAsync() =>
        await GetAllAsync().Result.OrderBy(weight => weight.WeightValue).ToListAsync();
    
    public async Task<Weight?> GetWeightAsync(int id) =>
        await GetAsync(weight => weight.Id.Equals(id)).Result.SingleOrDefaultAsync();

    public async Task CreateWeightAsync(Weight weight)
    {
        await CreateAsync(weight);
        await SaveChangesAsync();
    }

    public async Task UpdateWeightAsync(int id, Weight weight)
    {
        var changedWeight = await GetWeightAsync(id);
        await DeleteWeightAsync(changedWeight.Id);
        await CreateWeightAsync(weight);
        await SaveChangesAsync();
    }

    public async Task DeleteWeightAsync(int id)
    {
        var weight = await GetWeightAsync(id);
        await DeleteAsync(weight);
        await SaveChangesAsync();
    }
}