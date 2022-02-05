using Autofac;

namespace PeopleRegister.Infrastructure.CrossCutting
{
  public class ModuleIOC : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      ConfigurationIOC.Load(builder);
    }
  }
}