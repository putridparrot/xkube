using System.ComponentModel;
using System.Data;
using System.Reflection;
using Spectre.Console;
using Spectre.Console.Rendering;

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

    public static Grid CreateGrid(this DataTable dataTable)
    {
        var grid = new Grid();

        var columns = dataTable.Columns.Cast<DataColumn>().ToArray();

        var renderColumns = new IRenderable[columns.Length];
        for (var column = 0; column < columns.Length; column++)
        {
            grid.AddColumn(new GridColumn().LeftAligned());

            renderColumns[column] = new Text(columns[column].ColumnName, new Style(Color.White)).LeftJustified();
        }

        grid.AddRow(renderColumns.ToArray());

        foreach (var item in dataTable.AsEnumerable())
        {
            grid.AddRow(item.ItemArray.Select(Convert).ToArray());
        }

        string Convert(object value)
        {
            if(value is null)
                return string.Empty;

            return value.ToString();
        }

        return grid;
    }

}
