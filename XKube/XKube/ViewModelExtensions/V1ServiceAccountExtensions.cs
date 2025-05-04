using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1ServiceAccountExtensions
{
    public static ICollection<ServiceAccountViewModel> ToViewModel(this V1ServiceAccountList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static ServiceAccountViewModel ToViewModel(this V1ServiceAccount item)
    {
        return new ServiceAccountViewModel
        {
            Namespace = item.Metadata.NamespaceProperty ?? string.Empty,
            Name = item.Metadata.Name ?? string.Empty,
            Count = GetCount(item).ToString() ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ServiceAccountViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Namespace,
            item.Name,
            item.Count,
            item.CreationTimestamp
        ]);
    }
    private static int GetCount(V1ServiceAccount item) => item.Secrets?.Count ?? 0;
}