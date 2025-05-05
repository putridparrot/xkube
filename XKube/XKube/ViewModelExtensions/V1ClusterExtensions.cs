using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1ClusterExtensions
{
    public static ICollection<ClusterViewModel> ToViewModel(this V1ClusterList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static ClusterViewModel ToViewModel(this V1Cluster item)
    {
        return new ClusterViewModel
        {
            Current = item.Current.ToString() ?? string.Empty,
            Name = item.Name ?? string.Empty,
            Cluster = item.Cluster ?? string.Empty,
            AuthInfo = item.AuthInfo ?? string.Empty,
            Namespace = item.Namespace ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ClusterViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Current,
            item.Name,
            item.Cluster,
            item.AuthInfo,
            item.Namespace
        ]);
    }
}