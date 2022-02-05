using AutoMapper;
using PeopleRegister.Application.Interfaces;
using PeopleRegister.Domain.Entities;
using PeopleRegister.Domain.Interfaces;

namespace PeopleRegister.Application.Services;

public class BaseApplicationService<TDTO, TAddDTO, TEntity> : IBaseApplicationService<TDTO, TAddDTO> 
    where TDTO : class
    where TAddDTO : class
    where TEntity : BaseEntity
{
    private readonly IBaseRepository<TEntity> BaseRepository;
    private readonly IMapper Mapper;

    public BaseApplicationService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
    {
        BaseRepository = baseRepository;
        Mapper = mapper;
    }

    public async Task<Guid> Add(TAddDTO obj)
    {
        var entity = Mapper.Map<TEntity>(obj);
        await BaseRepository.Add(entity);
        return entity.Id;
    }

    public async Task<IEnumerable<TDTO>> GetAll()
    {
        var entityItems = await BaseRepository.GetAll();
        return Mapper.Map<IEnumerable<TDTO>>(entityItems);
    }

    public async Task<TDTO> GetById(Guid id)
    {
        var entity = await BaseRepository.GetById(id);
        return Mapper.Map<TDTO>(entity);
    }

    public async Task Remove(Guid id)
    {
        var entity = await BaseRepository.GetById(id);
        await BaseRepository.Remove(entity);
    }

    public async Task Update(TDTO obj)
    {
        var entity = Mapper.Map<TEntity>(obj);
        await BaseRepository.Update(entity);
    }
}
