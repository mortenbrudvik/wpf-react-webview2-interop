using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;

namespace AppUI;

public class AutofacBootstrapper
{
    public static IContainer Bootstrap()
    {
        var builder = new ContainerBuilder();

        var configuration = MediatRConfigurationBuilder
            .Create(typeof(WpfAppModule).Assembly)
            .WithAllOpenGenericHandlerTypesRegistered()
            .Build();

        builder.RegisterMediatR(configuration);
        builder.RegisterModule<WpfAppModule>();
        

        return builder.Build();
    }
}