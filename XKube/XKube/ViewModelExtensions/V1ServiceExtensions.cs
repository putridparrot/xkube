using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1ServiceExtensions
{
    public static ICollection<ServiceViewModel> ToViewModel(this V1ServiceList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static ServiceViewModel ToViewModel(this V1Service item)
    {
        return new ServiceViewModel
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

    public static Grid ToGrid(this ICollection<ServiceViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Namespace,
            item.Name,
            item.Type,
            item.ClusterIp,
            item.ExternalIp,
            item.Ports,
            item.Age
        ]);
    }
}
