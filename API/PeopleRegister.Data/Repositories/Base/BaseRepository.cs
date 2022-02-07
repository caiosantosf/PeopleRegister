using Microsoft.EntityFrameworkCore;
using PeopleRegister.Domain.Entities;
using PeopleRegister.Domain.Interfaces;
using System.Linq;
using System.Linq.Expressions;

namespace PeopleRegister.Data.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly Context context;

    public BaseRepository(Context sqlServerContext)
    {
        context = sqlServerContext;
    }

    public async Task Add(TEntity obj)
    {
        await context.Set<TEntity>().AddAsync(obj);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> GetManyPaginated(int Page, int PageItems, Expression<Func<TEntity, bool>> query)
    {
        return await context.Set<TEntity>().Where(query).Skip((Page - 1) * PageItems).Take(PageItems).ToListAsync();
    }

    public async Task<TEntity> GetById(Guid id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetFiltered(Expression<Func<TEntity, bool>> query)
    {
        return await context.Set<TEntity>().Where(query).ToListAsync();
    }

    public async Task Remove(TEntity obj)
    {
        context.Set<TEntity>().Remove(obj);
        await context.SaveChangesAsync();
    }

    public async Task Update(TEntity obj)
    {
        context.ChangeTracker.Clear();
        context.Set<TEntity>().Update(obj);
        await context.SaveChangesAsync();
    }
}