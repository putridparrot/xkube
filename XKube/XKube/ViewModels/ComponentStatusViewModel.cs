using System.ComponentModel;

namespace XKube.ViewModels;

public class ComponentStatusViewModel
{
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Status")]
    public string Status { get; set; } = string.Empty;
    [DisplayName("Message")]
    public string Message { get; set; } = string.Empty;
    [DisplayName("Error")]
    public string Error { get; set; } = string.Empty;
}