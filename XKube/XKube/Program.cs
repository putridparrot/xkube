using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
using XKube.CommandRegister;
using XKube.Commands;
using XKube.Injection;
using XKube.Services;

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<IKubernetesClientService>(_ =>
{
    var client = new KubernetesClientService();
    client.LoadKubeConfig();
    client.LoadConfig(null, null);
    return client;
});

var typeRegistrar = new TypeRegistrar(serviceCollection);
var app = new CommandApp(typeRegistrar);
app.Configure(config =>
{
    config.SetApplicationName("xkube");
    config.UseAssemblyInformationalVersion();
    config.RegisterGetCommands();
    config.RegisterLogCommands();
    config.RegisterQueryCommands();
});

app.Run(args);