using PeopleRegister.Domain.Entities;

namespace PeopleRegister.Domain.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task Add(TEntity obj);
    Task Update(TEntity obj);
    Task Remove(TEntity obj);
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetById(Guid id);
}
