using PeopleRegister.Application.DTOs;

namespace PeopleRegister.Application.Interfaces;

public interface IPersonApplicationService : IBaseApplicationService<PersonDTO, AddPersonDTO>
{
}
