using System.ComponentModel;

namespace XKube.ViewModels;

public class CsiNodeViewModel
{
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Age")]
    public string Age { get; set; } = string.Empty;
}