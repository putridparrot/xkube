using System.ComponentModel;
using Spectre.Console.Cli;

namespace XKube.Commands.Shared;

public class OutputCommandSettings : CommandSettings
{
    [CommandOption("-c|--cluster")]
    [Description("Use supplied cluster")]
    public string? Cluster { get; set; }
    [CommandOption("-o|--output")]
    [Description("Returns data in the specified format (accepts json, csv, yaml)")]
    public OutputFormat Output { get; set; }
}