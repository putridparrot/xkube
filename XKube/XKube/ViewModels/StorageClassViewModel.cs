using System.ComponentModel;

namespace XKube.ViewModels;

public class StorageClassViewModel
{
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Age")]
    public string Age { get; set; } = string.Empty;
}