using PeopleRegister.Application.DTOs;
using PeopleRegister.Domain.Entities;

namespace PeopleRegister.Application.Interfaces;

public interface IPersonMapper
{
    Person MapperDtoToEntity(AddPersonDTO costumerDto);
    AddPersonDTO MapperEntityToDto(Person costumer);
}
