using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1PersistentVolumeClaimExtensions
{
    public static ICollection<PersistentVolumeClaimViewModel> ToViewModel(this V1PersistentVolumeClaimList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static PersistentVolumeClaimViewModel ToViewModel(this V1PersistentVolumeClaim item)
    {
        return new PersistentVolumeClaimViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<PersistentVolumeClaimViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}