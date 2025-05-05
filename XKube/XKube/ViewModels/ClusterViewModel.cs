using System.ComponentModel;

namespace XKube.ViewModels;

public class ClusterViewModel
{
    [DisplayName("Current")]
    public string Current { get; set; } = string.Empty;
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Cluster")]
    public string Cluster { get; set; } = string.Empty;
    [DisplayName("Auth Info")]
    public string AuthInfo { get; set; } = string.Empty;
    [DisplayName("Namespace")]
    public string Namespace { get; set; } = string.Empty;
}