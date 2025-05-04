using System.ComponentModel;

namespace XKube.ViewModels;

public class RoleBindingViewModel
{
    [DisplayName("Namespace")]
    public string Namespace { get; set; } = string.Empty;
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Role")]
    public string Role { get; set; } = string.Empty;
    [DisplayName("Age")]
    public string Age { get; set; } = string.Empty;
}