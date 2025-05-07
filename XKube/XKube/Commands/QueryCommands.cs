using System.ComponentModel;
using System.Reflection;
using Kusto.Language;
using Kusto.Language.Symbols;
using Kusto.Language.Syntax;
using KustoLoco.Core;
using KustoLoco.Core.Settings;
using KustoLoco.Rendering.ScottPlot;
using Spectre.Console;
using Spectre.Console.Cli;
using XKube.Commands.Shared;
using XKube.Services;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.Commands;

internal class QueryCommands(IKubernetesClientService kubernetesClientServices) : AsyncCommand<QueryCommands.Settings>
{
    public sealed class Settings : NamespaceCommandSettings
    {
        [CommandArgument(0, "[query]")]
        [Description("The query string to execute")]
        public string? Query { get; set; }
        [CommandOption("-s|--script <file>")]
        [Description("Execute the supplied")]
        public string? Script { get; set; }
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        if (!string.IsNullOrEmpty(settings.Script))
        {
            settings.Query = await File.ReadAllTextAsync(settings.Script);
        }

        if (string.IsNullOrWhiteSpace(settings.Query))
        {
            AnsiConsole.MarkupLine("[red]Error: Either a query or script is required.[/]");
            return 1;
        }

        if (!string.IsNullOrEmpty(settings.Cluster))
        {
            kubernetesClientServices.LoadConfig(null, settings.Cluster, null);
        }

        // parse query to get tables and reduce the data added to the context
        var globalState = GetGlobalState();
        var code = KustoCode.ParseAndAnalyze(settings.Query, globalState);
        var tables = GetDatabaseTables(code);

        var ctx = new KustoQueryContext();
        await ctx.RegisterTables(tables, kubernetesClientServices, settings.AllNamespaces ? null : settings.Namespace ?? kubernetesClientServices.CurrentNamespace);

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

    private static GlobalState? GetGlobalState()
    {
        return GlobalState.Default.WithDatabase(
            new DatabaseSymbol("db",
                GetTables().ToArray<Symbol>())
        );
    }

    private static HashSet<string> GetDatabaseTables(KustoCode code)
    {
        var tables = new HashSet<string>();
        GatherTables(code.Syntax);
        return tables;

        void GatherTables(SyntaxNode root)
        {
            SyntaxElement.WalkNodes(root,
                fnBefore: n =>
                {
                    //Console.WriteLine($"{n.GetType().Name.ToString()} -> {n.Kind.ToString()} -> {n.ToString()}");
                    if (n.ReferencedSymbol is TableSymbol t
                        && code.Globals.IsDatabaseTable(t))
                    {
                        tables.Add(t.Name);
                    }
                    else if (n is Expression e
                             && e.ResultType is TableSymbol ts
                             && code.Globals.IsDatabaseTable(ts))
                    {
                        tables.Add(ts.Name);
                    }
                    else if (n.GetCalledFunctionBody() is { } body)
                    {
                        GatherTables(body);
                    }
                },
                fnDescend: n =>
                    // skip descending into function declarations since their bodies will be examined by the code above
                    !(n is FunctionDeclaration)
            );
        }
    }

