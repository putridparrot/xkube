using System.ComponentModel;

namespace XKube.ViewModels;

public class PodViewModel
{
    [DisplayName("Namespace")]
    public string Namespace { get; set; } = string.Empty;
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Status")]
    public string Status { get; set; } = string.Empty;
    [DisplayName("Restarts")]
    public string Restarts { get; set; } = string.Empty;
    [DisplayName("Pod IP")]
    public string PodIP { get; set; } = string.Empty;
    [DisplayName("Age")]
    public string Age { get; set; } = string.Empty;
}