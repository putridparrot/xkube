using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1StorageClassExtensions
{
    public static ICollection<StorageClassViewModel> ToViewModel(this V1StorageClassList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static StorageClassViewModel ToViewModel(this V1StorageClass item)
    {
        return new StorageClassViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            Age = item.Metadata.CreationTimestamp.ToAge() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<StorageClassViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.Age
        ]);
    }
}