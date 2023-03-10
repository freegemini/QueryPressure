using QueryPressure.App.Interfaces;
using QueryPressure.Core.Interfaces;

public class ProviderManager
{
  private readonly Dictionary<string, Provider> _providers;
  public ProviderManager(ICreator<IConnectionProvider>[] creators)
  {
    _providers = creators.ToDictionary(x => x.Type, x => new Provider(x));
  }
  public Provider GetProvider(string providerName)
  {
    return _providers[providerName];
  }
}
