using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1beta1ResourceSliceExtensions
{
    public static ICollection<ResourceSliceViewModel> ToViewModel(this V1beta1ResourceSliceList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static ResourceSliceViewModel ToViewModel(this V1beta1ResourceSlice item)
    {
        return new ResourceSliceViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ResourceSliceViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}