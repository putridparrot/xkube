using k8s.Models;
using Spectre.Console;
using XKube.Extensions;

namespace XKube.ViewObjects;

public static class V1NodeExtensions
{
    public static ICollection<NodeViewObject> ToViewObject(this V1NodeList list) =>
        list.Items.Select(item => item.ToViewObject()).ToArray();

    public static NodeViewObject ToViewObject(this V1Node item)
    {
        return new NodeViewObject
        {
            Name = item.Metadata?.Name ?? string.Empty,
            Status = item.Status?.Phase ?? string.Empty,
            Age = item.Metadata?.CreationTimestamp.ToAge()
        };
    }

    public static Grid ToGrid(this ICollection<NodeViewObject> items)
    {
        var grid = new Grid();
        grid.AddColumn(new GridColumn().LeftAligned());
        grid.AddColumn(new GridColumn().LeftAligned());
        grid.AddColumn(new GridColumn().LeftAligned());
        grid.AddColumn(new GridColumn().LeftAligned());

        grid.AddRow(
            new Text("NAME", new Style(Color.White)).LeftJustified(),
            new Text("STATUS", new Style(Color.White)).LeftJustified(),
            new Text("AGE", new Style(Color.White)).LeftJustified(),
            new Text("VERSION", new Style(Color.White)).LeftJustified());

        foreach (var item in items)
        {
            grid.AddRow(
                item.Name,
                $"[green]{item.Status}[/]",
                item.Age,
                item.Version
            );
        }
        return grid;
    }
}