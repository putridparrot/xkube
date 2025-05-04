using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1APIServiceExtensions
{
    public static ICollection<ApiServiceViewModel> ToViewModel(this V1APIServiceList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static ApiServiceViewModel ToViewModel(this V1APIService item)
    {
        return new ApiServiceViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            Service = item.Status.Conditions[0].Reason ?? string.Empty,
            Available = item.Status.Conditions[0].Status ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ApiServiceViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.Service,
            item.Available
        ]);
    }
}