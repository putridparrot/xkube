using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1ValidatingAdmissionPolicyBindingExtensions
{
    public static ICollection<ValidatingAdmissionPolicyBindingViewModel> ToViewModel(this V1ValidatingAdmissionPolicyBindingList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static ValidatingAdmissionPolicyBindingViewModel ToViewModel(this V1ValidatingAdmissionPolicyBinding item)
    {
        return new ValidatingAdmissionPolicyBindingViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ValidatingAdmissionPolicyBindingViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}