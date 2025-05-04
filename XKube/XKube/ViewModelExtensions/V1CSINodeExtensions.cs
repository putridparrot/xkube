using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1CSINodeExtensions
{
    public static ICollection<CsiNodeViewModel> ToViewModel(this V1CSINodeList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static CsiNodeViewModel ToViewModel(this V1CSINode item)
    {
        return new CsiNodeViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            Age = item.Metadata.CreationTimestamp.ToAge() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<CsiNodeViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.Age
        ]);
    }
}