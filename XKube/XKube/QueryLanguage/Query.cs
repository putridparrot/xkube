using System.Reflection;
using System.Text;
using Kusto.Language;
using Kusto.Language.Symbols;
using Kusto.Language.Syntax;
using PutridParrot.Results;
using XKube.ViewModels;

namespace XKube.QueryLanguage;

public static class Query
{
    public static IResult<string> ExecQuery(string query)
    {
        var code = KustoCode.ParseAndAnalyze(query, GetGlobalState());
        var diagnostics = code.GetDiagnostics();
        if (diagnostics.Count > 0)
        {
            return Result.Failure(string.Empty, string.Join(", ", diagnostics.Select(d => d.Description)));
        }

        //var dbColumns = GetDatabaseTableColumns(code);
        var columns = GetDatabaseTables(code);

        //var table = code.Globals.GetTable(column);
        //var database = code.Globals.GetDatabase(table);
        //var cluster = code.Globals.GetCluster(database);

        return Result.Success(code.Text);
    }

    private static HashSet<TableSymbol> GetDatabaseTables(KustoCode code)
    {
        var tables = new HashSet<TableSymbol>();
        GatherTables(code.Syntax);
        return tables;

        void GatherTables(SyntaxNode root)
        {
            SyntaxElement.WalkNodes(root,
                fnBefore: n =>
                {
                    Console.WriteLine($"{n.GetType().Name.ToString()} -> {n.Kind.ToString()} -> {n.ToString()}");
                    if (n.ReferencedSymbol is TableSymbol t
                        && code.Globals.IsDatabaseTable(t))
                    {
                        tables.Add(t);
                    }
                    else if (n is Expression e
                             && e.ResultType is TableSymbol ts
                             && code.Globals.IsDatabaseTable(ts))
                    {
                        tables.Add(ts);
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

    public static HashSet<ColumnSymbol> GetDatabaseTableColumns(KustoCode code)
    {
        var columns = new HashSet<ColumnSymbol>();
        GatherColumns(code.Syntax);
        return columns;

        void GatherColumns(SyntaxNode root)
        {
            SyntaxElement.WalkNodes(root,
                fnBefore: n =>
                {
                    if (n.ReferencedSymbol is ColumnSymbol c)
                    {
                        AddDatabaseTableColumns(c, code.Globals, columns);
                    }
                    else if (n.GetCalledFunctionBody() is { } body)
                    {
                        GatherColumns(body);
                    }
                },
                fnDescend: n =>
                    // skip descending into function declarations since their bodies will be examined by the code above
                    !(n is FunctionDeclaration)
            );
        }
    }

    private static bool IsDatabaseTableColumn(ColumnSymbol column, GlobalState globals)
    {
        return globals.GetTable(column) != null;
    }

    private static void AddDatabaseTableColumns(ColumnSymbol column, GlobalState globals, HashSet<ColumnSymbol> columns)
    {
        if (IsDatabaseTableColumn(column, globals))
        {
            columns.Add(column);
        }
        else if (column.OriginalColumns.Count > 0)
        {
            foreach (var originalColumn in column.OriginalColumns)
            {
                AddDatabaseTableColumns(originalColumn, globals, columns);
            }
        }
    }

    private static GlobalState? GetGlobalState()
    {
        return GlobalState.Default.WithDatabase(
            new DatabaseSymbol("db",
                GetTables().Concat<Symbol>(
                    GetFunctions()).ToArray())
        );
    }

    private static FunctionSymbol[] GetFunctions()
    {
        return
        [
            new FunctionSymbol("RunningPods", "{ pods | where Status == \"Running\"; }"),
            new FunctionSymbol("FailingPods", "{ pods | where Status != \"Running\"; }") // TBC
        ];
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