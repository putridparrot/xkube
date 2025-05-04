using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V2HorizontalPodAutoscalerExtensions
{
    public static ICollection<HorizontalPodAutoscalerViewModel> ToViewModel(this V2HorizontalPodAutoscalerList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static HorizontalPodAutoscalerViewModel ToViewModel(this V2HorizontalPodAutoscaler item)
    {
        return new HorizontalPodAutoscalerViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<HorizontalPodAutoscalerViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}