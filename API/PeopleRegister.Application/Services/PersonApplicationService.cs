using AutoMapper;
using PeopleRegister.Application.DTOs;
using PeopleRegister.Application.Interfaces;
using PeopleRegister.Domain.Entities;
using PeopleRegister.Domain.Interfaces;

namespace PeopleRegister.Application.Services;

public class PersonApplicationService : BaseApplicationService<PersonDTO, AddPersonDTO, Person>, IPersonApplicationService
{
    public PersonApplicationService(IPersonRepository personRepository, IMapper mapper) : base(personRepository, mapper)
    {

    }
}
