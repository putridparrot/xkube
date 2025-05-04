using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1ReplicaSetExtensions
{
    public static ICollection<ReplicaSetViewModel> ToViewModel(this V1ReplicaSetList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static ReplicaSetViewModel ToViewModel(this V1ReplicaSet item)
    {
        return new ReplicaSetViewModel
        {
            Namespace = item.Metadata.NamespaceProperty ?? string.Empty,
            Name = item.Metadata.Name ?? string.Empty,
            Replicas = item.Status.Replicas.ToString() ?? string.Empty,
            AvailableReplicas = item.Status.AvailableReplicas.ToString() ?? string.Empty,
            ReadyReplicas = item.Status.ReadyReplicas.ToString() ?? string.Empty,
            Age = item.Metadata.CreationTimestamp.ToAge() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ReplicaSetViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Namespace,
            item.Name,
            item.Replicas,
            item.AvailableReplicas,
            item.ReadyReplicas,
            item.Age
        ]);
    }
}