namespace XKube.ViewObjects;

public class ServiceViewObject
{
    public string Name { get; set; } = string.Empty;
    public string Namespace { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string ClusterIp { get; set; } = string.Empty;
    public string ExternalIp { get; set; } = string.Empty;
    public string Ports { get; set; } = string.Empty;
    public string Age { get; set; } = string.Empty;
}