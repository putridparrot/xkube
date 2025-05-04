using System.ComponentModel;

namespace XKube.ViewModels;

public class FlowSchemaViewModel
{
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Priority Level")]
    public string PriorityLevel { get; set; } = string.Empty;
    [DisplayName("Matching Precedence")]
    public string MatchingPrecedence { get; set; } = string.Empty;
    [DisplayName("Distinguisher Method")]
    public string DistinguisherMethod { get; set; } = string.Empty;
}