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
            Name = item.Metadata?.Name ?? string.Empty,
            Status = item.Status?.Phase ?? string.Empty,
            Age = item.Metadata?.CreationTimestamp.ToAge()
        };
    }

    public static Grid ToGrid(this ICollection<NodeViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            $"[green]{item.Status}[/]",
            item.Age,
            item.Version
        ]);
    }
}