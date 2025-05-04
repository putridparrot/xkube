using System.ComponentModel;

namespace XKube.ViewModels;

public class ServiceViewModel
{
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Namespace")]
    public string Namespace { get; set; } = string.Empty;
    [DisplayName("Type")]
    public string Type { get; set; } = string.Empty;
    [DisplayName("Cluster IP")]
    public string ClusterIP { get; set; } = string.Empty;
    [DisplayName("External IP")]
    public string ExternalIP { get; set; } = string.Empty;
    [DisplayName("Ports")]
    public string Ports { get; set; } = string.Empty;
    [DisplayName("Age")]
    public string Age { get; set; } = string.Empty;
}