using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1beta1ServiceCIDRExtensions
{
    public static ICollection<ServiceCidrsViewModel> ToViewModel(this V1beta1ServiceCIDRList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static ServiceCidrsViewModel ToViewModel(this V1beta1ServiceCIDR item)
    {
        return new ServiceCidrsViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ServiceCidrsViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}