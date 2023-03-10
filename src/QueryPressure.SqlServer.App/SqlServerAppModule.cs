using Autofac;

namespace QueryPressure.SqlServer.App
{
  using QueryPressure.Core;
  using QueryPressure.Core.Interfaces;

  public class SqlServerAppModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<SqlServerConnectionProviderCreator>()
        .AsImplementedInterfaces();
      builder.RegisterInstance(new ProviderInfo("SqlServer"))
        .As<IProviderInfo>();
    }
  }
}
