using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1PodDisruptionBudgetExtensions
{
    public static ICollection<PodDisruptionBudgetViewModel> ToViewModel(this V1PodDisruptionBudgetList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static PodDisruptionBudgetViewModel ToViewModel(this V1PodDisruptionBudget item)
    {
        return new PodDisruptionBudgetViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<PodDisruptionBudgetViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}