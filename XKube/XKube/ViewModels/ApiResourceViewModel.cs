using System.ComponentModel;

namespace XKube.ViewModels;

public class ApiResourceViewModel
{
    [DisplayName("NAME")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("VERSION")]
    public string Version { get; set; } = string.Empty;
    [DisplayName("NAMESPACED")]
    public string Namespaced { get; set; } = string.Empty;
    [DisplayName("SHORTNAMES")]
    public string Shortnames { get; set; } = string.Empty;
    [DisplayName("KIND")]
    public string Kind { get; set; } = string.Empty;
}