using System.ComponentModel;

namespace XKube.ViewModels;

public class EndpointSliceViewModel
{
    [DisplayName("Namespace")]
    public string Namespace { get; set; } = string.Empty;
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Address Type")]
    public string AddressType { get; set; } = string.Empty;
    [DisplayName("Endpoints")]
    public string Endpoints { get; set; } = string.Empty;
    [DisplayName("Ports")]
    public string Ports { get; set; } = string.Empty;
    [DisplayName("Age")]
    public string Age { get; set; } = string.Empty;
}