using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1beta1VolumeAttributesClassExtensions
{
    public static ICollection<VolumeAttributeViewModel> ToViewModel(this V1beta1VolumeAttributesClassList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static VolumeAttributeViewModel ToViewModel(this V1beta1VolumeAttributesClass item)
    {
        return new VolumeAttributeViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<VolumeAttributeViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}