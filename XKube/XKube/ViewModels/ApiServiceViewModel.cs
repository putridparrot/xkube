using System.ComponentModel;

namespace XKube.ViewModels;

public class ApiServiceViewModel
{
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Service")]
    public string Service { get; set; } = string.Empty;
    [DisplayName("Available")]
    public string Available { get; set; } = string.Empty;
}