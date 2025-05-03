using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
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
    config.AddBranch("get", list =>
    {
        list.AddCommand<GetPodCommands>("pods");
        list.AddCommand<GetNodeCommands>("nodes");
        list.AddCommand<GetServiceCommands>("services");
        list.AddCommand<GetIngressCommands>("ingresses");
        list.AddCommand<GetApiResourcesCommands>("apiresources");
    });

    config.AddCommand<LogCommands>("log");
});

app.Run(args);