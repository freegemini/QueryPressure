using Autofac;

namespace QueryPressure.Redis.App;

using QueryPressure.Core;
using QueryPressure.Core.Interfaces;

public sealed class RedisAppModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<RedisConnectionProviderCreator>()
      .AsImplementedInterfaces();
    builder.RegisterInstance(new ProviderInfo("Redis"))
      .As<IProviderInfo>();
  }
}
