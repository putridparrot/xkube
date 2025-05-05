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
    public IList<V1Cluster> Items { get; set; }
}
