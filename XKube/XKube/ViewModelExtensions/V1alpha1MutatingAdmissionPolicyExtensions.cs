using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1alpha1MutatingAdmissionPolicyExtensions
{
    public static ICollection<MutatingAdmissionPolicyViewModel> ToViewModel(this V1alpha1MutatingAdmissionPolicyList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static MutatingAdmissionPolicyViewModel ToViewModel(this V1alpha1MutatingAdmissionPolicy item)
    {
        return new MutatingAdmissionPolicyViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<MutatingAdmissionPolicyViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}