using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1ComponentStatusExtensions
{
    public static ICollection<ComponentStatusViewModel> ToViewModel(this V1ComponentStatusList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static ComponentStatusViewModel ToViewModel(this V1ComponentStatus item)
    {
        return new ComponentStatusViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            Status = item.Conditions[0].Status ?? string.Empty,
            Message = item.Conditions[0].Message ?? string.Empty,
            Error = item.Conditions[0].Error ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ComponentStatusViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.Status,
            item.Message,
            item.Error
        ]);
    }
}