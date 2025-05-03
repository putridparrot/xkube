using k8s.Models;
using Spectre.Console;

namespace XKube.ViewObjects;

public static class V1ApiResourcesExtensions
{
    public static ICollection<ApiResourceViewObject> ToViewObject(this V1APIResourceList list) =>
        list.Resources.Select(item => item.ToViewObject()).ToArray();

    public static ApiResourceViewObject ToViewObject(this V1APIResource item)
    {
        return new ApiResourceViewObject
        {
            Name = item.Name ?? string.Empty,
            Version = item.Version ?? string.Empty,
            Namespaced = item.Namespaced.ToString(),
            Shortnames = string.Join(",", item.ShortNames ?? Array.Empty<string>()),
            Kind = item.Kind ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ApiResourceViewObject> items)
    {
        var grid = new Grid();
        grid.AddColumn(new GridColumn().LeftAligned());
        grid.AddColumn(new GridColumn().LeftAligned());
        grid.AddColumn(new GridColumn().LeftAligned());
        grid.AddColumn(new GridColumn().LeftAligned());
        grid.AddColumn(new GridColumn().LeftAligned());

        grid.AddRow(
            new Text("NAME", new Style(Color.White)).LeftJustified(),
            new Text("VERSION", new Style(Color.White)).LeftJustified(),
            new Text("NAMESPACED", new Style(Color.White)).LeftJustified(),
            new Text("SHORTNAMES", new Style(Color.White)).LeftJustified(),
            new Text("KIND", new Style(Color.White)).LeftJustified());

        foreach (var item in items)
        {
            grid.AddRow(
                item.Name, 
                item.Version,
                item.Namespaced,
                item.Shortnames,
                item.Kind
            );
        }
        return grid;
    }
}