using System.ComponentModel;

namespace XKube.ViewModels;

public class ServiceCidrsViewModel
{
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Creation Timestamp")]
    public string CreationTimestamp { get; set; } = string.Empty;
}