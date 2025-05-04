using System.Reflection;
using CodeGenerator;
using HandlebarsDotNet;
using YamlDotNet.Serialization;

var root = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

var deserializer = new DeserializerBuilder()
    .Build();

Handlebars.RegisterHelper("AsMethodName", (_, arguments) =>
    arguments[0] is string title ? Functions.Normalize(title) : "<missing>");
Handlebars.RegisterHelper("AsPropertyName", (_, arguments) =>
    arguments[0] is string title ? Functions.PropertyName(title) : "<missing>");
Handlebars.RegisterHelper("AsCommandName", (_, arguments) =>
    arguments[0] is string title ? Functions.Normalize(title)?.ToLower() : "<missing>");

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

// view models

var viewModelTemplate = Handlebars.Compile(File.ReadAllText(Path.Combine(root, "viewmodel.template")));

var viewModelsFolder = Path.Combine(outputFolder, "ViewModels");

Directory.CreateDirectory(viewModelsFolder);

foreach (var definition in operations.Definitions)
{
    var code = viewModelTemplate(definition);

    var fileName = $"{definition.Model.Replace(" ", "")}ViewModel.cs";
    File.WriteAllText($"{Path.Combine(viewModelsFolder, fileName)}", code);
}

// commands

var getCommandsTemplate = Handlebars.Compile(File.ReadAllText(Path.Combine(root, "getcommands.template")));

var getCommandsFolder = Path.Combine(outputFolder, "Commands");

Directory.CreateDirectory(getCommandsFolder);

foreach (var definition in operations.Definitions)
{
    var code = getCommandsTemplate(definition);

    var fileName = $"Get{definition.Model.Replace(" ", "")}Commands.cs";
    File.WriteAllText($"{Path.Combine(getCommandsFolder, fileName)}", code);
}

// extensions

var extensionsTemplate = Handlebars.Compile(File.ReadAllText(Path.Combine(root, "extensions.template")));

var extensionsFolder = Path.Combine(outputFolder, "ViewModelExtensions");

Directory.CreateDirectory(extensionsFolder);

foreach (var definition in operations.Definitions)
{
    var code = extensionsTemplate(definition);

    var fileName = $"{definition.ItemType.Replace(" ", "")}Extensions.cs";
    File.WriteAllText($"{Path.Combine(extensionsFolder, fileName)}", code);
}


// command registration

var commandRegistrationTemplate = Handlebars.Compile(File.ReadAllText(Path.Combine(root, "commandregistration.template")));

var commandRegistrationFolder = Path.Combine(outputFolder, "CommandRegistration");

Directory.CreateDirectory(commandRegistrationFolder);

var orderedDefinitions = operations.Definitions.OrderBy(d => d.Title).ToArray();
var commands = commandRegistrationTemplate(orderedDefinitions);
File.WriteAllText(Path.Combine(commandRegistrationFolder, "Commands.cs"), commands);


// table creation

var tablesTemplate = Handlebars.Compile(File.ReadAllText(Path.Combine(root, "querytables.template")));

var tablesFolder = Path.Combine(outputFolder, "Query");

Directory.CreateDirectory(tablesFolder);

var tableDefinitions = operations.Definitions.OrderBy(d => d.Title).ToArray();
var tables = tablesTemplate(tableDefinitions);
File.WriteAllText(Path.Combine(tablesFolder, "QueryTables.cs"), tables);