using AutoMapper;
using PeopleRegister.Application.Interfaces;
using PeopleRegister.Domain.Entities;
using PeopleRegister.Domain.Exceptions;
using PeopleRegister.Domain.Interfaces;
using PeopleRegister.Domain.Notifications;
using System.Linq.Expressions;

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

    public virtual async Task<Guid> Add(TAddDTO obj)
    {
        var entity = Mapper.Map<TEntity>(obj);

        if (!entity.IsValid)
        {
            throw new BadRequestException(entity.Notifications);
        }

        await BaseRepository.Add(entity);
        return entity.Id;
    }

    public virtual async Task<IEnumerable<TDTO>> GetManyPaginated(int Page, int PageItems, string Search)
    {
        var entityItems = await BaseRepository.GetManyPaginated(Page, PageItems, null);
        return Mapper.Map<IEnumerable<TDTO>>(entityItems);
    }

    public virtual async Task<TDTO> GetById(Guid id)
    {
        var entity = await BaseRepository.GetById(id);

        if (entity == null)
        {
            throw new NotFoundException(Messages.PersonNotFound);
        }

        return Mapper.Map<TDTO>(entity);
    }

    public virtual async Task Remove(Guid id)
    {
        var entity = await BaseRepository.GetById(id);

        if (entity == null)
        {
            throw new NotFoundException(Messages.PersonNotFound);
        }

        await BaseRepository.Remove(entity);
    }

    public virtual async Task Update(TDTO obj)
    {
        var entity = Mapper.Map<TEntity>(obj);

        if (await BaseRepository.GetById(entity.Id) == null)
        {
            throw new NotFoundException(Messages.PersonNotFound);
        }
                
        await BaseRepository.Update(entity);
    }
}
