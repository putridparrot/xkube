using PutridParrot.Results;
using Spectre.Console;
using Spectre.Console.Cli;
using XKube.Commands.Shared;
using XKube.Services;
using XKube.ViewModelExtensions;

namespace XKube.Commands;

public class GetApiResourceCommands(IKubernetesClientService kubernetesClientServices) : AsyncCommand<GetApiResourceCommands.Settings>
{
    public sealed class Settings : OutputCommandSettings;

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        if (!string.IsNullOrEmpty(settings.Cluster))
        {
            kubernetesClientServices.LoadConfig(null, settings.Cluster, null);
        }

        var items = await kubernetesClientServices.GetApiResourcesAsync();
        if (items is IFailure failure)
        {
            AnsiConsole.MarkupLine($"[red]Error: {failure.FailureMessage()}[/]");
            return 1;
        }

        var list = items.Value.ToViewModel();
        list.Write(settings.Output, models => models.ToGrid());

        return 0;
    }
}