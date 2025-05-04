using System.ComponentModel;
using System.Reflection;
using Spectre.Console;
using Spectre.Console.Rendering;
using XKube.ViewModels;

namespace XKube.Ui;
internal static class ConsoleExtensions
{
    public static Grid CreateGrid<T>(this ICollection<T> items, Func<T, string[]> getRowData)
    {
        var grid = new Grid();

        var displayProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.GetCustomAttribute<DisplayNameAttribute>() != null).ToArray();

        var renderColumns = new IRenderable[displayProperties.Length];
        for (var column = 0; column < displayProperties.Length; column++)
        {
            grid.AddColumn(new GridColumn().LeftAligned());

            var attribute = displayProperties[column].GetCustomAttribute<DisplayNameAttribute>();
            renderColumns[column] = new Text(attribute?.DisplayName ?? displayProperties[column].Name, new Style(Color.White)).LeftJustified();
        }

        grid.AddRow(renderColumns.ToArray());


        foreach (var item in items)
        {
            grid.AddRow(getRowData(item));
        }


        return grid;
    }
}
