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

    public override async Task<IEnumerable<PersonDTO>> GetManyPaginated(int page, int pageItems, string search)
    {
        Expression<Func<Person, bool>> query = p =>
            !string.IsNullOrWhiteSpace(search) && (
            p.Name.Contains(search) ||
            p.LastName.Contains(search) ||
            p.Nacionality.Contains(search) ||
            p.State.Contains(search) ||
            p.City.Contains(search) ||
            p.CPF.Contains(search) ||
            p.Phone.Contains(search) ||
            p.CEP.Contains(search) ||
            p.Address.Contains(search) ||
            p.Email.Contains(search));

        var entityItems = await PersonRepository.GetManyPaginated(page, pageItems, query);
        return Mapper.Map<IEnumerable<PersonDTO>>(entityItems);
    }
}
