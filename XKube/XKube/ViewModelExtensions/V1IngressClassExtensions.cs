using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1IngressClassExtensions
{
    public static ICollection<IngressClassViewModel> ToViewModel(this V1IngressClassList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static IngressClassViewModel ToViewModel(this V1IngressClass item)
    {
        return new IngressClassViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<IngressClassViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}