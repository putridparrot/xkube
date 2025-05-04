using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1alpha1StorageVersionExtensions
{
    public static ICollection<StorageVersionViewModel> ToViewModel(this V1alpha1StorageVersionList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static StorageVersionViewModel ToViewModel(this V1alpha1StorageVersion item)
    {
        return new StorageVersionViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<StorageVersionViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}