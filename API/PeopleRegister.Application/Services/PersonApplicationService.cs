using AutoMapper;
using PeopleRegister.Application.DTOs;
using PeopleRegister.Application.Interfaces;
using PeopleRegister.Domain.Entities;
using PeopleRegister.Domain.Interfaces;
using PeopleRegister.Domain.Notifications;
using System.Linq.Expressions;

namespace PeopleRegister.Application.Services;

public class PersonApplicationService : BaseApplicationService<PersonDTO, AddPersonDTO, Person>, IPersonApplicationService
{
    IPersonRepository PersonRepository;
    IMapper Mapper;

    public PersonApplicationService(IPersonRepository personRepository, IMapper mapper) : base(personRepository, mapper)
    {
        Mapper = mapper;
        PersonRepository = personRepository;
    }

    public async Task<IEnumerable<PersonDTO>> GetFiltered(GetPeopleDTO getPeopleDTO)
    {
        Expression<Func<Person, bool>> query = person => person.CPF == getPeopleDTO.CPF;
        var entityItems = await PersonRepository.GetFiltered(query);
        return Mapper.Map<IEnumerable<PersonDTO>>(entityItems);
    }

    public override async Task<Guid> Add(AddPersonDTO addPersonDTO)
    {
        var getPeopleDTO = new GetPeopleDTO
        {
            CPF = addPersonDTO.CPF,
        };

        if (GetFiltered(getPeopleDTO).Result.Any())
            throw new Exception(Messages.CPFJaCadastrado);

        return await base.Add(addPersonDTO);
    }
}
