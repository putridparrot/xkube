using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1ValidatingAdmissionPolicyExtensions
{
    public static ICollection<ValidatingAdmissionPolicyViewModel> ToViewModel(this V1ValidatingAdmissionPolicyList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static ValidatingAdmissionPolicyViewModel ToViewModel(this V1ValidatingAdmissionPolicy item)
    {
        return new ValidatingAdmissionPolicyViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ValidatingAdmissionPolicyViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}