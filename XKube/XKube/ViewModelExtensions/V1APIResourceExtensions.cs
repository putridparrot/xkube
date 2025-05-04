using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1APIResourceExtensions
{
    public static ICollection<ApiResourceViewModel> ToViewModel(this V1APIResourceList list) =>
        list.Resources.Select(item => item.ToViewModel()).ToArray();

    public static ApiResourceViewModel ToViewModel(this V1APIResource item)
    {
        return new ApiResourceViewModel
        {
            Name = item.Name ?? string.Empty,
            Version = item.Version ?? string.Empty,
            Namespaced = item.Namespaced.ToString() ?? string.Empty,
            Shortnames = item.ShortNames.CsvJoin() ?? string.Empty,
            Kind = item.Kind ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ApiResourceViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.Version,
            item.Namespaced,
            item.Shortnames,
            item.Kind
        ]);
    }
}