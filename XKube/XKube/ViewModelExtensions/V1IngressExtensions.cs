using k8s.Models;
using Spectre.Console;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1IngressExtensions
{
    public static ICollection<IngressViewModel> ToViewModel(this V1IngressList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static IngressViewModel ToViewModel(this V1Ingress item)
    {
        return new IngressViewModel
        {
            Name = item.Metadata?.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp
        };
    }

    public static Grid ToGrid(this ICollection<IngressViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp?.ToString() ?? string.Empty
        ]);
    }
}