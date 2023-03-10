using Autofac;

namespace QueryPressure.Postgres.App;

using QueryPressure.Core;
using QueryPressure.Core.Interfaces;

public class PostgresAppModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<PostgresConnectionProviderCreator>()
      .AsImplementedInterfaces();
    builder.RegisterInstance(new ProviderInfo("Postgress"))
      .As<IProviderInfo>();
  }
}
