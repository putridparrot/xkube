using System.ComponentModel;

namespace XKube.ViewModels;

public class PodViewModel
{
    [DisplayName("NAME")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("NAMESPACE")]
    public string Namespace { get; set; } = string.Empty;
    [DisplayName("STATUS")]
    public string Status { get; set; } = string.Empty;
    [DisplayName("RESTARTS")]
    public string Restarts { get; set; } = string.Empty;
    [DisplayName("AGE")]
    public string Age { get; set; } = string.Empty;
}