using System.Reflection;
using CodeGenerator;
using HandlebarsDotNet;
using YamlDotNet.Serialization;

var root = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

var deserializer = new DeserializerBuilder()
    .Build();

Handlebars.RegisterHelper("MethodName", (_, arguments) =>
    arguments[0] is string title ? Functions.Normalize(title) : "<missing>");
Handlebars.RegisterHelper("PropertyName", (_, arguments) =>
    arguments[0] is string title ? Functions.PropertyName(title) : "<missing>");

var operations = deserializer.Deserialize<Application>(File.OpenText(Path.Combine(root, "configuration.yaml")));

if (operations.Definitions is null)
{
    Console.WriteLine("No Definitions found");
    return;
}

var outputFolder = Path.Combine(root, ".Generated");

if (Directory.Exists(outputFolder))
{
    Directory.Delete(outputFolder, true);
}

var viewModelTemplate = Handlebars.Compile(File.ReadAllText(Path.Combine(root, "viewmodel.template")));

var viewModelsFolder = Path.Combine(outputFolder, "viewmodels");

Directory.CreateDirectory(viewModelsFolder);

foreach (var definition in operations.Definitions)
{
    var code = viewModelTemplate(definition);

    File.WriteAllText($"{Path.Combine(viewModelsFolder, definition.Title.Replace(" ", ""))}.razor", code);
}
