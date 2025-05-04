using System.ComponentModel;

namespace XKube.ViewModels;

public class DaemonSetViewModel
{
    [DisplayName("Namespace")]
    public string Namespace { get; set; } = string.Empty;
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Desired")]
    public string Desired { get; set; } = string.Empty;
    [DisplayName("Current")]
    public string Current { get; set; } = string.Empty;
    [DisplayName("Ready")]
    public string Ready { get; set; } = string.Empty;
    [DisplayName("Upto date")]
    public string Uptodate { get; set; } = string.Empty;
    [DisplayName("Available")]
    public string Available { get; set; } = string.Empty;
}