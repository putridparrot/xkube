using System.Collections.Immutable;
using KustoLoco.Core;
using XKube.Services;
using XKube.ViewModelExtensions;

namespace XKube.Commands;

public static class KustoQueryContextExtensions
{
    public static async Task RegisterTables(this KustoQueryContext ctx, IKubernetesClientService kubernetesClientServices, string ns)
    {
        ctx.WrapDataIntoTable("apiresources",
            (await kubernetesClientServices.GetApiResourcesAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("apiservices",
            (await kubernetesClientServices.GetApiServicesAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("certificatesigningrequests",
            (await kubernetesClientServices.GetCertificateSigningRequestsAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("clusterrolebindings",
            (await kubernetesClientServices.GetClusterRoleBindingsAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("clusterroles",
            (await kubernetesClientServices.GetClusterRolesAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("clustertrustbundles",
            (await kubernetesClientServices.GetClusterTrustBundlesAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("clusters",
            (await kubernetesClientServices.GetV1ClustersAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("componentstatuses",
            (await kubernetesClientServices.GetComponentStatusesAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("configmaps",
            (await kubernetesClientServices.GetConfigMapsAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("controllerrevisions",
            (await kubernetesClientServices.GetControllerRevisionsAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("cronjobs",
            (await kubernetesClientServices.GetCronJobsAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("csidrivers",
            (await kubernetesClientServices.GetCsiDriversAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("csinodes",
            (await kubernetesClientServices.GetCsiNodesAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("csistoragecapacity",
            (await kubernetesClientServices.GetCsiStorageCapacitiesAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("customresourcedefinitions",
            (await kubernetesClientServices.GetCustomResourceDefinitionsAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("daemonsets",
            (await kubernetesClientServices.GetDaemonSetsAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("deployments",
            (await kubernetesClientServices.GetDeploymentsAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("deviceclasses",
            (await kubernetesClientServices.GetDeviceClassesAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("endpointslices",
            (await kubernetesClientServices.GetEndpointSlicesAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("endpoints",
            (await kubernetesClientServices.GetEndpointsAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("events",
            (await kubernetesClientServices.GetEventsAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("flowschemas",
            (await kubernetesClientServices.GetFlowSchemasAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("horizontalpodautoscalers",
            (await kubernetesClientServices.GetHorizontalPodAutoscalersAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("ingressclasses",
            (await kubernetesClientServices.GetIngressClassesAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("ingresses",
            (await kubernetesClientServices.GetIngressesAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("ipaddresses",
            (await kubernetesClientServices.GetIPAddressesAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("jobs",
            (await kubernetesClientServices.GetJobsAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("leasecandidates",
            (await kubernetesClientServices.GetLeaseCandidatesAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("leases",
            (await kubernetesClientServices.GetLeasesAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("limitranges",
            (await kubernetesClientServices.GetLimitRangesAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("mutatingadmissionpolicies",
            (await kubernetesClientServices.GetMutatingAdmissionPoliciesAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("mutatingadmissionpolicybindings",
            (await kubernetesClientServices.GetMutatingAdmissionPolicyBindingsAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("mutatingwebhookconfigurations",
            (await kubernetesClientServices.GetMutatingWebhookConfigurationsAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("namespaces",
            (await kubernetesClientServices.GetNamespacesAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("networkpolicies",
            (await kubernetesClientServices.GetNetworkPoliciesAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("nodes",
            (await kubernetesClientServices.GetNodesAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("persistentvolumeclaims",
            (await kubernetesClientServices.GetPersistentVolumeClaimsAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("persistentvolumes",
            (await kubernetesClientServices.GetPersistentVolumesAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("poddisruptionbudgets",
            (await kubernetesClientServices.GetPodDisruptionBudgetsAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("podtemplates",
            (await kubernetesClientServices.GetPodTemplatesAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("pods",
            (await kubernetesClientServices.GetPodsAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("priorityclasses",
            (await kubernetesClientServices.GetPriorityClassesAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("prioritylevelconfigurations",
            (await kubernetesClientServices.GetPriorityLevelConfigurationsAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("replicasets",
            (await kubernetesClientServices.GetReplicaSetsAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("replicationcontrollers",
            (await kubernetesClientServices.GetReplicationControllersAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("resourceclaimtemplates",
            (await kubernetesClientServices.GetResourceClaimTemplatesAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("resourceclaims",
            (await kubernetesClientServices.GetResourceClaimsAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("resourcequotas",
            (await kubernetesClientServices.GetResourceQuotasAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("resourceslices",
            (await kubernetesClientServices.GetResourceSlicesAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("rolebindings",
            (await kubernetesClientServices.GetRoleBindingsAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("roles",
            (await kubernetesClientServices.GetRolesAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("runtimeclasses",
            (await kubernetesClientServices.GetRuntimeClassesAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("secrets",
            (await kubernetesClientServices.GetSecretsAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("serviceaccounts",
            (await kubernetesClientServices.GetServiceAccountsAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("servicecidrs",
            (await kubernetesClientServices.GetServiceCIDRSAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("services",
            (await kubernetesClientServices.GetServicesAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("statefulsets",
            (await kubernetesClientServices.GetStatefulSetsAsync(ns)).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("storageclasses",
            (await kubernetesClientServices.GetStorageClassesAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("storageversionmigrations",
            (await kubernetesClientServices.GetStorageVersionMigrationsAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("storageversions",
            (await kubernetesClientServices.GetStorageVersionsAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("validatingadmissionpolicies",
            (await kubernetesClientServices.GetValidatingAdmissionPoliciesAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("validatingadmissionpolicybindings",
            (await kubernetesClientServices.GetValidatingAdmissionPolicyBindingsAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("validatingwebhookconfigurations",
            (await kubernetesClientServices.GetValidatingWebhookConfigurationsAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("volumeattachments",
            (await kubernetesClientServices.GetVolumeAttachmentsAsync()).Value.ToViewModel().ToImmutableArray());
        ctx.WrapDataIntoTable("volumeattributes",
            (await kubernetesClientServices.GetVolumeAttributesClassesAsync()).Value.ToViewModel().ToImmutableArray());
    }
}