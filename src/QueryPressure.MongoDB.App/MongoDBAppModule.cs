using Autofac;

namespace QueryPressure.MongoDB.App;

using QueryPressure.Core;
using QueryPressure.Core.Interfaces;

public class MongoDBAppModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<MongoDBConnectionProviderCreator>()
        .AsImplementedInterfaces();
    builder.RegisterInstance(new ProviderInfo("SqlServer"))
      .As<IProviderInfo>();
  }
}
