using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1NetworkPolicyExtensions
{
    public static ICollection<NetworkPolicyViewModel> ToViewModel(this V1NetworkPolicyList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static NetworkPolicyViewModel ToViewModel(this V1NetworkPolicy item)
    {
        return new NetworkPolicyViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<NetworkPolicyViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}