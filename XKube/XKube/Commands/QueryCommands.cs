using System.ComponentModel;
using System.Text.Json;
using PutridParrot.Results;
using Spectre.Console;
using Spectre.Console.Cli;
using XKube.QueryLanguage;
using XKube.Services;

namespace XKube.Commands;

internal class QueryCommands(IKubernetesClientService kubernetesClientServices) : AsyncCommand<QueryCommands.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [CommandArgument(0, "<query>")]
        [Description("The query string to execut")]
        public string? Query { get; set; }
    }

    public override Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        if (string.IsNullOrWhiteSpace(settings.Query))
        {
            AnsiConsole.MarkupLine("[red]Error: Query cannot be null or empty.[/]");
            return Task.FromResult(1);
        }

        var result = Query.Parse(settings.Query);

        return Task.FromResult(0);
    }
}