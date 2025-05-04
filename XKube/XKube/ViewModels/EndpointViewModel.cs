using System.ComponentModel;

namespace XKube.ViewModels;

public class EndpointViewModel
{
    [DisplayName("Namespace")]
    public string Namespace { get; set; } = string.Empty;
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Endpoints")]
    public string Endpoints { get; set; } = string.Empty;
    [DisplayName("Age")]
    public string Age { get; set; } = string.Empty;
}