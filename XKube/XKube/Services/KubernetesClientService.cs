using k8s.KubeConfigModels;
using k8s;
using k8s.Autorest;
using PutridParrot.Results;
using k8s.Models;
using XKube.Extensions;

namespace XKube.Services;

internal class KubernetesClientService : IKubernetesClientService
{
    private KubernetesClientConfiguration? _kubernetesClientConfiguration;
    private IKubernetes? _kubernetes;
    private K8SConfiguration? _k8SConfiguration;

    public void LoadKubeConfig(string? configLocation = null)
    {
        _k8SConfiguration = KubernetesClientConfiguration.LoadKubeConfig(configLocation);
    }

    public void LoadConfig(string? configLocation, string? context)
    {
        _kubernetesClientConfiguration =
            KubernetesClientConfiguration.BuildConfigFromConfigFile(configLocation, currentContext: context);
        _kubernetesClientConfiguration.Namespace = "default";
        _kubernetes = new Kubernetes(_kubernetesClientConfiguration);
    }

    public void LoadConfig(string? configLocation, string? context, string? ns)
    {
        _kubernetesClientConfiguration =
            KubernetesClientConfiguration.BuildConfigFromConfigFile(configLocation, currentContext: context);
        _kubernetesClientConfiguration.Namespace = ns;
        _kubernetes = new Kubernetes(_kubernetesClientConfiguration);
    }

    public string CurrentContext => _kubernetesClientConfiguration?.CurrentContext ?? string.Empty;

    public string CurrentNamespace 
    { 
        get => _kubernetesClientConfiguration?.Namespace ?? string.Empty;
        set 
        {
            if (_kubernetesClientConfiguration.Namespace != value)
            {
                _kubernetesClientConfiguration.Namespace = value;
                _kubernetes = new Kubernetes(_kubernetesClientConfiguration);
            }
        }
    }

    public K8SConfiguration? ClustersConfiguration => _k8SConfiguration;

    public Task<List<Cluster>> GetClustersAsync()
    {
        return Task.FromResult(_k8SConfiguration?.Clusters.ToList() ?? []);
    }

    public async Task<IResult<V1ClusterList>> GetV1ClustersAsync()
    {
        // TODO: Current needs setting also namespace
        var contexts = ClustersConfiguration.Contexts;
        var currentContext = CurrentContext;
        var namespaces = await GetNamespacesAsync();

        var clusterList = new V1ClusterList
        {
            Items = _k8SConfiguration.Clusters.Select(c => new V1Cluster
            {
                Current = c.Name == currentContext,
                Name = c.Name,
                AuthInfo = c.ClusterEndpoint.CertificateAuthority,
                Cluster = c.ClusterEndpoint.Server,
                Namespace = contexts.FirstOrDefault(ctx => ctx.Name == c.Name)?.ContextDetails.Namespace
            }).ToList()
        };

        return Result.Success(clusterList);
    }

    public async Task<IResult<V1PodList>> GetPodsAsync(string? nameSpace = null, bool? watch = null)
    {
        return await GetOrDefault(_kubernetes,
            k => nameSpace.HasValue() ? k.CoreV1.ListNamespacedPodAsync(nameSpace/*, watch: watch*/) : k.CoreV1.ListPodForAllNamespacesAsync(/*watch: watch*/),
            () => new V1PodList([]));
    }

    public async Task WatchPodsAsync(V1PodList list, CancellationToken cancellationToken, string? nameSpace = null)
    {
        do
        {
            try
            {
                var lastResourceVersion = list.ResourceVersion();
                var podList = _kubernetes.CoreV1.ListNamespacedPodWithHttpMessagesAsync(nameSpace, resourceVersion: lastResourceVersion, watch: true, cancellationToken: cancellationToken);

                await foreach (var (type, item) in podList.WatchAsync<V1Pod, V1PodList>(cancellationToken: cancellationToken))
                {
                    // use values
                }
            }
            catch (HttpOperationException ex) when (ex.Response.StatusCode == System.Net.HttpStatusCode.Gone)
            {
                //Log.Warning(ex, $"Resource version being watched has been garbage collected by Kubernetes. Establishing the connection again.");
            }
            catch (Exception ex)
            {
                //Log.Warning(ex, $"Exception occured while watching pods. Establishing the connection again.");
            }
        }
        while (!cancellationToken.IsCancellationRequested);
    }

