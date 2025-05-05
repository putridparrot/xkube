using System.Collections.Immutable;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text.Json;
using KustoLoco.Core;
using KustoLoco.Core.Settings;
using KustoLoco.Rendering.ScottPlot;
using PutridParrot.Results;
using Spectre.Console;
using Spectre.Console.Cli;
using XKube.Commands.Shared;
using XKube.QueryLanguage;
using XKube.Services;
using XKube.Ui;
using XKube.ViewModelExtensions;
using YamlDotNet.Core.Tokens;

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

        var ctx = new KustoQueryContext();
        ctx.WrapDataIntoTable("pods",
                (await kubernetesClientServices.GetPodsAsync()).Value.ToViewModel().ToImmutableArray())
            .WrapDataIntoTable("services",
                (await kubernetesClientServices.GetServicesAsync()).Value.ToViewModel().ToImmutableArray())
            .WrapDataIntoTable("deployments",
                (await kubernetesClientServices.GetDeploymentsAsync()).Value.ToViewModel().ToImmutableArray())
            .WrapDataIntoTable("ingresses",
                (await kubernetesClientServices.GetIngressesAsync()).Value.ToViewModel().ToImmutableArray())
            .WrapDataIntoTable("nodes",
                (await kubernetesClientServices.GetNodesAsync()).Value.ToViewModel().ToImmutableArray());

        var result = await ctx.RunQuery(settings.Query);
        if (!string.IsNullOrEmpty(result.Error))
        {
            AnsiConsole.MarkupLine($"[red]Error: {result.Error}[/]");
            return 1;
        }

        if (result.IsChart)
        {
            Console.WriteLine(ScottPlotKustoResultRenderer.RenderToSixelWithPad(result, new KustoSettingsProvider(), 3));
        }

        var dataTable = result.ToDataTable();
        AnsiConsole.Write(dataTable.CreateGrid());

        return 0;
    }
}