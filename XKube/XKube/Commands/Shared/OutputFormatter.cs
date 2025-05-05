using Spectre.Console;

namespace XKube.Commands.Shared;

public static class OutputFormatter
{
    public static void Write<T>(this ICollection<T> list, OutputFormat outputFormat, Func<ICollection<T>, Grid> gridWriter)
    {
        switch (outputFormat)
        {
            case OutputFormat.Json:
                Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(list));
                break;
            case OutputFormat.Yaml:
            case OutputFormat.Csv:
                AnsiConsole.MarkupLine($"[red]{outputFormat} format is not supported yet[/]");
                break;
            case OutputFormat.None:
            default:
                AnsiConsole.Write(gridWriter(list));
                break;
        }
    }
}
