namespace XKube.ViewObjects;

public class PodViewObject
{
    public string Name { get; set; } = string.Empty;
    public string Namespace { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Restarts { get; set; } = string.Empty;
    public string Age { get; set; } = string.Empty;
}