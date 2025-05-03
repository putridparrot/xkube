using k8s.Models;
using Spectre.Console;
using XKube.Extensions;

namespace XKube.ViewObjects;

public static class V1ServiceExtensions
{
    public static ICollection<ServiceViewObject> ToViewObject(this V1ServiceList list) =>
        list.Items.Select(item => item.ToViewObject()).ToArray();

    public static ServiceViewObject ToViewObject(this V1Service item)
    {
        return new ServiceViewObject
        {
            Name = item.Metadata?.Name ?? string.Empty,
            Namespace = item.Metadata?.NamespaceProperty ?? string.Empty,
            Type = item.Spec.Type ?? string.Empty,
            ClusterIp = item.Spec.ClusterIP ?? string.Empty,
            ExternalIp = item.Status.LoadBalancer?.Ingress?.FirstOrDefault()?.Ip ?? string.Empty,
            Ports = string.Join(",", item.Spec.Ports.Select(p => $"{p.Port}/{p.Protocol}")),
            Age = item.Metadata?.CreationTimestamp.ToAge()
        };
    }

    public static Grid ToGrid(this ICollection<ServiceViewObject> items)
    {
        var grid = new Grid();
        grid.AddColumn(new GridColumn().LeftAligned());
        grid.AddColumn(new GridColumn().LeftAligned());
        grid.AddColumn(new GridColumn().LeftAligned());
        grid.AddColumn(new GridColumn().LeftAligned());
        grid.AddColumn(new GridColumn().LeftAligned());
        grid.AddColumn(new GridColumn().LeftAligned());
        grid.AddColumn(new GridColumn().LeftAligned());

        grid.AddRow(
            new Text("NAMESPACE", new Style(Color.White)).LeftJustified(),
            new Text("NAME", new Style(Color.White)).LeftJustified(),
            new Text("TYPE", new Style(Color.White)).LeftJustified(),
            new Text("CLUSTER-IP", new Style(Color.White)).LeftJustified(),
            new Text("EXTERNAL-IP", new Style(Color.White)).LeftJustified(),
            new Text("PORTS", new Style(Color.White)).LeftJustified(),
            new Text("AGE", new Style(Color.White)).LeftJustified());

        foreach (var item in items)
        {
            grid.AddRow(
                item.Namespace,
                item.Name,
                item.Type,
                item.ClusterIp,
                item.ExternalIp,
                item.Ports,
                item.Age
            );
        }
        return grid;
    }
}
