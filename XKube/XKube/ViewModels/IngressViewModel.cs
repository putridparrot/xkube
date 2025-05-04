using System.ComponentModel;

namespace XKube.ViewModels;

public class IngressViewModel
{
    [DisplayName("NAME")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("CREATION TIMESTAMP")]
    public DateTime? CreationTimestamp { get; set; } = null;
}