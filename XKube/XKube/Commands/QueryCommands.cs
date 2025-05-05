using System.ComponentModel;
using KustoLoco.Core;
using KustoLoco.Core.Settings;
using KustoLoco.Rendering.ScottPlot;
using Spectre.Console;
using Spectre.Console.Cli;
using XKube.Commands.Shared;
using XKube.Services;
using XKube.Ui;

namespace XKube.Commands;

internal class QueryCommands(IKubernetesClientService kubernetesClientServices) : AsyncCommand<QueryCommands.Settings>
{
    public sealed class Settings : NamespaceCommandSettings
    {
        [CommandArgument(0, "<query>")]
        [Description("The query string to execute")]
        public string? Query { get; set; }
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        if (string.IsNullOrWhiteSpace(settings.Query))
        {
            AnsiConsole.MarkupLine("[red]Error: Query cannot be null or empty.[/]");
            return 1;
        }

        if (!string.IsNullOrEmpty(settings.Cluster))
        {
            kubernetesClientServices.LoadConfig(null, settings.Cluster, null);
        }

        var ctx = new KustoQueryContext();
        await ctx.RegisterTables(kubernetesClientServices, settings.AllNamespaces ? null : settings.Namespace ?? kubernetesClientServices.CurrentNamespace);

        var result = await ctx.RunQuery(settings.Query);
        if (!string.IsNullOrEmpty(result.Error))
        {
            AnsiConsole.MarkupLine($"[red]Error: {result.Error}[/]");
            return 1;
        }

        if (result.IsChart)
        {
            Console.WriteLine(ScottPlotKustoResultRenderer.RenderToSixelWithPad(result, new KustoSettingsProvider(), 3));
            return 0;
        }

        var dataTable = result.ToDataTable();
        AnsiConsole.Write(dataTable.CreateGrid());

        return 0;
    }
}