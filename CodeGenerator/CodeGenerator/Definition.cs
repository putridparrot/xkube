using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator;

public class Application
{
    public List<Definition>? Definitions { get; set; }
}

public class Definition
{
    public string? Title { get; set; }
    public string? Model { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public string? ListMethod { get; set; }
    public string? DescribeMethod { get; set; }
    public string? PropertyName { get; set; } = "Items";
    public string? ReturnType { get; set; }
    public string? ItemType { get; set; }
    public bool? IsNamespaced { get; set; }
    public string? KubeCtlHint { get; set; }
    public List<Field>? Fields { get; set; }
    public List<string>? ExtraMethods { get; set; }
    public bool? IsWatchable { get; set; } = false;
}

public class Field
{
    public string? Title { get; set; }
    public string? Expression { get; set; }
    public bool? IsDefaultSortColumn { get; set; } = false;
    public bool? Sortable { get; set; } = true;
    public bool? IsFilterable { get; set; } = false;
    public bool? AllowAutoHideNamespace { get; set; } = false;
}