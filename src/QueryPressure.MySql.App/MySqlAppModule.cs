using Autofac;

namespace QueryPressure.MySql.App;

using QueryPressure.Core;
using QueryPressure.Core.Interfaces;

public class MySqlAppModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<MySqlConnectionProviderCreator>()
      .AsImplementedInterfaces();
    builder.RegisterInstance(new ProviderInfo("MySql"))
      .As<IProviderInfo>();
  }
}
