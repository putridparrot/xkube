using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1ConfigMapExtensions
{
    public static ICollection<ConfigMapViewModel> ToViewModel(this V1ConfigMapList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static ConfigMapViewModel ToViewModel(this V1ConfigMap item)
    {
        return new ConfigMapViewModel
        {
            Namespace = item.Metadata.NamespaceProperty ?? string.Empty,
            Name = item.Metadata.Name ?? string.Empty,
            Data = item.Data.Count.ToString() ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ConfigMapViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Namespace,
            item.Name,
            item.Data,
            item.CreationTimestamp
        ]);
    }
}