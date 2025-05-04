using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1PriorityClassExtensions
{
    public static ICollection<PriorityClassViewModel> ToViewModel(this V1PriorityClassList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static PriorityClassViewModel ToViewModel(this V1PriorityClass item)
    {
        return new PriorityClassViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            Value = item.Value.ToString() ?? string.Empty,
            Default = GlobalDefault(item).ToString() ?? string.Empty,
            Age = item.Metadata.CreationTimestamp.ToAge() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<PriorityClassViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.Value,
            item.Default,
            item.Age
        ]);
    }
    private static bool GlobalDefault(V1PriorityClass item) => item.GlobalDefault ?? false;
}