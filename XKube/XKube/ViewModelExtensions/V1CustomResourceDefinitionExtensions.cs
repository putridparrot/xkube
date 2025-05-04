using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1CustomResourceDefinitionExtensions
{
    public static ICollection<CustomResourceDefinitionViewModel> ToViewModel(this V1CustomResourceDefinitionList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static CustomResourceDefinitionViewModel ToViewModel(this V1CustomResourceDefinition item)
    {
        return new CustomResourceDefinitionViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<CustomResourceDefinitionViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}