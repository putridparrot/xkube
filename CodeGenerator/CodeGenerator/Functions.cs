namespace CodeGenerator;

public static class Functions
{
    public static string Normalize(string value) =>
        value.Replace(" ", string.Empty);

    public static string FirstCharLower(string value) =>
        $"{value[0].ToString().ToLower()}{value[1..]}";

    public static string FirstCharUpper(string value) =>
        $"{value[0].ToString().ToUpper()}{value[1..]}";

    public static string PropertyName(string value)
    {
        return $"{FirstCharUpper(Normalize(value))}";
    }

    public static string VariableName(string value)
    {
        return $"_{FirstCharLower(Normalize(value))}";
    }

    public static bool HasFilter(List<Field>? fields) =>
        fields?.Any(f => f.IsFilterable == true) ?? false;
}