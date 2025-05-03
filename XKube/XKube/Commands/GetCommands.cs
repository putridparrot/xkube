using Spectre.Console;
using Spectre.Console.Cli;
using XKube.Services;

namespace XKube.Commands;

internal class GetCommands(IKubernetesClientService kubernetesClientServices) : Command<GetCommands.Settings>
{
    public sealed class Settings : CommandSettings
    {
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        AnsiConsole.Markup("[green]Available list options: pods, nodes, services[/]");
        return 0;
    }
}