using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1alpha1ClusterTrustBundleExtensions
{
    public static ICollection<ClusterTrustBundleViewModel> ToViewModel(this V1alpha1ClusterTrustBundleList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static ClusterTrustBundleViewModel ToViewModel(this V1alpha1ClusterTrustBundle item)
    {
        return new ClusterTrustBundleViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ClusterTrustBundleViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}