using System.ComponentModel;

namespace XKube.ViewModels;

public class PriorityClassViewModel
{
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Value")]
    public string Value { get; set; } = string.Empty;
    [DisplayName("Default")]
    public string Default { get; set; } = string.Empty;
    [DisplayName("Age")]
    public string Age { get; set; } = string.Empty;
}