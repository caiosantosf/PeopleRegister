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
    private readonly IPersonRepository PersonRepository;
    private readonly IMapper Mapper;

    public PersonApplicationService(IPersonRepository personRepository, IMapper mapper) : base(personRepository, mapper)
    {
        Mapper = mapper;
        PersonRepository = personRepository;
    }

    public async Task<IEnumerable<PersonDTO>> GetByCPF(GetPeopleDTO getPeopleDTO)
    {
        Expression<Func<Person, bool>> query = person => person.CPF == getPeopleDTO.CPFFilter && string.IsNullOrWhiteSpace(getPeopleDTO.CPFFilter);

        var entityItems = await PersonRepository.GetFiltered(query);
        return Mapper.Map<IEnumerable<PersonDTO>>(entityItems);
    }

    public override async Task<Guid> Add(AddPersonDTO addPersonDTO)
    {
        var getPeopleDTO = new GetPeopleDTO
        {
            CPFFilter = addPersonDTO.CPF,
        };

        if (GetByCPF(getPeopleDTO).Result.Any())
            throw new Exception(Messages.CPFJaCadastrado);

        return await base.Add(addPersonDTO);
    }

    public override async Task<IEnumerable<PersonDTO>> GetManyPaginated(int Page, int PageItems, string Search)
    {
        Expression<Func<Person, bool>> query = p =>
            $"{p.Name}{p.LastName}{p.Nacionality}{p.State}{p.City}{p.CPF}{p.Phone}{p.CEP}{p.Address}{p.Email}".Contains(Search);

        var entityItems = await PersonRepository.GetManyPaginated(Page, PageItems, query);
        return Mapper.Map<IEnumerable<PersonDTO>>(entityItems);
    }
}
