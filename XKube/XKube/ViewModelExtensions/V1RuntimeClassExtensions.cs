using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1RuntimeClassExtensions
{
    public static ICollection<RuntimeClassViewModel> ToViewModel(this V1RuntimeClassList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static RuntimeClassViewModel ToViewModel(this V1RuntimeClass item)
    {
        return new RuntimeClassViewModel
        {
            Namespace = item.Metadata.NamespaceProperty ?? string.Empty,
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<RuntimeClassViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Namespace,
            item.Name,
            item.CreationTimestamp
        ]);
    }
}