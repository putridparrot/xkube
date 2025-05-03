using Spectre.Console.Cli;

namespace XKube.Injection;

public class TypeResolver(IServiceProvider provider) : ITypeResolver
{
    public object Resolve(Type? type) => provider.GetService(type);
}