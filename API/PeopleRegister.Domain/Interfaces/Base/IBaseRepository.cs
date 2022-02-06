using PeopleRegister.Domain.Entities;
using System.Linq.Expressions;

namespace PeopleRegister.Domain.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task Add(TEntity obj);
    Task Update(TEntity obj);
    Task Remove(TEntity obj);
    Task<IEnumerable<TEntity>> GetManyPaginated(int Page, int PageItems, Expression<Func<TEntity, bool>> query);
    Task<IEnumerable<TEntity>> GetFiltered(Expression<Func<TEntity, bool>> query);
    Task<TEntity> GetById(Guid id);
}
