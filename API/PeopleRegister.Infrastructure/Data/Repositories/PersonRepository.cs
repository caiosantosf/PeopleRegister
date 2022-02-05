using PeopleRegister.Domain.Entities;
using PeopleRegister.Domain.Interfaces;

namespace PeopleRegister.Infrastructure.Data.Repositories;

public class PersonRepository : BaseRepository<Person>, IPersonRepository
{
    public PersonRepository(Context sqlServerContext) : base(sqlServerContext)
    {
    }
}
