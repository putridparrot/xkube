using System.ComponentModel;

namespace XKube.ViewModels;

public class NamespaceViewModel
{
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Phase")]
    public string Phase { get; set; } = string.Empty;
    [DisplayName("Age")]
    public string Age { get; set; } = string.Empty;
}