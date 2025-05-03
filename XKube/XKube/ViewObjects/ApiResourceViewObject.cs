namespace XKube.ViewObjects;

public class ApiResourceViewObject
{
    public string Name { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Namespaced { get; set; } = string.Empty;
    public string Shortnames { get; set; } = string.Empty;
    public string Kind { get; set; } = string.Empty;
}