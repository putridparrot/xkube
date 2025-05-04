using System.ComponentModel;

namespace XKube.ViewModels;

public class PriorityLevelConfigurationViewModel
{
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Type")]
    public string Type { get; set; } = string.Empty;
    [DisplayName("Age")]
    public string Age { get; set; } = string.Empty;
}