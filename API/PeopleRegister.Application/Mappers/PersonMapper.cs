using AutoMapper;
using PeopleRegister.Application.DTOs;
using PeopleRegister.Domain.Entities;

namespace PeopleRegister.Application.Mappers;

public class PersonMapper : Profile
{
    public PersonMapper()
    {
        CreateMap<Person, PersonDTO>().ReverseMap();
        CreateMap<AddPersonDTO, Person>();
    }
}
