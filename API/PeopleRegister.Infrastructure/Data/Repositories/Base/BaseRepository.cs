using Microsoft.EntityFrameworkCore;
using PeopleRegister.Domain.Interfaces;

namespace PeopleRegister.Infrastructure.Data.Repositories;

public class BaseRepository<TEntity> : IBaseOperations<TEntity> where TEntity : class
{
    private readonly SqlServerContext context;

    public BaseRepository(SqlServerContext sqlServerContext)
    {
        context = sqlServerContext;
    }

    public async Task Add(TEntity obj)
    {
        try
        {
            await context.Set<TEntity>().AddAsync(obj);
            await context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetById(int id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }

    public async Task Remove(TEntity obj)
    {
        try
        {
            context.Set<TEntity>().Remove(obj);
            await context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task Update(TEntity obj)
    {
        try
        {
            context.Set<TEntity>().Update(obj);
            await context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}