using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1beta1ResourceClaimExtensions
{
    public static ICollection<ResourceClaimViewModel> ToViewModel(this V1beta1ResourceClaimList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static ResourceClaimViewModel ToViewModel(this V1beta1ResourceClaim item)
    {
        return new ResourceClaimViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ResourceClaimViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}