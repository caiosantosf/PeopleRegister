using AutoMapper;
using PeopleRegister.Application.Interfaces;
using PeopleRegister.Domain.Entities;
using PeopleRegister.Domain.Exceptions;
using PeopleRegister.Domain.Interfaces;
using PeopleRegister.Domain.Notifications;

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

        if (entity == null)
        {
            throw new NotFoundException(Messages.PersonNotFound);
        }

        return Mapper.Map<TDTO>(entity);
    }

    public async Task Remove(Guid id)
    {
        var entity = await BaseRepository.GetById(id);

        if (entity == null)
        {
            throw new NotFoundException(Messages.PersonNotFound);
        }

        await BaseRepository.Remove(entity);
    }

    public async Task Update(TDTO obj)
    {
        var entity = await BaseRepository.GetById(Mapper.Map<TEntity>(obj).Id);

        if (entity == null)
        {
            throw new NotFoundException(Messages.PersonNotFound);
        }
                
        await BaseRepository.Update(entity);
    }
}
