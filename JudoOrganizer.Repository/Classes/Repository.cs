using System.Linq.Expressions;
using JudoOrganizer.Data;
using JudoOrganizer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JudoOrganizer.Repository.Classes;

public abstract class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationContext ApplicationContext;

    public Repository(ApplicationContext applicationContext)
    {
        ApplicationContext = applicationContext;
    }

    public async Task<IQueryable<T>> GetAsync(Expression<Func<T, bool>> expression) =>
        await Task.Run(() => ApplicationContext.Set<T>().Where(expression));

    public async Task<IQueryable<T>> GetAllAsync() =>
        await Task.Run(() => ApplicationContext.Set<T>());

    public async Task CreateAsync(T entity) =>
        await Task.Run(() => ApplicationContext.Set<T>().Add(entity));

    public async Task DeleteAsync(T entity) =>
        await Task.Run(() => ApplicationContext.Set<T>().Remove(entity));

    public async Task SaveChangesAsync() =>
        await Task.Run(() => ApplicationContext.SaveChangesAsync());
}