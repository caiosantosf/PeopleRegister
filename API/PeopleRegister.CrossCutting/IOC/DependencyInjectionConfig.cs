using Microsoft.Extensions.DependencyInjection;
using PeopleRegister.Application.Interfaces;
using PeopleRegister.Application.Services;
using PeopleRegister.Data.Repositories;
using PeopleRegister.Domain.Interfaces;

namespace PeopleRegister.CrossCutting.IOC;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDepencyInjections(this IServiceCollection services)
    {
        services.AddTransient<IPersonRepository, PersonRepository>();
        services.AddTransient<IPersonApplicationService, PersonApplicationService>();

        return services;
    }
}
