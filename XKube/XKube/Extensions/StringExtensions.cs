namespace XKube.Extensions;
public static class StringExtensions
{
    public static bool HasValue(this string? str) =>
        !string.IsNullOrWhiteSpace(str);
}
