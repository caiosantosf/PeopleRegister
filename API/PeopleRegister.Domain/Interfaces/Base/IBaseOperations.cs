namespace PeopleRegister.Domain.Interfaces;

public interface IBaseOperations<TEntity> where TEntity : class
{
    Task Add(TEntity obj);
    Task Update(TEntity obj);
    Task Remove(TEntity obj);
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetById(int id);
}
