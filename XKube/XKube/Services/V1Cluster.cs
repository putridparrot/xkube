using k8s.KubeConfigModels;

namespace k8s.Models;

/// <summary>
/// Used to allow the clusters to be displayed like any other resource
/// </summary>
public class V1Cluster
{
    public bool Current { get; set; }
    public string? Name{ get; set; }
    public string? Cluster { get; set; }
    public string? AuthInfo { get; set; }
    public string? Namespace { get; set; }
}

public class V1ClusterList
{
    public V1ClusterList()
    {
    }

    public V1ClusterList(IList<V1Cluster> items)
    {
        Items = items;
    }

    public IList<V1Cluster> Items { get; set; }
}

public class ClusterContext(Cluster? cluster, Context? context)
{
    public Cluster? Cluster { get; set; } = cluster;
    public Context? Context { get; set; } = context;
}