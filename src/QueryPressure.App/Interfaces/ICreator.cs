using QueryPressure.App.Arguments;

namespace QueryPressure.App.Interfaces;

using Core.Interfaces;

public interface ICreator<out T>
{
  string Type { get; }

  T Create(ArgumentsSection argumentsSection);
}
public record ArgumentDescriptor(string Name, string Type);

public interface IProfileCreator : ICreator<IProfile>
{
  ArgumentDescriptor[] Arguments { get; }
}
