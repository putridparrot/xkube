using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1EndpointSliceExtensions
{
    public static ICollection<EndpointSliceViewModel> ToViewModel(this V1EndpointSliceList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static EndpointSliceViewModel ToViewModel(this V1EndpointSlice item)
    {
        return new EndpointSliceViewModel
        {
            Namespace = item.Metadata.NamespaceProperty ?? string.Empty,
            Name = item.Metadata.Name ?? string.Empty,
            AddressType = item.AddressType ?? string.Empty,
            Endpoints = item.Endpoints.SelectMany(e => e.Addresses).CsvJoin() ?? string.Empty,
            Ports = item.Ports.Select(i => i.Port).CsvJoin() ?? string.Empty,
            Age = item.Metadata.CreationTimestamp.ToAge() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<EndpointSliceViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Namespace,
            item.Name,
            item.AddressType,
            item.Endpoints,
            item.Ports,
            item.Age
        ]);
    }
}