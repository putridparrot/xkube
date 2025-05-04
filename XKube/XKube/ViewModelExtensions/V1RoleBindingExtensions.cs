using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1RoleBindingExtensions
{
    public static ICollection<RoleBindingViewModel> ToViewModel(this V1RoleBindingList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static RoleBindingViewModel ToViewModel(this V1RoleBinding item)
    {
        return new RoleBindingViewModel
        {
            Namespace = item.Metadata.NamespaceProperty ?? string.Empty,
            Name = item.Metadata.Name ?? string.Empty,
            Role = $"{item.RoleRef.Kind}/{item.RoleRef.Name}" ?? string.Empty,
            Age = item.Metadata.CreationTimestamp.ToAge() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<RoleBindingViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Namespace,
            item.Name,
            item.Role,
            item.Age
        ]);
    }
}