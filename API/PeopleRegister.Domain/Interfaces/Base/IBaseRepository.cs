using PeopleRegister.Domain.Entities;
using System.Linq.Expressions;

namespace PeopleRegister.Domain.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task Add(TEntity obj);
    Task Update(TEntity obj);
    Task Remove(TEntity obj);
    Task<IEnumerable<TEntity>> GetMany(int Page, int PageItems, Expression<Func<TEntity, bool>> query);
    Task<TEntity> GetById(Guid id);
    Task<int> GetAmount(Expression<Func<TEntity, bool>> query);
}
