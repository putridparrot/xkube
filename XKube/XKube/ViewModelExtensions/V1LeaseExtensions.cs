using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1LeaseExtensions
{
    public static ICollection<LeaseViewModel> ToViewModel(this V1LeaseList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static LeaseViewModel ToViewModel(this V1Lease item)
    {
        return new LeaseViewModel
        {
            Namespace = item.Metadata.NamespaceProperty ?? string.Empty,
            Name = item.Metadata.Name ?? string.Empty,
            Holder = item.Spec.HolderIdentity ?? string.Empty,
            Age = item.Metadata.CreationTimestamp.ToAge() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<LeaseViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Namespace,
            item.Name,
            item.Holder,
            item.Age
        ]);
    }
}