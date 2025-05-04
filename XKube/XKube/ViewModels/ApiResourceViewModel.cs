using System.ComponentModel;

namespace XKube.ViewModels;

public class ApiResourceViewModel
{
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Version")]
    public string Version { get; set; } = string.Empty;
    [DisplayName("Namespaced")]
    public string Namespaced { get; set; } = string.Empty;
    [DisplayName("Shortnames")]
    public string Shortnames { get; set; } = string.Empty;
    [DisplayName("Kind")]
    public string Kind { get; set; } = string.Empty;
}