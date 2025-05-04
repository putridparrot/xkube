using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1LimitRangeExtensions
{
    public static ICollection<LimitRangeViewModel> ToViewModel(this V1LimitRangeList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static LimitRangeViewModel ToViewModel(this V1LimitRange item)
    {
        return new LimitRangeViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<LimitRangeViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}