    public async Task<IResult<V1ConfigMapList>> GetConfigMapsAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.CoreV1.ListNamespacedConfigMapAsync(nameSpace) : k.CoreV1.ListConfigMapForAllNamespacesAsync(),
            () => new V1ConfigMapList([]));
    }

    public async Task<IResult<V1DaemonSetList>> GetDaemonSetsAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.AppsV1.ListNamespacedDaemonSetAsync(nameSpace) : k.AppsV1.ListDaemonSetForAllNamespacesAsync(),
            () => new V1DaemonSetList([]));
    }

    public async Task<IResult<V1DeploymentList>> GetDeploymentsAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.AppsV1.ListNamespacedDeploymentAsync(nameSpace) : k.AppsV1.ListDeploymentForAllNamespacesAsync(),
            () => new V1DeploymentList([]));
    }

    public async Task<IResult<V1EndpointsList>> GetEndpointsAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.CoreV1.ListNamespacedEndpointsAsync(nameSpace) : k.CoreV1.ListEndpointsForAllNamespacesAsync(),
            () => new V1EndpointsList([]));
    }

    public async Task<string[]> GetNamespaceNamesAsync()
    {
        var namespaces = await GetNamespacesAsync();
        if (namespaces.IsSuccess())
        {
            var ns = namespaces.Value.Items.Select(s => s.Metadata.Name).ToArray();
            return [string.Empty, .. ns];
        }
        return [];
    }
    public async Task<IResult<V1NamespaceList>> GetNamespacesAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.CoreV1.ListNamespaceAsync(), () => new V1NamespaceList([]));
    }

    public async Task<IResult<V1NodeList>> GetNodesAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.CoreV1.ListNodeAsync(), () => new V1NodeList([]));
    }

    public async Task<IResult<V1ReplicationControllerList>> GetReplicationControllersAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.CoreV1.ListNamespacedReplicationControllerAsync(nameSpace) : k.CoreV1.ListReplicationControllerForAllNamespacesAsync(),
            () => new V1ReplicationControllerList([]));
    }

    public async Task<IResult<V1ReplicaSetList>> GetReplicaSetsAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.AppsV1.ListNamespacedReplicaSetAsync(nameSpace) : k.AppsV1.ListReplicaSetForAllNamespacesAsync(),
            () => new V1ReplicaSetList([]));
    }

    public async Task<IResult<V1ServiceList>> GetServicesAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.CoreV1.ListNamespacedServiceAsync(nameSpace) : k.CoreV1.ListServiceForAllNamespacesAsync(),
            () => new V1ServiceList([]));
    }

    public async Task<IResult<V1StatefulSetList>> GetStatefulSetsAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.AppsV1.ListNamespacedStatefulSetAsync(nameSpace) : k.AppsV1.ListStatefulSetForAllNamespacesAsync(),
            () => new V1StatefulSetList([]));
    }

    public async Task<IResult<V1CronJobList>> GetCronJobsAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.BatchV1.ListNamespacedCronJobAsync(nameSpace) : k.BatchV1.ListCronJobForAllNamespacesAsync(),
            () => new V1CronJobList([]));
    }

    public async Task<IResult<V1JobList>> GetJobsAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.BatchV1.ListNamespacedJobAsync(nameSpace) : k.BatchV1.ListJobForAllNamespacesAsync(),
            () => new V1JobList([]));
    }

    public async Task<IResult<V1EndpointSliceList>> GetEndpointSlicesAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.DiscoveryV1.ListNamespacedEndpointSliceAsync(nameSpace) : k.DiscoveryV1.ListEndpointSliceForAllNamespacesAsync(),
            () => new V1EndpointSliceList([]));
    }

    public async Task<IResult<V1SecretList>> GetSecretsAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.CoreV1.ListNamespacedSecretAsync(nameSpace) : k.CoreV1.ListSecretForAllNamespacesAsync(),
            () => new V1SecretList([]));
    }

    public async Task<IResult<V1PersistentVolumeList>> GetPersistentVolumesAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.CoreV1.ListPersistentVolumeAsync(),
            () => new V1PersistentVolumeList([]));
    }

    public async Task<IResult<V1IngressList>> GetIngressesAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.NetworkingV1.ListNamespacedIngressAsync(nameSpace) : k.NetworkingV1.ListIngressForAllNamespacesAsync(),
            () => new V1IngressList([]));
    }

    public async Task<IResult<V1IngressClassList>> GetIngressClassesAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.NetworkingV1.ListIngressClassAsync(),
            () => new V1IngressClassList([]));
    }

    public async Task<IResult<V1PersistentVolumeClaimList>> GetPersistentVolumeClaimsAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.CoreV1.ListNamespacedPersistentVolumeClaimAsync(nameSpace) : k.CoreV1.ListPersistentVolumeClaimForAllNamespacesAsync(),
            () => new V1PersistentVolumeClaimList([]));
    }

    public async Task<IResult<V1StorageClassList>> GetStorageClassesAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.StorageV1.ListStorageClassAsync(),
            () => new V1StorageClassList([]));
    }

    public async Task<IResult<V1VolumeAttachmentList>> GetVolumeAttachmentsAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.StorageV1.ListVolumeAttachmentAsync(),
            () => new V1VolumeAttachmentList([]));
    }

    public async Task<IResult<V1beta1VolumeAttributesClassList>> GetVolumeAttributesClassesAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.StorageV1beta1.ListVolumeAttributesClassAsync(),
            () => new V1beta1VolumeAttributesClassList([]));
    }

    public async Task<IResult<V1APIServiceList>> GetApiServicesAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.ApiregistrationV1.ListAPIServiceAsync(),
            () => new V1APIServiceList([]));
    }

    public async Task<IResult<V1CertificateSigningRequestList>> GetCertificateSigningRequestsAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.CertificatesV1.ListCertificateSigningRequestAsync(),
            () => new V1CertificateSigningRequestList([]));
    }

    public async Task<IResult<V1ClusterRoleList>> GetClusterRolesAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.RbacAuthorizationV1.ListClusterRoleAsync(),
            () => new V1ClusterRoleList([]));
    }

    public async Task<IResult<V1ClusterRoleBindingList>> GetClusterRoleBindingsAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.RbacAuthorizationV1.ListClusterRoleBindingAsync(),
            () => new V1ClusterRoleBindingList([]));
    }

    public async Task<IResult<V1ComponentStatusList>> GetComponentStatusesAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.CoreV1.ListComponentStatusAsync(),
            () => new V1ComponentStatusList([]));
    }

    public async Task<IResult<V1FlowSchemaList>> GetFlowSchemasAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.FlowcontrolApiserverV1.ListFlowSchemaAsync(),
            () => new V1FlowSchemaList([]));
    }

    public async Task<IResult<V1beta1IPAddressList>> GetIPAddressesAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.NetworkingV1beta1.ListIPAddressAsync(), () => new V1beta1IPAddressList([]));
    }

    public async Task<IResult<V1LeaseList>> GetLeasesAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.CoordinationV1.ListNamespacedLeaseAsync(nameSpace) : k.CoordinationV1.ListLeaseForAllNamespacesAsync(),
            () => new V1LeaseList([]));
    }

    public async Task<IResult<V1alpha2LeaseCandidateList>> GetLeaseCandidatesAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.CoordinationV1alpha2.ListNamespacedLeaseCandidateAsync(nameSpace) : k.CoordinationV1alpha2.ListLeaseCandidateForAllNamespacesAsync(),
            () => new V1alpha2LeaseCandidateList([]));
    }

    public async Task<IResult<V1PriorityLevelConfigurationList>> GetPriorityLevelConfigurationsAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.FlowcontrolApiserverV1.ListPriorityLevelConfigurationAsync(),
            () => new V1PriorityLevelConfigurationList([]));
    }

    public async Task<IResult<V1ResourceQuotaList>> GetResourceQuotasAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.CoreV1.ListNamespacedResourceQuotaAsync(nameSpace) : k.CoreV1.ListResourceQuotaForAllNamespacesAsync(),
            () => new V1ResourceQuotaList([]));
    }

    public async Task<IResult<V1RoleList>> GetRolesAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.RbacAuthorizationV1.ListNamespacedRoleAsync(nameSpace) : k.RbacAuthorizationV1.ListRoleForAllNamespacesAsync(),
            () => new V1RoleList([]));
    }

    public async Task<IResult<V1RoleBindingList>> GetRoleBindingsAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.RbacAuthorizationV1.ListNamespacedRoleBindingAsync(nameSpace) : k.RbacAuthorizationV1.ListRoleBindingForAllNamespacesAsync(),
            () => new V1RoleBindingList([]));
    }

    public async Task<IResult<V1RuntimeClassList>> GetRuntimeClassesAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.NodeV1.ListRuntimeClassAsync(), () => new V1RuntimeClassList([]));
    }

    public async Task<IResult<V1ServiceAccountList>> GetServiceAccountsAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.CoreV1.ListNamespacedServiceAccountAsync(nameSpace) : k.CoreV1.ListServiceAccountForAllNamespacesAsync(),
            () => new V1ServiceAccountList([]));
    }

    private static async Task<IResult<T>> GetOrDefault<T>(IKubernetes? k, Func<IKubernetes, Task<T>> getter, Func<T> defaultResult)
    {
        if (k == null)
        {
            return Result.Failure(defaultResult(), "Kubernetes client is not initialized.");
        }

        try
        {
            return Result.Success(await getter(k));
        }
        catch (HttpOperationException e)
        {
            return Result.Failure(defaultResult(), $"Error - {e.Response.ReasonPhrase}");
        }
        catch (Exception e)
        {
            return Result.Failure(defaultResult(), e.Message);
        }
    }

    public async Task<IResult<V1beta1ServiceCIDRList>> GetServiceCIDRSAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.NetworkingV1beta1.ListServiceCIDRAsync(),
            () => new V1beta1ServiceCIDRList([]));
    }

    public async Task<IResult<V1alpha1StorageVersionList>> GetStorageVersionsAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.InternalApiserverV1alpha1.ListStorageVersionAsync(),
            () => new V1alpha1StorageVersionList([]));
    }

    public async Task<IResult<V1alpha1StorageVersionMigrationList>> GetStorageVersionMigrationsAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.StoragemigrationV1alpha1.ListStorageVersionMigrationAsync(),
            () => new V1alpha1StorageVersionMigrationList([]));
    }

    public async Task<IResult<V1alpha1ClusterTrustBundleList>> GetClusterTrustBundlesAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.CertificatesV1alpha1.ListClusterTrustBundleAsync(),
            () => new V1alpha1ClusterTrustBundleList([]));
    }

    public async Task<IResult<V1ControllerRevisionList>> GetControllerRevisionsAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.AppsV1.ListNamespacedControllerRevisionAsync(nameSpace) : k.AppsV1.ListControllerRevisionForAllNamespacesAsync(),
            () => new V1ControllerRevisionList([]));
    }

    public async Task<IResult<V1CustomResourceDefinitionList>> GetCustomResourceDefinitionsAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.ApiextensionsV1.ListCustomResourceDefinitionAsync(),
            () => new V1CustomResourceDefinitionList([]));
    }

    public async Task<IResult<V1beta1DeviceClassList>> GetDeviceClassesAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.ResourceV1beta1.ListDeviceClassAsync(),
            () => new V1beta1DeviceClassList([]));
    }

    public async Task<IResult<V1LimitRangeList>> GetLimitRangesAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.CoreV1.ListNamespacedLimitRangeAsync(nameSpace) : k.CoreV1.ListLimitRangeForAllNamespacesAsync(),
            () => new V1LimitRangeList([]));
    }

    public async Task<IResult<V2HorizontalPodAutoscalerList>> GetHorizontalPodAutoscalersAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.AutoscalingV2.ListNamespacedHorizontalPodAutoscalerAsync(nameSpace) : k.AutoscalingV2.ListHorizontalPodAutoscalerForAllNamespacesAsync(),
            () => new V2HorizontalPodAutoscalerList([]));
    }

    public async Task<IResult<V1MutatingWebhookConfigurationList>> GetMutatingWebhookConfigurationsAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.AdmissionregistrationV1.ListMutatingWebhookConfigurationAsync(),
            () => new V1MutatingWebhookConfigurationList([]));
    }

    public async Task<IResult<V1PodTemplateList>> GetPodTemplatesAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.CoreV1.ListNamespacedPodTemplateAsync(nameSpace) : k.CoreV1.ListPodTemplateForAllNamespacesAsync(),
            () => new V1PodTemplateList([]));
    }

    public async Task<IResult<V1PodDisruptionBudgetList>> GetPodDisruptionBudgetsAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.PolicyV1.ListNamespacedPodDisruptionBudgetAsync(nameSpace) : k.PolicyV1.ListPodDisruptionBudgetForAllNamespacesAsync(),
            () => new V1PodDisruptionBudgetList([]));
    }

    public async Task<IResult<V1PriorityClassList>> GetPriorityClassesAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.SchedulingV1.ListPriorityClassAsync(),
            () => new V1PriorityClassList([]));
    }

    public async Task<IResult<V1beta1ResourceClaimList>> GetResourceClaimsAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.ResourceV1beta1.ListNamespacedResourceClaimAsync(nameSpace) : k.ResourceV1beta1.ListResourceClaimForAllNamespacesAsync(),
            () => new V1beta1ResourceClaimList([]));
    }

    public async Task<IResult<V1beta1ResourceClaimTemplateList>> GetResourceClaimTemplatesAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.ResourceV1beta1.ListNamespacedResourceClaimTemplateAsync(nameSpace) : k.ResourceV1beta1.ListResourceClaimTemplateForAllNamespacesAsync(),
            () => new V1beta1ResourceClaimTemplateList([]));
    }

    public async Task<IResult<V1beta1ResourceSliceList>> GetResourceSlicesAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.ResourceV1beta1.ListResourceSliceAsync(),
            () => new V1beta1ResourceSliceList([]));
    }

    public async Task<IResult<V1ValidatingAdmissionPolicyList>> GetValidatingAdmissionPoliciesAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.AdmissionregistrationV1.ListValidatingAdmissionPolicyAsync(),
            () => new V1ValidatingAdmissionPolicyList([]));
    }

    public async Task<IResult<V1ValidatingAdmissionPolicyBindingList>> GetValidatingAdmissionPolicyBindingsAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.AdmissionregistrationV1.ListValidatingAdmissionPolicyBindingAsync(),
            () => new V1ValidatingAdmissionPolicyBindingList([]));
    }

    public async Task<IResult<V1ValidatingWebhookConfigurationList>> GetValidatingWebhookConfigurationsAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.AdmissionregistrationV1.ListValidatingWebhookConfigurationAsync(),
            () => new V1ValidatingWebhookConfigurationList([]));
    }

    public async Task<IResult<V1NetworkPolicyList>> GetNetworkPoliciesAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.NetworkingV1.ListNamespacedNetworkPolicyAsync(nameSpace) : k.NetworkingV1.ListNetworkPolicyForAllNamespacesAsync(),
            () => new V1NetworkPolicyList([]));
    }

    public async Task<IResult<V1alpha1MutatingAdmissionPolicyList>> GetMutatingAdmissionPoliciesAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.AdmissionregistrationV1alpha1.ListMutatingAdmissionPolicyAsync(),
            () => new V1alpha1MutatingAdmissionPolicyList([]));
    }

    public async Task<IResult<V1alpha1MutatingAdmissionPolicyBindingList>> GetMutatingAdmissionPolicyBindingsAsync()
    {
        return await GetOrDefault(
            _kubernetes, k => k.AdmissionregistrationV1alpha1.ListMutatingAdmissionPolicyBindingAsync(),
            () => new V1alpha1MutatingAdmissionPolicyBindingList([]));
    }

    public async Task<string> GetPodLogsAsync(string nameSpace, string podName)
    {
        var stream = await _kubernetes.CoreV1.ReadNamespacedPodLogAsync(
            name: podName, nameSpace,
            //container:
            follow: false,
            tailLines: 100);
        using var reader = new StreamReader(stream);
        return await reader.ReadToEndAsync();
    }

    public async Task<IResult<PodMetricsList>> GetPodMetricsAsync()
    {
        // kubectl get apiservices (v1beta1.metrics.k8s.io. If it's missing, you'll need to install the Metrics Server)
        return Result.Success(await _kubernetes.GetKubernetesPodsMetricsAsync());
    }

    public async Task<IResult<NodeMetricsList>> GetNodeMetricsAsync()
    {
        // kubectl get apiservices (v1beta1.metrics.k8s.io. If it's missing, you'll need to install the Metrics Server)
        return Result.Success(await _kubernetes.GetKubernetesNodesMetricsAsync());
    }

    public async Task<IResult<V1APIResourceList>> GetApiResourcesAsync()
    {
        return await GetOrDefault(_kubernetes,
            k => k.CoreV1.GetAPIResourcesAsync(),
            () => new V1APIResourceList(string.Empty, []));
    }

    public async Task<IResult<V1APIGroupList>> GetAPIVersionsAsync()
    {
        return await GetOrDefault(_kubernetes,
            k => k.Apis.GetAPIVersionsAsync(),
            () => new V1APIGroupList());
    }

    public async Task<IResult<Corev1EventList>> GetEventsAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.CoreV1.ListNamespacedEventAsync(nameSpace) : k.CoreV1.ListEventForAllNamespacesAsync(),
            () => new Corev1EventList());
    }

    public async Task<IResult<V1CSIDriverList>> GetCsiDriversAsync()
    {
        return await GetOrDefault(_kubernetes,
            k => k.StorageV1.ListCSIDriverAsync(),
            () => new V1CSIDriverList());
    }
    public async Task<IResult<V1CSINodeList>> GetCsiNodesAsync()
    {
        return await GetOrDefault(
            _kubernetes, k => k.StorageV1.ListCSINodeAsync(),
            () => new V1CSINodeList());
    }

    public async Task<IResult<V1CSIStorageCapacityList>> GetCsiStorageCapacitiesAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.StorageV1.ListNamespacedCSIStorageCapacityAsync(nameSpace) : k.StorageV1.ListCSIStorageCapacityForAllNamespacesAsync(),
            () => new V1CSIStorageCapacityList());
    }

    public async Task<IResult<V1Pod>> DescribePodAsync(string podName, string nameSpace)
    {
        return await GetOrDefault(
            _kubernetes, k => k.CoreV1.ReadNamespacedPodAsync(podName, nameSpace),
            () => new V1Pod());
    }

    public async Task<IResult<V1Node>> DescribeNodeAsync(string nodeName)
    {
        return await GetOrDefault(
            _kubernetes, k => k.CoreV1.ReadNodeAsync(nodeName),
            () => new V1Node());
    }

    // kubectl get deployment my-app -o yaml
    public async Task<IResult<V1Deployment>> DescribeDeploymentAsync(string deploymentName, string namespaceName = "default")
    {
        return await GetOrDefault(
            _kubernetes, k => k.AppsV1.ReadNamespacedDeploymentAsync(deploymentName, namespaceName),
            () => new V1Deployment());
    }

    public async Task<IResult<V1Ingress>> DescribeIngressAsync(string ingressName, string namespaceName = "default")
    {
        return await GetOrDefault(_kubernetes, k => k.NetworkingV1.ReadNamespacedIngressAsync(ingressName, namespaceName),
            () => new V1Ingress());
    }
}
