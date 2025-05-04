using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1PodTemplateExtensions
{
    public static ICollection<PodTemplateViewModel> ToViewModel(this V1PodTemplateList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static PodTemplateViewModel ToViewModel(this V1PodTemplate item)
    {
        return new PodTemplateViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<PodTemplateViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}