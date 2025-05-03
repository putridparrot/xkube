using k8s.Models;
using Spectre.Console;
using XKube.Extensions;

namespace XKube.ViewObjects;

public static class V1PodExtensions
{
    public static ICollection<PodViewObject> ToViewObject(this V1PodList list) =>
        list.Items.Select(item => item.ToViewObject()).ToArray();

    public static PodViewObject ToViewObject(this V1Pod item)
    {
        return new PodViewObject
        {
            Name = item.Metadata?.Name ?? string.Empty,
            Namespace = item.Metadata?.NamespaceProperty ?? string.Empty,
            Status = item.Status?.Phase ?? string.Empty,
            Restarts = $"{GetRestarts(item)} ({GetLastRestart(item)} ago)",
            Age = item.Metadata?.CreationTimestamp.ToAge()
        };
    }

    public static Grid ToGrid(this ICollection<PodViewObject> items)
    {
        var grid = new Grid();
        grid.AddColumn(new GridColumn().LeftAligned());
        grid.AddColumn(new GridColumn().LeftAligned());
        grid.AddColumn(new GridColumn().LeftAligned());
        grid.AddColumn(new GridColumn().LeftAligned());
        grid.AddColumn(new GridColumn().LeftAligned());
        grid.AddColumn(new GridColumn().LeftAligned());

        grid.AddRow(
            new Text("NAMESPACE", new Style(Color.White)).LeftJustified(),
            new Text("NAME", new Style(Color.White)).LeftJustified(),
            //new Text("READY", new Style(Color.White)).LeftJustified(),
            new Text("STATUS", new Style(Color.White)).LeftJustified(),
            new Text("RESTARTS", new Style(Color.White)).LeftJustified(),
            new Text("AGE", new Style(Color.White)).LeftJustified());

        foreach (var item in items)
        {
            grid.AddRow(
                item.Namespace,
                item.Name,
                //string.Empty,
                $"[green]{item.Status}[/]",
                item.Restarts,
                item.Age
            );
        }
        return grid;
    }

    private static string GetRestarts(V1Pod item) => item.Status.ContainerStatuses.FirstOrDefault()?.RestartCount.ToString() ?? string.Empty;
    private static string GetLastRestart(V1Pod item) => item.Status.ContainerStatuses.FirstOrDefault()?.State.Running.StartedAt.ToAge() ?? string.Empty;

}
