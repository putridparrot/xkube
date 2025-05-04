using System.ComponentModel;

namespace XKube.ViewModels;

public class EventViewModel
{
    [DisplayName("Type")]
    public string Type { get; set; } = string.Empty;
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Message")]
    public string Message { get; set; } = string.Empty;
    [DisplayName("Object Name")]
    public string ObjectName { get; set; } = string.Empty;
    [DisplayName("Last Timestamp")]
    public string LastTimestamp { get; set; } = string.Empty;
}