using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1beta1DeviceClassExtensions
{
    public static ICollection<DeviceClassViewModel> ToViewModel(this V1beta1DeviceClassList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static DeviceClassViewModel ToViewModel(this V1beta1DeviceClass item)
    {
        return new DeviceClassViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<DeviceClassViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}