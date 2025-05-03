using k8s.KubeConfigModels;
using k8s.Models;
using PutridParrot.Results;

namespace XKube.Services;

internal interface IKubernetesClientService
{
    string CurrentContext { get; }
    string CurrentNamespace { get; }
    K8SConfiguration? ClustersConfiguration { get; }

    Task<IResult<V1PodList>> GetPodsAsync(string? nameSpace = null, bool? watch = null);
    Task<IResult<V1ServiceList>> GetServicesAsync(string? nameSpace = null);

    Task<IResult<V1NodeList>> GetNodesAsync();
}