namespace XKube.Extensions;
public static class DateTimeExtensions
{
    public static string ToAge(this DateTime? dateTime)
    {
        if (!dateTime.HasValue)
        {
            return string.Empty;
        }

        var diff = DateTime.Now.ToUniversalTime() - dateTime;
        if (diff.Value.Days >= 1)
        {
            return $"{diff.Value.Days}d";
        }

        if (diff.Value.Hours >= 1)
        {
            return diff.Value.Minutes >= 1 ? $"{diff.Value.Hours}h{diff.Value.Minutes}m" : $"{diff.Value.Hours}h";
        }

        if (diff.Value.Minutes >= 1)
        {
            return $"{diff.Value.Minutes}m";
        }

        return $"{diff.Value.Seconds}s";
    }
}