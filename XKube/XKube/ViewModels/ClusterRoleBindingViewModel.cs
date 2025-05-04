using System.ComponentModel;

namespace XKube.ViewModels;

public class ClusterRoleBindingViewModel
{
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Role")]
    public string Role { get; set; } = string.Empty;
    [DisplayName("Users")]
    public string Users { get; set; } = string.Empty;
    [DisplayName("Groups")]
    public string Groups { get; set; } = string.Empty;
}