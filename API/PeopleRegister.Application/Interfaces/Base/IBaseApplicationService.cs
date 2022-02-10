using PeopleRegister.Application.DTOs;

namespace PeopleRegister.Application.Interfaces;

public interface IBaseApplicationService<TDTO, TAddDTO> 
    where TDTO : class
    where TAddDTO : class
{
    Task<Guid> Add(TAddDTO obj); 
    Task Update(TDTO obj);
    Task Remove(Guid id);
    Task<ResponseListDTO<TDTO>> GetMany(int page, int pageItems, string search);
    Task<TDTO> GetById(Guid id);
}
