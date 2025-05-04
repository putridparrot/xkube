using k8s.Models;
using Spectre.Console;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1ApiResourcesExtensions
{
    public static ICollection<ApiResourceViewModel> ToViewModel(this V1APIResourceList list) =>
        list.Resources.Select(item => item.ToViewModel()).ToArray();

    public static ApiResourceViewModel ToViewModel(this V1APIResource item)
    {
        return new ApiResourceViewModel
        {
            Name = item.Name ?? string.Empty,
            Version = item.Version ?? string.Empty,
            Namespaced = item.Namespaced.ToString(),
            Shortnames = string.Join(",", item.ShortNames ?? Array.Empty<string>()),
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