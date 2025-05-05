using Spectre.Console.Cli;
using System.ComponentModel;

namespace XKube.Commands.Shared;
public class NamespaceCommandSettings : OutputCommandSettings
{
    [CommandOption("-n|--namespace")]
    [Description("Filter Pods by namespace")]
    public string? Namespace { get; set; }
    [CommandOption("-a|--all-namespaces")]
    [Description("Show across all namespaces")]
    public bool AllNamespaces { get; set; } = false;
}