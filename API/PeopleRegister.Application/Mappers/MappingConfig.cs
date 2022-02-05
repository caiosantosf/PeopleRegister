using Microsoft.Extensions.DependencyInjection;

namespace PeopleRegister.Application.Mappers;

public static class MappingConfig
{
    public static IServiceCollection AddProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(PersonMapper));
            
        return services;
    }
}