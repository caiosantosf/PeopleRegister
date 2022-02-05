using Autofac;
using PeopleRegister.Domain.Interfaces;

namespace PeopleRegister.Infrastructure.CrossCutting
{
  public class ConfigurationIOC
  {
    public static void Load(ContainerBuilder builder)
    {
      /*builder.RegisterType<ApplicationServiceCostumer>().As<IApplicationServiceCostumer>();
      builder.RegisterType<ApplicationServiceProduct>().As<IApplicationServiceProduct>();

      builder.RegisterType<ServiceCostumer>().As<IServiceCostumer>();
      builder.RegisterType<ServiceProduct>().As<IServiceProduct>();

      builder.RegisterType<RepositoryCostumer>().As<IRepositoryCostumer>();
      builder.RegisterType<RepositoryProduct>().As<IRepositoryProduct>();

      builder.RegisterType<MapperCostumer>().As<IMapperCostumer>();
      builder.RegisterType<MapperProduct>().As<IMapperProduct>();*/
    }
  }
}