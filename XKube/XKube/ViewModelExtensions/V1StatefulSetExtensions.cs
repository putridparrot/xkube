using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1StatefulSetExtensions
{
    public static ICollection<StatefuleSetViewModel> ToViewModel(this V1StatefulSetList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static StatefuleSetViewModel ToViewModel(this V1StatefulSet item)
    {
        return new StatefuleSetViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<StatefuleSetViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}