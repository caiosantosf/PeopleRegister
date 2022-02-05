using PeopleRegister.Domain.Entities;
using PeopleRegister.Domain.Interfaces;

namespace PeopleRegister.Application.Services;

public class BaseApplicationService<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly IBaseRepository<TEntity> BaseRepository;

    public BaseApplicationService(IBaseRepository<TEntity> baseRepository)
    {
        BaseRepository = baseRepository;
    }

    public async Task Add(TEntity obj)
    {
        await BaseRepository.Add(obj);
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await BaseRepository.GetAll();
    }

    public async Task<TEntity> GetById(int id)
    {
        return await BaseRepository.GetById(id);
    }

    public async Task Remove(TEntity obj)
    {
        await BaseRepository.Remove(obj);
    }

    public async Task Update(TEntity obj)
    {
        await BaseRepository.Update(obj);
    }
}
