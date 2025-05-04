using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1SecretExtensions
{
    public static ICollection<SecretViewModel> ToViewModel(this V1SecretList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static SecretViewModel ToViewModel(this V1Secret item)
    {
        return new SecretViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<SecretViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}