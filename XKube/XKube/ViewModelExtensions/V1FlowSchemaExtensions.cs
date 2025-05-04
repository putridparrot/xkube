using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1FlowSchemaExtensions
{
    public static ICollection<FlowSchemaViewModel> ToViewModel(this V1FlowSchemaList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static FlowSchemaViewModel ToViewModel(this V1FlowSchema item)
    {
        return new FlowSchemaViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            PriorityLevel = item.Spec.PriorityLevelConfiguration.Name ?? string.Empty,
            MatchingPrecedence = item.Spec.MatchingPrecedence?.ToString() ?? string.Empty,
            DistinguisherMethod = DistinguisherMethod(item) ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<FlowSchemaViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.PriorityLevel,
            item.MatchingPrecedence,
            item.DistinguisherMethod
        ]);
    }
    private static string DistinguisherMethod(V1FlowSchema item) => item.Spec.DistinguisherMethod?.Type ?? string.Empty;
}