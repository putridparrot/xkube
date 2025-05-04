namespace XKube.QueryLanguage;

public class ParserResult
{
    public bool IsValid { get; internal set; }
    public int ErrorPosition { get; internal set; } = -1;
    public string? ErrorMessage { get; internal set; }
    public string? Result { get; internal set; }
}