    private static TableSymbol[] GetTables()
    {
        return
        [
            GetTable<ApiResourceViewModel>("apiresources"),
            GetTable<ApiServiceViewModel>("apiservices"),
            GetTable<CertificateSigningRequestViewModel>("certificatesigningrequests"),
            GetTable<ClusterRoleBindingViewModel>("clusterrolebindings"),
            GetTable<ClusterRoleViewModel>("clusterroles"),
            GetTable<ClusterTrustBundleViewModel>("clustertrustbundles"),
            GetTable<ComponentStatusViewModel>("componentstatuses"),
            GetTable<ConfigMapViewModel>("configmaps"),
            GetTable<ControllerRevisionViewModel>("controllerrevisions"),
            GetTable<ClusterViewModel>("clusters"),
            GetTable<CronJobViewModel>("cronjobs"),
            GetTable<CsiDriverViewModel>("csidrivers"),
            GetTable<CsiNodeViewModel>("csinodes"),
            GetTable<CsiStorageCapacityViewModel>("csistoragecapacity"),
            GetTable<CustomResourceDefinitionViewModel>("customresourcedefinitions"),
            GetTable<DaemonSetViewModel>("daemonsets"),
            GetTable<DeploymentViewModel>("deployments"),
            GetTable<DeviceClassViewModel>("deviceclasses"),
            GetTable<EndpointSliceViewModel>("endpointslices"),
            GetTable<EndpointViewModel>("endpoints"),
            GetTable<EventViewModel>("events"),
            GetTable<FlowSchemaViewModel>("flowschemas"),
            GetTable<HorizontalPodAutoscalerViewModel>("horizontalpodautoscalers"),
            GetTable<IngressClassViewModel>("ingressclasses"),
            GetTable<IngressViewModel>("ingresses"),
            GetTable<IpAddressViewModel>("ipaddresses"),
            GetTable<JobViewModel>("jobs"),
            GetTable<LeaseCandidateViewModel>("leasecandidates"),
            GetTable<LeaseViewModel>("leases"),
            GetTable<LimitRangeViewModel>("limitranges"),
            GetTable<MutatingAdmissionPolicyViewModel>("mutatingadmissionpolicies"),
            GetTable<MutatingAdmissionPolicyBindingViewModel>("mutatingadmissionpolicybindings"),
            GetTable<MutatingWebhookConfigurationViewModel>("mutatingwebhookconfigurations"),
            GetTable<NamespaceViewModel>("namespaces"),
            GetTable<NetworkPolicyViewModel>("networkpolicies"),
            GetTable<NodeViewModel>("nodes"),
            GetTable<PersistentVolumeClaimViewModel>("persistentvolumeclaims"),
            GetTable<PersistentVolumeViewModel>("persistentvolumes"),
            GetTable<PodDisruptionBudgetViewModel>("poddisruptionbudgets"),
            GetTable<PodTemplateViewModel>("podtemplates"),
            GetTable<PodViewModel>("pods"),
            GetTable<PriorityClassViewModel>("priorityclasses"),
            GetTable<PriorityLevelConfigurationViewModel>("prioritylevelconfigurations"),
            GetTable<ReplicaSetViewModel>("replicasets"),
            GetTable<ReplicationControllerViewModel>("replicationcontrollers"),
            GetTable<ResourceClaimTeplateViewModel>("resourceclaimtemplates"),
            GetTable<ResourceClaimViewModel>("resourceclaims"),
            GetTable<ResourceQuotasViewModel>("resourcequotas"),
            GetTable<ResourceSliceViewModel>("resourceslices"),
            GetTable<RoleBindingViewModel>("rolebindings"),
            GetTable<RoleViewModel>("roles"),
            GetTable<RuntimeClassViewModel>("runtimeclasses"),
            GetTable<SecretViewModel>("secrets"),
            GetTable<ServiceAccountViewModel>("serviceaccounts"),
            GetTable<ServiceCidrsViewModel>("servicecidrs"),
            GetTable<ServiceViewModel>("services"),
            GetTable<StatefuleSetViewModel>("statefulsets"),
            GetTable<StorageClassViewModel>("storageclasses"),
            GetTable<StorageVersionMigrationViewModel>("storageversionmigrations"),
            GetTable<StorageVersionViewModel>("storageversions"),
            GetTable<ValidatingAdmissionPolicyViewModel>("validatingadmissionpolicies"),
            GetTable<ValidatingAdmissionPolicyBindingViewModel>("validatingadmissionpolicybindings"),
            GetTable<ValidatingWebhookConfigurationViewModel>("validatingwebhookconfigurations"),
            GetTable<VolumeAttachmentViewModel>("volumeattachments"),
            GetTable<VolumeAttributeViewModel>("volumeattributes")
        ];
    }

    private static TableSymbol GetTable<T>(string tableName)
    {
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var schema = string.Join(", ", properties.Select(p => $"{p.Name}: {p.PropertyType.Name}"));
        return new TableSymbol(tableName, $"({schema})");
    }

}