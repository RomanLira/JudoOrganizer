using JudoOrganizer.Data;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using JudoOrganizer.Repository.Classes;
using Microsoft.EntityFrameworkCore;

namespace JudoOrganizer.Service.Classes;

public class WeighingService : Repository<Weighing>, IWeighingService
{
    public WeighingService(ApplicationContext applicationContext) : base(applicationContext)
    {
        
    }

    public async Task<IEnumerable<Weighing>> GetAllWeighingAsync() =>
        await GetAllAsync().Result.OrderBy(weighing => weighing.TournamentId).ToListAsync();

    public async Task<IEnumerable<Weighing>> GetAllWeighingForTournamentAsync(int tournamentId) =>
        await GetAllAsync().Result.Where(weighing => weighing.TournamentId.Equals(tournamentId))
            .OrderBy(weighing => weighing.SportsmanId)
            .ToListAsync();

    public async Task<Weighing?> GetWeighingAsync(int id) =>
        await GetAsync(weighing => weighing.Id.Equals(id)).Result.SingleOrDefaultAsync();

    public async Task CreateWeighingAsync(Weighing weighing)
    {
        await CreateAsync(weighing);
        await SaveChangesAsync();
    }

    public async Task UpdateWeighingAsync(int id, Weighing weighing)
    {
        var changedWeighing = await GetWeighingAsync(id);
        if (changedWeighing != null)
        {
            changedWeighing.Date = weighing.Date;
            changedWeighing.WeightValue = weighing.WeightValue;
            changedWeighing.TournamentId = weighing.TournamentId;
            changedWeighing.SportsmanId = weighing.SportsmanId;
            changedWeighing.SportCategoryId = weighing.SportCategoryId;

            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Данные не найдены.");
        }
    }


    public async Task DeleteWeighingAsync(int id)
    {
        var weighing = await GetWeighingAsync(id);
        if (weighing != null)
        {
            await DeleteAsync(weighing);
            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Данные не найдены.");
        }
    }
}