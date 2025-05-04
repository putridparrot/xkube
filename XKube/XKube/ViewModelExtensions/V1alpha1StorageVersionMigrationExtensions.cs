using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1alpha1StorageVersionMigrationExtensions
{
    public static ICollection<StorageVersionMigrationViewModel> ToViewModel(this V1alpha1StorageVersionMigrationList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static StorageVersionMigrationViewModel ToViewModel(this V1alpha1StorageVersionMigration item)
    {
        return new StorageVersionMigrationViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<StorageVersionMigrationViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}