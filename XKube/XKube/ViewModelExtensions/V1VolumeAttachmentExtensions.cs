using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1VolumeAttachmentExtensions
{
    public static ICollection<VolumeAttachmentViewModel> ToViewModel(this V1VolumeAttachmentList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static VolumeAttachmentViewModel ToViewModel(this V1VolumeAttachment item)
    {
        return new VolumeAttachmentViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<VolumeAttachmentViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}