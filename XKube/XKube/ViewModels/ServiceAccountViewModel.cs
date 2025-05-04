using System.ComponentModel;

namespace XKube.ViewModels;

public class ServiceAccountViewModel
{
    [DisplayName("Namespace")]
    public string Namespace { get; set; } = string.Empty;
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Count")]
    public string Count { get; set; } = string.Empty;
    [DisplayName("Creation Timestamp")]
    public string CreationTimestamp { get; set; } = string.Empty;
}