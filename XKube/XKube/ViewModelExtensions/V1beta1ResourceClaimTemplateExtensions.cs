using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1beta1ResourceClaimTemplateExtensions
{
    public static ICollection<ResourceClaimTeplateViewModel> ToViewModel(this V1beta1ResourceClaimTemplateList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static ResourceClaimTeplateViewModel ToViewModel(this V1beta1ResourceClaimTemplate item)
    {
        return new ResourceClaimTeplateViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ResourceClaimTeplateViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}