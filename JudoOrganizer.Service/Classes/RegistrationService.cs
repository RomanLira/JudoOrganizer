using System.Linq;
using JudoOrganizer.Data;
using JudoOrganizer.Data.Models;
using JudoOrganizer.Service.Interfaces;
using JudoOrganizer.Repository.Classes;
using Microsoft.EntityFrameworkCore;

namespace JudoOrganizer.Service.Classes;

public class RegistrationService : Repository<Registration>, IRegistrationService
{
    public RegistrationService(ApplicationContext applicationContext) : base(applicationContext)
    {
        
    }

    public async Task<IEnumerable<Registration>> GetAllRegistrationsAsync() =>
        await GetAllAsync().Result.OrderBy(registration => registration.TournamentId).ToListAsync();

    public async Task<IEnumerable<Registration>> GetAllRegistrationsForTournamentAsync(int tournamentId) =>
        await GetAllAsync().Result.Where(registration => registration.TournamentId.Equals(tournamentId))
            .OrderBy(registration => registration.SportsmanId)
            .ToListAsync();

    public async Task<IEnumerable<Registration>> GetAllRegistrationsWithPaginationAsync(int pageIndex, int pageSize)
    {
        try
        {
            var registrations = await GetAllAsync();
            var pagedRegistrations = registrations.OrderBy(registration =>
                    registration.Date)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
            return pagedRegistrations.ToList();
        }
        catch(Exception ex)
        {
            throw new Exception("Error! " + ex.Message);
        }
    }
    
    public async Task<IEnumerable<Registration>> GetAllRegistrationsForTournamentWithPaginationAsync(int tournamentId, int pageIndex, int pageSize)
    {
        try
        {
            var registrations = await GetAllAsync();
            var pagedRegistrations = registrations.Where(registration => registration.TournamentId.Equals(tournamentId))
                .OrderBy(registration => registration.Date)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
            return pagedRegistrations.ToList();
        }
        catch(Exception ex)
        {
            throw new Exception("Error! " + ex.Message);
        }
    }
    
    public async Task<Registration?> GetRegistrationAsync(int id) =>
        await GetAsync(registration => registration.Id.Equals(id)).Result.SingleOrDefaultAsync();

    public async Task CreateRegistrationAsync(Registration registration)
    {
        await CreateAsync(registration);
        await SaveChangesAsync();
    }

    public async Task UpdateRegistrationAsync(int id, Registration registration)
    {
        var changedRegistration = await GetRegistrationAsync(id);
        if (changedRegistration != null)
        {
            changedRegistration.Date = registration.Date;
            changedRegistration.TournamentId = registration.TournamentId;
            changedRegistration.SportsmanId = registration.SportsmanId;
            changedRegistration.SportCategoryId = registration.SportCategoryId;

            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Данные не найдены.");
        }
    }


    public async Task DeleteRegistrationAsync(int id)
    {
        var registration = await GetRegistrationAsync(id);
        if (registration != null)
        {
            await DeleteAsync(registration);
            await SaveChangesAsync();
        }
        else
        {
            throw new Exception("Данные не найдены.");
        }
    }
}