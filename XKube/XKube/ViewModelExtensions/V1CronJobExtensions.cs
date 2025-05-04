using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1CronJobExtensions
{
    public static ICollection<CronJobViewModel> ToViewModel(this V1CronJobList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static CronJobViewModel ToViewModel(this V1CronJob item)
    {
        return new CronJobViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<CronJobViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}