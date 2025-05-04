using System.ComponentModel;

namespace XKube.ViewModels;

public class ControllerRevisionViewModel
{
    [DisplayName("Namespace")]
    public string Namespace { get; set; } = string.Empty;
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Controller")]
    public string Controller { get; set; } = string.Empty;
    [DisplayName("Revision")]
    public string Revision { get; set; } = string.Empty;
}