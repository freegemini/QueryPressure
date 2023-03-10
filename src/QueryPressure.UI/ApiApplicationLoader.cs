using Autofac;
using QueryPressure.App;

public class ApiApplicationLoader:ApplicationLoader
{
  public override ContainerBuilder Load(ContainerBuilder builder)
  {
    builder.RegisterType<ProviderManager>()
      .AsSelf()
      .SingleInstance();
    return base.Load(builder);
  }
}
