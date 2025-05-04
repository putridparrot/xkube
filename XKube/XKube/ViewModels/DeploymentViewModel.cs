using System.ComponentModel;

namespace XKube.ViewModels;

public class DeploymentViewModel
{
    [DisplayName("Namespace")]
    public string Namespace { get; set; } = string.Empty;
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Ready")]
    public string Ready { get; set; } = string.Empty;
    [DisplayName("Upto date")]
    public string Uptodate { get; set; } = string.Empty;
    [DisplayName("Available")]
    public string Available { get; set; } = string.Empty;
    [DisplayName("Age")]
    public string Age { get; set; } = string.Empty;
}