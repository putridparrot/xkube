using System.ComponentModel;

namespace XKube.ViewModels;

public class NodeViewModel
{
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Status")]
    public string Status { get; set; } = string.Empty;
    [DisplayName("Age")]
    public string Age { get; set; } = string.Empty;
    [DisplayName("Version")]
    public string Version { get; set; } = string.Empty;
}