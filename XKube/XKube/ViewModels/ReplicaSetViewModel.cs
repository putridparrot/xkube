using System.ComponentModel;

namespace XKube.ViewModels;

public class ReplicaSetViewModel
{
    [DisplayName("Namespace")]
    public string Namespace { get; set; } = string.Empty;
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Replicas")]
    public string Replicas { get; set; } = string.Empty;
    [DisplayName("Available Replicas")]
    public string AvailableReplicas { get; set; } = string.Empty;
    [DisplayName("Ready Replicas")]
    public string ReadyReplicas { get; set; } = string.Empty;
    [DisplayName("Age")]
    public string Age { get; set; } = string.Empty;
}