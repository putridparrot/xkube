using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1ClusterRoleExtensions
{
    public static ICollection<ClusterRoleViewModel> ToViewModel(this V1ClusterRoleList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static ClusterRoleViewModel ToViewModel(this V1ClusterRole item)
    {
        return new ClusterRoleViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ClusterRoleViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}