using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1ValidatingWebhookConfigurationExtensions
{
    public static ICollection<ValidatingWebhookConfigurationViewModel> ToViewModel(this V1ValidatingWebhookConfigurationList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static ValidatingWebhookConfigurationViewModel ToViewModel(this V1ValidatingWebhookConfiguration item)
    {
        return new ValidatingWebhookConfigurationViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ValidatingWebhookConfigurationViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}