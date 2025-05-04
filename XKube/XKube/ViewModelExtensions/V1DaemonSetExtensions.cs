using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1DaemonSetExtensions
{
    public static ICollection<DaemonSetViewModel> ToViewModel(this V1DaemonSetList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static DaemonSetViewModel ToViewModel(this V1DaemonSet item)
    {
        return new DaemonSetViewModel
        {
            Namespace = item.Metadata.NamespaceProperty ?? string.Empty,
            Name = item.Metadata.Name ?? string.Empty,
            Desired = item.Status.DesiredNumberScheduled.ToString() ?? string.Empty,
            Current = item.Status.CurrentNumberScheduled.ToString() ?? string.Empty,
            Ready = item.Status.NumberReady.ToString() ?? string.Empty,
            Uptodate = item.Status.UpdatedNumberScheduled?.ToString() ?? string.Empty,
            Available = item.Status.NumberAvailable.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<DaemonSetViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Namespace,
            item.Name,
            item.Desired,
            item.Current,
            item.Ready,
            item.Uptodate,
            item.Available
        ]);
    }
}