using System.Collections.Immutable;
using KustoLoco.Core;
using XKube.Services;
using XKube.ViewModelExtensions;

namespace XKube.Commands;

public static class KustoQueryContextExtensions
{
    public static async Task RegisterTables(this KustoQueryContext ctx, HashSet<string> tables, IKubernetesClientService kubernetesClientServices, string? ns)
    {
        await ctx.RegisterTable(tables, "apiresources",
           async () => (await kubernetesClientServices.GetApiResourcesAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "apiservices",
           async () => (await kubernetesClientServices.GetApiServicesAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "certificatesigningrequests",
           async () => (await kubernetesClientServices.GetCertificateSigningRequestsAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "clusterrolebindings",
           async () => (await kubernetesClientServices.GetClusterRoleBindingsAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "clusterroles",
           async () => (await kubernetesClientServices.GetClusterRolesAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "clustertrustbundles",
           async () => (await kubernetesClientServices.GetClusterTrustBundlesAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "clusters",
           async () => (await kubernetesClientServices.GetV1ClustersAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "componentstatuses",
           async () => (await kubernetesClientServices.GetComponentStatusesAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "configmaps",
           async () => (await kubernetesClientServices.GetConfigMapsAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "controllerrevisions",
           async () => (await kubernetesClientServices.GetControllerRevisionsAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "cronjobs",
           async () => (await kubernetesClientServices.GetCronJobsAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "csidrivers",
           async () => (await kubernetesClientServices.GetCsiDriversAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "csinodes",
           async () => (await kubernetesClientServices.GetCsiNodesAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "csistoragecapacity",
           async () => (await kubernetesClientServices.GetCsiStorageCapacitiesAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "customresourcedefinitions",
           async () => (await kubernetesClientServices.GetCustomResourceDefinitionsAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "daemonsets",
           async () => (await kubernetesClientServices.GetDaemonSetsAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "deployments",
           async () => (await kubernetesClientServices.GetDeploymentsAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "deviceclasses",
           async () => (await kubernetesClientServices.GetDeviceClassesAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "endpointslices",
           async () => (await kubernetesClientServices.GetEndpointSlicesAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "endpoints",
           async () => (await kubernetesClientServices.GetEndpointsAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "events",
           async () => (await kubernetesClientServices.GetEventsAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "flowschemas",
           async () => (await kubernetesClientServices.GetFlowSchemasAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "horizontalpodautoscalers",
           async () => (await kubernetesClientServices.GetHorizontalPodAutoscalersAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "ingressclasses",
           async () => (await kubernetesClientServices.GetIngressClassesAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "ingresses",
           async () => (await kubernetesClientServices.GetIngressesAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "ipaddresses",
           async () => (await kubernetesClientServices.GetIPAddressesAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "jobs",
           async () => (await kubernetesClientServices.GetJobsAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "leasecandidates",
           async () => (await kubernetesClientServices.GetLeaseCandidatesAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "leases",
           async () => (await kubernetesClientServices.GetLeasesAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "limitranges",
           async () => (await kubernetesClientServices.GetLimitRangesAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "mutatingadmissionpolicies",
           async () => (await kubernetesClientServices.GetMutatingAdmissionPoliciesAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "mutatingadmissionpolicybindings",
           async () => (await kubernetesClientServices.GetMutatingAdmissionPolicyBindingsAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "mutatingwebhookconfigurations",
           async () => (await kubernetesClientServices.GetMutatingWebhookConfigurationsAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "namespaces",
           async () => (await kubernetesClientServices.GetNamespacesAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "networkpolicies",
           async () => (await kubernetesClientServices.GetNetworkPoliciesAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "nodes",
           async () => (await kubernetesClientServices.GetNodesAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "persistentvolumeclaims",
           async () => (await kubernetesClientServices.GetPersistentVolumeClaimsAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "persistentvolumes",
           async () => (await kubernetesClientServices.GetPersistentVolumesAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "poddisruptionbudgets",
           async () => (await kubernetesClientServices.GetPodDisruptionBudgetsAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "podtemplates",
           async () => (await kubernetesClientServices.GetPodTemplatesAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "pods",
           async () => (await kubernetesClientServices.GetPodsAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "priorityclasses",
           async () => (await kubernetesClientServices.GetPriorityClassesAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "prioritylevelconfigurations",
           async () => (await kubernetesClientServices.GetPriorityLevelConfigurationsAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "replicasets",
           async () => (await kubernetesClientServices.GetReplicaSetsAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "replicationcontrollers",
           async () => (await kubernetesClientServices.GetReplicationControllersAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "resourceclaimtemplates",
           async () => (await kubernetesClientServices.GetResourceClaimTemplatesAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "resourceclaims",
           async () => (await kubernetesClientServices.GetResourceClaimsAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "resourcequotas",
           async () => (await kubernetesClientServices.GetResourceQuotasAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "resourceslices",
           async () => (await kubernetesClientServices.GetResourceSlicesAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "rolebindings",
           async () => (await kubernetesClientServices.GetRoleBindingsAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "roles",
           async () => (await kubernetesClientServices.GetRolesAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "runtimeclasses",
           async () => (await kubernetesClientServices.GetRuntimeClassesAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "secrets",
           async () => (await kubernetesClientServices.GetSecretsAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "serviceaccounts",
           async () => (await kubernetesClientServices.GetServiceAccountsAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "servicecidrs",
           async () => (await kubernetesClientServices.GetServiceCIDRSAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "services",
           async () => (await kubernetesClientServices.GetServicesAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "statefulsets",
           async () => (await kubernetesClientServices.GetStatefulSetsAsync(ns)).Value.ToViewModel());
        await ctx.RegisterTable(tables, "storageclasses",
           async () => (await kubernetesClientServices.GetStorageClassesAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "storageversionmigrations",
           async () => (await kubernetesClientServices.GetStorageVersionMigrationsAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "storageversions",
           async () => (await kubernetesClientServices.GetStorageVersionsAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "validatingadmissionpolicies",
           async () => (await kubernetesClientServices.GetValidatingAdmissionPoliciesAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "validatingadmissionpolicybindings",
           async () => (await kubernetesClientServices.GetValidatingAdmissionPolicyBindingsAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "validatingwebhookconfigurations",
           async () => (await kubernetesClientServices.GetValidatingWebhookConfigurationsAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "volumeattachments",
           async () => (await kubernetesClientServices.GetVolumeAttachmentsAsync()).Value.ToViewModel());
        await ctx.RegisterTable(tables, "volumeattributes",
           async () => (await kubernetesClientServices.GetVolumeAttributesClassesAsync()).Value.ToViewModel());
    }

    private static async Task RegisterTable<T>(this KustoQueryContext ctx, HashSet<string> tables, string tableName, Func<Task<ICollection<T>>> fn)
    {
        try
        {
            ctx.WrapDataIntoTable(tableName,
                tables.Contains(tableName) ? [..await fn()] : ImmutableArray<T>.Empty);
        }
        catch
        {
            ctx.WrapDataIntoTable(tableName, ImmutableArray<T>.Empty);
        }
    }
}