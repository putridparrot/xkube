using k8s.Models;
using Spectre.Console;

namespace XKube.ViewObjects;

public static class V1IngressExtensions
{
    public static ICollection<IngressViewObject> ToViewObject(this V1IngressList list) =>
        list.Items.Select(item => item.ToViewObject()).ToArray();

    public static IngressViewObject ToViewObject(this V1Ingress item)
    {
        return new IngressViewObject
        {
            Name = item.Metadata?.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp
        };
    }

    public static Grid ToGrid(this ICollection<IngressViewObject> items)
    {
        var grid = new Grid();
        grid.AddColumn(new GridColumn().LeftAligned());
        grid.AddColumn(new GridColumn().LeftAligned());

        grid.AddRow(
            new Text("NAME", new Style(Color.White)).LeftJustified(),
            new Text("CREATION TIMESTAMP", new Style(Color.White)).LeftJustified());

        foreach (var item in items)
        {
            grid.AddRow(
                item.Name,
                item.CreationTimestamp?.ToString() ?? string.Empty
            );
        }
        return grid;
    }
}