using System.ComponentModel;
using System.Text.Json;
using PutridParrot.Results;
using Spectre.Console;
using Spectre.Console.Cli;
using XKube.Services;
using XKube.ViewModelExtensions;

namespace XKube.Commands;

public class GetEventCommands(IKubernetesClientService kubernetesClientServices) : AsyncCommand<GetEventCommands.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [CommandOption("-n|--namespace")]
        [Description("Filter Events by namespace")]
        public string? Namespace { get; set; }
        [CommandOption("-a|--all-namespaces")]
        [Description("Show across all namespaces")]
        public bool AllNamespaces { get; set; } = false;
        [CommandOption("-o|--output")]
        [Description("Returns data in the specified format")]
        public OutputFormat Output { get; set; }
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var items = await kubernetesClientServices.GetEventsAsync(settings.AllNamespaces ? null : settings.Namespace ?? kubernetesClientServices.CurrentNamespace);
        if (items is IFailure failure)
        {
            AnsiConsole.MarkupLine($"[red]Error: {failure.FailureMessage()}[/]");
            return 1;
        }

        var list = items.Value.ToViewModel();
        if (settings.Output == OutputFormat.Json)
        {
            Console.Write(JsonSerializer.Serialize(list));
        }
        else
        {
            AnsiConsole.Write(list.ToGrid());
        }

        return 0;
    }
}