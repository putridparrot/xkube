using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1NamespaceExtensions
{
    public static ICollection<NamespaceViewModel> ToViewModel(this V1NamespaceList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static NamespaceViewModel ToViewModel(this V1Namespace item)
    {
        return new NamespaceViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            Phase = item.Status.Phase ?? string.Empty,
            Age = item.Metadata.CreationTimestamp.ToAge() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<NamespaceViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.Phase,
            item.Age
        ]);
    }
}