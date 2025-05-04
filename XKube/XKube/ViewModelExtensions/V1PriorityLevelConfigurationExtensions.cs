using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1PriorityLevelConfigurationExtensions
{
    public static ICollection<PriorityLevelConfigurationViewModel> ToViewModel(this V1PriorityLevelConfigurationList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static PriorityLevelConfigurationViewModel ToViewModel(this V1PriorityLevelConfiguration item)
    {
        return new PriorityLevelConfigurationViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            Type = item.Spec.Type ?? string.Empty,
            Age = item.Metadata.CreationTimestamp.ToAge() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<PriorityLevelConfigurationViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.Type,
            item.Age
        ]);
    }
}