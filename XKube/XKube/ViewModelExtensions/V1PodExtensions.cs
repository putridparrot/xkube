using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1PodExtensions
{
    public static ICollection<PodViewModel> ToViewModel(this V1PodList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static PodViewModel ToViewModel(this V1Pod item)
    {
        return new PodViewModel
        {
            Name = item.Metadata?.Name ?? string.Empty,
            Namespace = item.Metadata?.NamespaceProperty ?? string.Empty,
            Status = item.Status?.Phase ?? string.Empty,
            Restarts = $"{GetRestarts(item)} ({GetLastRestart(item)} ago)",
            Age = item.Metadata?.CreationTimestamp.ToAge()
        };
    }

    public static Grid ToGrid(this ICollection<PodViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.Namespace,
            //string.Empty,
            $"[green]{item.Status}[/]",
            item.Restarts,
            item.Age
        ]);
    }

    private static string GetRestarts(V1Pod item) => item.Status.ContainerStatuses.FirstOrDefault()?.RestartCount.ToString() ?? string.Empty;
    private static string GetLastRestart(V1Pod item) => item.Status.ContainerStatuses.FirstOrDefault()?.State.Running.StartedAt.ToAge() ?? string.Empty;

}
