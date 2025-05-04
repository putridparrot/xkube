using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1ControllerRevisionExtensions
{
    public static ICollection<ControllerRevisionViewModel> ToViewModel(this V1ControllerRevisionList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static ControllerRevisionViewModel ToViewModel(this V1ControllerRevision item)
    {
        return new ControllerRevisionViewModel
        {
            Namespace = item.Metadata.NamespaceProperty ?? string.Empty,
            Name = item.Metadata.Name ?? string.Empty,
            Controller = item.Metadata.OwnerReferences[0].Name ?? string.Empty,
            Revision = item.Revision.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ControllerRevisionViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Namespace,
            item.Name,
            item.Controller,
            item.Revision
        ]);
    }
}