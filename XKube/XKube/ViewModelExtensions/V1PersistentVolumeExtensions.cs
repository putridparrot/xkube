using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1PersistentVolumeExtensions
{
    public static ICollection<PersistentVolumeViewModel> ToViewModel(this V1PersistentVolumeList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static PersistentVolumeViewModel ToViewModel(this V1PersistentVolume item)
    {
        return new PersistentVolumeViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<PersistentVolumeViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}