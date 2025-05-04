using System.ComponentModel;

namespace XKube.ViewModels;

public class ServiceViewModel
{
    [DisplayName("NAME")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("NAMESPACE")]
    public string Namespace { get; set; } = string.Empty;
    [DisplayName("TYPE")]
    public string Type { get; set; } = string.Empty;
    [DisplayName("CLUSTER-IP")]
    public string ClusterIp { get; set; } = string.Empty;
    [DisplayName("EXTERNAL-IP")]
    public string ExternalIp { get; set; } = string.Empty;
    [DisplayName("PORTS")]
    public string Ports { get; set; } = string.Empty;
    [DisplayName("AGE")]
    public string Age { get; set; } = string.Empty;
}