using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1EndpointsExtensions
{
    public static ICollection<EndpointViewModel> ToViewModel(this V1EndpointsList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static EndpointViewModel ToViewModel(this V1Endpoints item)
    {
        return new EndpointViewModel
        {
            Namespace = item.Metadata.NamespaceProperty ?? string.Empty,
            Name = item.Metadata.Name ?? string.Empty,
            Endpoints = GetEndpointIps(item) ?? string.Empty,
            Age = item.Metadata.CreationTimestamp.ToAge() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<EndpointViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Namespace,
            item.Name,
            item.Endpoints,
            item.Age
        ]);
    }
    private static string? GetEndpointIps(V1Endpoints item) => item.Subsets is null ? string.Empty : item.Subsets.SelectMany(s => s.Addresses.Select(a => a.Ip)).CsvJoin();
}