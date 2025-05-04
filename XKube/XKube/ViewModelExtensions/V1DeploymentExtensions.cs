using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1DeploymentExtensions
{
    public static ICollection<DeploymentViewModel> ToViewModel(this V1DeploymentList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static DeploymentViewModel ToViewModel(this V1Deployment item)
    {
        return new DeploymentViewModel
        {
            Namespace = item.Metadata.NamespaceProperty ?? string.Empty,
            Name = item.Metadata.Name ?? string.Empty,
            Ready = $"{item.Status.ReadyReplicas}/{item.Status.AvailableReplicas}" ?? string.Empty,
            Uptodate = item.Status.UpdatedReplicas.ToString() ?? string.Empty,
            Available = item.Status.AvailableReplicas.ToString() ?? string.Empty,
            Age = item.Metadata.CreationTimestamp.ToAge() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<DeploymentViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Namespace,
            item.Name,
            item.Ready,
            item.Uptodate,
            item.Available,
            item.Age
        ]);
    }
}