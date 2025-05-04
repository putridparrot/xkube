using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1ReplicationControllerExtensions
{
    public static ICollection<ReplicationControllerViewModel> ToViewModel(this V1ReplicationControllerList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static ReplicationControllerViewModel ToViewModel(this V1ReplicationController item)
    {
        return new ReplicationControllerViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ReplicationControllerViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}