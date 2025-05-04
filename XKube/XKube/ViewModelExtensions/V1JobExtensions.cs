using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1JobExtensions
{
    public static ICollection<JobViewModel> ToViewModel(this V1JobList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static JobViewModel ToViewModel(this V1Job item)
    {
        return new JobViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<JobViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}