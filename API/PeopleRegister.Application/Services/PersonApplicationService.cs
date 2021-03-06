using AutoMapper;
using PeopleRegister.Application.DTOs;
using PeopleRegister.Application.Interfaces;
using PeopleRegister.Domain.Entities;
using PeopleRegister.Domain.Exceptions;
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

    public async Task<bool> HasPersonWithCPF(string cpf)
    { 
        return await PersonRepository.GetAmount(p => p.CPF == cpf && !string.IsNullOrWhiteSpace(cpf)) > 0;
    }

    public override async Task<Guid> Add(AddPersonDTO addPersonDTO)
    {
        if (await HasPersonWithCPF(addPersonDTO.CPF))
            throw new BadRequestException(Messages.CPFJaCadastrado);

        return await base.Add(addPersonDTO);
    }

    public override async Task<ResponseListDTO<PersonDTO>> GetMany(int page, int pageItems, string search)
    {
        Expression<Func<Person, bool>> query = p =>
            string.IsNullOrWhiteSpace(search) || (
                p.Name.Contains(search) ||
                p.LastName.Contains(search) ||
                p.Nacionality.Contains(search) ||
                p.State.Contains(search) ||
                p.City.Contains(search) ||
                p.CPF.Contains(search) ||
                p.Phone.Contains(search) ||
                p.CEP.Contains(search) ||
                p.Address.Contains(search) ||
                p.Email.Contains(search)
            );

        var people = await PersonRepository.GetMany(page, pageItems, query);
        var total = await PersonRepository.GetAmount(query);

        return new ResponseListDTO<PersonDTO>
        {
            Page = page,
            PageItems = people.Count(),
            TotalItems = total,
            Data = Mapper.Map<IEnumerable<PersonDTO>>(people)
        };
    }
}
