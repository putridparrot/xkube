using k8s.KubeConfigModels;
using k8s.Models;
using PutridParrot.Results;

namespace XKube.Services;

public interface IKubernetesClientService
{
    void LoadKubeConfig(string? configLocation = null);
    void LoadConfig(string? configLocation, string? context);
    void LoadConfig(string? configLocation, string? context, string? ns);
    string CurrentContext { get; }
    K8SConfiguration? ClustersConfiguration { get; }

    string CurrentNamespace { get; set; }

    Task<string[]> GetNamespaceNamesAsync();

    Task<List<Cluster>> GetClustersAsync();
    Task<IResult<V1PodList>> GetPodsAsync(string? nameSpace = null, bool? watch = null);
    Task<IResult<V1ConfigMapList>> GetConfigMapsAsync(string? nameSpace = null);
    Task<IResult<V1DaemonSetList>> GetDaemonSetsAsync(string? nameSpace = null);
    Task<IResult<V1DeploymentList>> GetDeploymentsAsync(string? nameSpace = null);
    Task<IResult<V1EndpointsList>> GetEndpointsAsync(string? nameSpace = null);
    Task<IResult<V1NamespaceList>> GetNamespacesAsync();
    Task<IResult<V1NodeList>> GetNodesAsync();
    Task<IResult<V1ReplicationControllerList>> GetReplicationControllersAsync(string? nameSpace = null);
    Task<IResult<V1ReplicaSetList>> GetReplicaSetsAsync(string? nameSpace = null);
    Task<IResult<V1ServiceList>> GetServicesAsync(string? nameSpace = null);
    Task<IResult<V1StatefulSetList>> GetStatefulSetsAsync(string? nameSpace = null);
    Task<IResult<V1CronJobList>> GetCronJobsAsync(string? nameSpace = null);
    Task<IResult<V1JobList>> GetJobsAsync(string? nameSpace = null);
    Task<IResult<V1EndpointSliceList>> GetEndpointSlicesAsync(string? nameSpace = null);
    Task<IResult<V1SecretList>> GetSecretsAsync(string? nameSpace = null);
    Task<IResult<V1PersistentVolumeList>> GetPersistentVolumesAsync();
    Task<IResult<V1IngressList>> GetIngressesAsync(string? nameSpace = null);
    Task<IResult<V1IngressClassList>> GetIngressClassesAsync();
    Task<IResult<V1PersistentVolumeClaimList>> GetPersistentVolumeClaimsAsync(string? nameSpace = null);
    Task<IResult<V1StorageClassList>> GetStorageClassesAsync();
    Task<IResult<V1VolumeAttachmentList>> GetVolumeAttachmentsAsync();
    Task<IResult<V1beta1VolumeAttributesClassList>> GetVolumeAttributesClassesAsync();
    Task<IResult<V1APIServiceList>> GetApiServicesAsync();
    Task<IResult<V1CertificateSigningRequestList>> GetCertificateSigningRequestsAsync();
    Task<IResult<V1ClusterRoleList>> GetClusterRolesAsync();
    Task<IResult<V1ClusterRoleBindingList>> GetClusterRoleBindingsAsync();
    Task<IResult<V1ComponentStatusList>> GetComponentStatusesAsync();
    Task<IResult<V1FlowSchemaList>> GetFlowSchemasAsync();
    Task<IResult<V1beta1IPAddressList>> GetIPAddressesAsync();
    Task<IResult<V1LeaseList>> GetLeasesAsync(string? nameSpace = null);
    Task<IResult<V1alpha2LeaseCandidateList>> GetLeaseCandidatesAsync(string? nameSpace = null);
    Task<IResult<V1PriorityLevelConfigurationList>> GetPriorityLevelConfigurationsAsync();
    Task<IResult<V1ResourceQuotaList>> GetResourceQuotasAsync(string? nameSpace = null);
    Task<IResult<V1RoleList>> GetRolesAsync(string? nameSpace = null);
    Task<IResult<V1RoleBindingList>> GetRoleBindingsAsync(string? nameSpace = null);
    Task<IResult<V1RuntimeClassList>> GetRuntimeClassesAsync();
    Task<IResult<V1ServiceAccountList>> GetServiceAccountsAsync(string? nameSpace = null);
    Task<IResult<V1beta1ServiceCIDRList>> GetServiceCIDRSAsync();
    Task<IResult<V1alpha1StorageVersionList>> GetStorageVersionsAsync();
    Task<IResult<V1alpha1StorageVersionMigrationList>> GetStorageVersionMigrationsAsync();
    Task<IResult<V1alpha1ClusterTrustBundleList>> GetClusterTrustBundlesAsync();
    Task<IResult<V1ControllerRevisionList>> GetControllerRevisionsAsync(string? nameSpace = null);
    Task<IResult<V1CustomResourceDefinitionList>> GetCustomResourceDefinitionsAsync();
    Task<IResult<V1beta1DeviceClassList>> GetDeviceClassesAsync();
    Task<IResult<V1LimitRangeList>> GetLimitRangesAsync(string? nameSpace = null);
    Task<IResult<V2HorizontalPodAutoscalerList>> GetHorizontalPodAutoscalersAsync(string? nameSpace = null);
    Task<IResult<V1MutatingWebhookConfigurationList>> GetMutatingWebhookConfigurationsAsync();
    Task<IResult<V1PodTemplateList>> GetPodTemplatesAsync(string? nameSpace = null);
    Task<IResult<V1PodDisruptionBudgetList>> GetPodDisruptionBudgetsAsync(string? nameSpace = null);
    Task<IResult<V1PriorityClassList>> GetPriorityClassesAsync();
    Task<IResult<V1beta1ResourceClaimList>> GetResourceClaimsAsync(string? nameSpace = null);
    Task<IResult<V1beta1ResourceClaimTemplateList>> GetResourceClaimTemplatesAsync(string? nameSpace = null);
    Task<IResult<V1beta1ResourceSliceList>> GetResourceSlicesAsync();
    Task<IResult<V1ValidatingAdmissionPolicyList>> GetValidatingAdmissionPoliciesAsync();
    Task<IResult<V1ValidatingAdmissionPolicyBindingList>> GetValidatingAdmissionPolicyBindingsAsync();
    Task<IResult<V1ValidatingWebhookConfigurationList>> GetValidatingWebhookConfigurationsAsync();
    Task<IResult<V1NetworkPolicyList>> GetNetworkPoliciesAsync(string? nameSpace = null);
    Task<IResult<V1alpha1MutatingAdmissionPolicyList>> GetMutatingAdmissionPoliciesAsync();
    Task<IResult<V1alpha1MutatingAdmissionPolicyBindingList>> GetMutatingAdmissionPolicyBindingsAsync();

    Task<string> GetPodLogsAsync(string nameSpace, string podName);
    Task<IResult<PodMetricsList>> GetPodMetricsAsync();
    Task<IResult<NodeMetricsList>> GetNodeMetricsAsync();
    Task<IResult<V1APIResourceList>> GetApiResourcesAsync();
    Task<IResult<V1APIGroupList>> GetAPIVersionsAsync();
    Task<IResult<Corev1EventList>> GetEventsAsync(string? nameSpace = null);
    Task<IResult<V1CSIDriverList>> GetCsiDriversAsync();
    Task<IResult<V1CSINodeList>> GetCsiNodesAsync();
    Task<IResult<V1CSIStorageCapacityList>> GetCsiStorageCapacitiesAsync(string? nameSpace = null);

    Task<IResult<V1Pod>> DescribePodAsync(string podName, string nameSpace);
    Task<IResult<V1Node>> DescribeNodeAsync(string nodeName);
    Task<IResult<V1Deployment>> DescribeDeploymentAsync(string deploymentName, string namespaceName = "default");
    Task<IResult<V1Ingress>> DescribeIngressAsync(string ingressName, string namespaceName = "default");
}