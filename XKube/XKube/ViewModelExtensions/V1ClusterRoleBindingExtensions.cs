using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1ClusterRoleBindingExtensions
{
    public static ICollection<ClusterRoleBindingViewModel> ToViewModel(this V1ClusterRoleBindingList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static ClusterRoleBindingViewModel ToViewModel(this V1ClusterRoleBinding item)
    {
        return new ClusterRoleBindingViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            Role = $"{item.RoleRef.Kind}/{item.RoleRef.Name}" ?? string.Empty,
            Users = GetUsers(item) ?? string.Empty,
            Groups = GetGroups(item) ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<ClusterRoleBindingViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.Role,
            item.Users,
            item.Groups
        ]);
    }
    private static string? GetGroups(V1ClusterRoleBinding item) => item.Subjects?.Where(s => s.Kind == "Group").Select(g => g.Name).CsvJoin();
    private static string? GetUsers(V1ClusterRoleBinding item) => item.Subjects?.Where(s => s.Kind == "User").Select(g => g.Name).CsvJoin();
}