using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1beta1IPAddressExtensions
{
    public static ICollection<IpAddressViewModel> ToViewModel(this V1beta1IPAddressList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static IpAddressViewModel ToViewModel(this V1beta1IPAddress item)
    {
        return new IpAddressViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<IpAddressViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}