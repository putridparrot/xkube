using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class Corev1EventExtensions
{
    public static ICollection<EventViewModel> ToViewModel(this Corev1EventList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static EventViewModel ToViewModel(this Corev1Event item)
    {
        return new EventViewModel
        {
            Type = item.Type ?? string.Empty,
            Name = item.Metadata.Name ?? string.Empty,
            Message = item.Message ?? string.Empty,
            ObjectName = item.InvolvedObject.Name ?? string.Empty,
            LastTimestamp = item.LastTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<EventViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Type,
            item.Name,
            item.Message,
            item.ObjectName,
            item.LastTimestamp
        ]);
    }
}