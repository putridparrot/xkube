using Spectre.Console.Cli;
using XKube.Commands;

namespace XKube.CommandRegister;
internal static class RegistrationExtensions
{
    public static void RegisterGetCommands(this IConfigurator config)
    {
        config.AddBranch("get", list =>
        {
            list.AddCommand<GetApiResourceCommands>("apiresources");
            list.AddCommand<GetApiServiceCommands>("apiservices");
            list.AddCommand<GetCertificateSigningRequestCommands>("certificatesigningrequests");
            list.AddCommand<GetClusterRoleBindingCommands>("clusterrolebindings");
            list.AddCommand<GetClusterRoleCommands>("clusterroles");
            list.AddCommand<GetClusterTrustBundleCommands>("clustertrustbundles");
            list.AddCommand<GetComponentStatusCommands>("componentstatuses");
            list.AddCommand<GetConfigMapCommands>("configmaps");
            list.AddCommand<GetControllerRevisionCommands>("controllerrevisions");
            list.AddCommand<GetCronJobCommands>("cronjobs");
            list.AddCommand<GetCsiDriverCommands>("csidrivers");
            list.AddCommand<GetCsiNodeCommands>("csinodes");
            list.AddCommand<GetCsiStorageCapacityCommands>("csistoragecapacity");
            list.AddCommand<GetCustomResourceDefinitionCommands>("customresourcedefinitions");
            list.AddCommand<GetDaemonSetCommands>("daemonsets");
            list.AddCommand<GetDeploymentCommands>("deployments");
            list.AddCommand<GetDeviceClassCommands>("deviceclasses");
            list.AddCommand<GetEndpointSliceCommands>("endpointslices");
            list.AddCommand<GetEndpointCommands>("endpoints");
            list.AddCommand<GetEventCommands>("events");
            list.AddCommand<GetFlowSchemaCommands>("flowschemas");
            list.AddCommand<GetHorizontalPodAutoscalerCommands>("horizontalpodautoscalers");
            list.AddCommand<GetIngressClassCommands>("ingressclasses");
            list.AddCommand<GetIngressCommands>("ingresses");
            list.AddCommand<GetIpAddressCommands>("ipaddresses");
            list.AddCommand<GetJobCommands>("jobs");
            list.AddCommand<GetLeaseCandidateCommands>("leasecandidates");
            list.AddCommand<GetLeaseCommands>("leases");
            list.AddCommand<GetLimitRangeCommands>("limitranges");
            list.AddCommand<GetMutatingAdmissionPolicyCommands>("mutatingadmissionpolicies");
            list.AddCommand<GetMutatingAdmissionPolicyBindingCommands>("mutatingadmissionpolicybindings");
            list.AddCommand<GetMutatingWebhookConfigurationCommands>("mutatingwebhookconfigurations");
            list.AddCommand<GetNamespaceCommands>("namespaces");
            list.AddCommand<GetNetworkPolicyCommands>("networkpolicies");
            list.AddCommand<GetNodeCommands>("nodes");
            list.AddCommand<GetPersistentVolumeClaimCommands>("persistentvolumeclaims");
            list.AddCommand<GetPersistentVolumeCommands>("persistentvolumes");
            list.AddCommand<GetPodDisruptionBudgetCommands>("poddisruptionbudgets");
            list.AddCommand<GetPodTemplateCommands>("podtemplates");
            list.AddCommand<GetPodCommands>("pods");
            list.AddCommand<GetPriorityClassCommands>("priorityclasses");
            list.AddCommand<GetPriorityLevelConfigurationCommands>("prioritylevelconfigurations");
            list.AddCommand<GetReplicaSetCommands>("replicasets");
            list.AddCommand<GetReplicationControllerCommands>("replicationcontrollers");
            list.AddCommand<GetResourceClaimTeplateCommands>("resourceclaimtemplates");
            list.AddCommand<GetResourceClaimCommands>("resourceclaims");
            list.AddCommand<GetResourceQuotasCommands>("resourcequotas");
            list.AddCommand<GetResourceSliceCommands>("resourceslices");
            list.AddCommand<GetRoleBindingCommands>("rolebindings");
            list.AddCommand<GetRoleCommands>("roles");
            list.AddCommand<GetRuntimeClassCommands>("runtimeclasses");
            list.AddCommand<GetSecretCommands>("secrets");
            list.AddCommand<GetServiceAccountCommands>("serviceaccounts");
            list.AddCommand<GetServiceCidrsCommands>("servicecidrs");
            list.AddCommand<GetServiceCommands>("services");
            list.AddCommand<GetStatefuleSetCommands>("statefulsets");
            list.AddCommand<GetStorageClassCommands>("storageclasses");
            list.AddCommand<GetStorageVersionMigrationCommands>("storageversionmigrations");
            list.AddCommand<GetStorageVersionCommands>("storageversions");
            list.AddCommand<GetValidatingAdmissionPolicyCommands>("validatingadmissionpolicies");
            list.AddCommand<GetValidatingAdmissionPolicyBindingCommands>("validatingadmissionpolicybindings");
            list.AddCommand<GetValidatingWebhookConfigurationCommands>("validatingwebhookconfigurations");
            list.AddCommand<GetVolumeAttachmentCommands>("volumeattachments");
            list.AddCommand<GetVolumeAttributeCommands>("volumeattributes");
        });
    }

    public static void RegisterLogCommands(this IConfigurator config)
    {
        config.AddCommand<LogCommands>("log");
    }
}
