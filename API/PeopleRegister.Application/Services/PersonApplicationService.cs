using PeopleRegister.Domain.Entities;
using PeopleRegister.Domain.Interfaces;

namespace PeopleRegister.Application.Services;

public class PersonApplicationService : BaseApplicationService<Person>, IPersonApplicationService
{
    public PersonApplicationService(IPersonRepository personRepository) : base(personRepository)
    {

    }
}
