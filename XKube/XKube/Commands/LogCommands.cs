using System.ComponentModel;
using PutridParrot.Results;
using Spectre.Console;
using Spectre.Console.Cli;
using XKube.Services;

namespace XKube.Commands;

internal class LogCommands(IKubernetesClientService kubernetesClientServices) : AsyncCommand<LogCommands.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [Description("Log pods")]
        [CommandArgument(0, "[pods]")]
        public string? Pods { get; init; }

        [CommandOption("-f|--follow")]
        [Description("Follow")]
        [DefaultValue(true)]
        public bool Follow { get; init; }
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var items = await kubernetesClientServices.GetPodsAsync(kubernetesClientServices.CurrentNamespace);
        if(items is IFailure failure)
        {
            AnsiConsole.MarkupLine($"[red]Error: {failure.FailureMessage()}[/]");
            return 1;
        }

        return 0;
    }
}