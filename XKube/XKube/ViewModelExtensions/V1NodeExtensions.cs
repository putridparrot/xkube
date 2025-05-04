using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1NodeExtensions
{
    public static ICollection<NodeViewModel> ToViewModel(this V1NodeList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static NodeViewModel ToViewModel(this V1Node item)
    {
        return new NodeViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            Status = GetStatus(item) ?? string.Empty,
            Age = item.Metadata.CreationTimestamp.ToAge() ?? string.Empty,
            Version = item.Status.NodeInfo.KubeletVersion ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<NodeViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.Status,
            item.Age,
            item.Version
        ]);
    }
    private static string? GetStatus(V1Node item) => item.Status.Conditions.FirstOrDefault(s => s.Type == "Ready")?.Status == "True" ? "Ready" : string.Empty;
}