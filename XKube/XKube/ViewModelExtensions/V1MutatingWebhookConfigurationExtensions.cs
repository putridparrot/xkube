using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1MutatingWebhookConfigurationExtensions
{
    public static ICollection<MutatingWebhookConfigurationViewModel> ToViewModel(this V1MutatingWebhookConfigurationList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static MutatingWebhookConfigurationViewModel ToViewModel(this V1MutatingWebhookConfiguration item)
    {
        return new MutatingWebhookConfigurationViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<MutatingWebhookConfigurationViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}