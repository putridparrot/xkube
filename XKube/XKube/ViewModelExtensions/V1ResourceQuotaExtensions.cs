using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1ResourceQuotaExtensions
{
    public static ICollection<ResourceQuotasViewModel> ToViewModel(this V1ResourceQuotaList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static ResourceQuotasViewModel ToViewModel(this V1ResourceQuota item)
    {
        return new ResourceQuotasViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ResourceQuotasViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}