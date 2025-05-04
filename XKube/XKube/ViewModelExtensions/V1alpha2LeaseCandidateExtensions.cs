using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1alpha2LeaseCandidateExtensions
{
    public static ICollection<LeaseCandidateViewModel> ToViewModel(this V1alpha2LeaseCandidateList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static LeaseCandidateViewModel ToViewModel(this V1alpha2LeaseCandidate item)
    {
        return new LeaseCandidateViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<LeaseCandidateViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}