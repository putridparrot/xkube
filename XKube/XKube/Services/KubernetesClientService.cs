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
        _kubernetesClientConfiguration = KubernetesClientConfiguration.BuildConfigFromConfigFile(configLocation, currentContext: context);
        //_kubernetesClientConfiguration.Namespace = CurrentNamespace;
        _kubernetes = new Kubernetes(_kubernetesClientConfiguration);
    }

    public void LoadConfig(string? configLocation, string? context, string? ns)
    {
        _kubernetesClientConfiguration = KubernetesClientConfiguration.BuildConfigFromConfigFile(configLocation, currentContext: context);
        _kubernetesClientConfiguration.Namespace = ns;
        _kubernetes = new Kubernetes(_kubernetesClientConfiguration);
    }

    public string CurrentContext => _kubernetesClientConfiguration?.CurrentContext ?? string.Empty;
    public string CurrentNamespace => _kubernetesClientConfiguration?.Namespace ?? string.Empty;
    public K8SConfiguration? ClustersConfiguration => _k8SConfiguration;

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

    public async Task<IResult<V1ServiceList>> GetServicesAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.CoreV1.ListNamespacedServiceAsync(nameSpace) : k.CoreV1.ListServiceForAllNamespacesAsync(),
            () => new V1ServiceList([]));
    }

    public async Task<IResult<V1NodeList>> GetNodesAsync()
    {
        return await GetOrDefault(_kubernetes, k => k.CoreV1.ListNodeAsync(), () => new V1NodeList([]));
    }

    public async Task<IResult<V1APIResourceList>> GetApiResourcesAsync()
    {
        return await GetOrDefault(_kubernetes,
            k => k.CoreV1.GetAPIResourcesAsync(),
            () => new V1APIResourceList(string.Empty, []));
    }

    public async Task<IResult<V1IngressList>> GetIngressesAsync(string? nameSpace = null)
    {
        return await GetOrDefault(_kubernetes, k => nameSpace.HasValue() ? k.NetworkingV1.ListNamespacedIngressAsync(nameSpace) : k.NetworkingV1.ListIngressForAllNamespacesAsync(),
            () => new V1IngressList([]));
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

}
