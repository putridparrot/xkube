using System.ComponentModel;
using System.Text.Json;
using PutridParrot.Results;
using Spectre.Console;
using Spectre.Console.Cli;
using XKube.Services;
using XKube.ViewModelExtensions;

namespace XKube.Commands;

public class GetRoleBindingCommands(IKubernetesClientService kubernetesClientServices) : AsyncCommand<GetRoleBindingCommands.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [CommandOption("-n|--namespace")]
        [Description("Filter Role Bindings by namespace")]
        public string? Namespace { get; set; }
        [CommandOption("-o|--json")]
        [Description("Returns data as a JSON object")]
        public bool Json { get; set; }
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var items = await kubernetesClientServices.GetRoleBindingsAsync(settings.Namespace ?? kubernetesClientServices.CurrentNamespace);
        if (items is IFailure failure)
        {
            AnsiConsole.MarkupLine($"[red]Error: {failure.FailureMessage()}[/]");
            return 1;
        }

        var list = items.Value.ToViewModel();
        if (settings.Json)
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