using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;

namespace WpfReactApp.UI;

public class AutofacBootstrapper
{
    public static IContainer Bootstrap()
    {
        var builder = new ContainerBuilder();

        var configuration = MediatRConfigurationBuilder
            .Create(typeof(WpfReactAppModule).Assembly)
            .WithAllOpenGenericHandlerTypesRegistered()
            .Build();

        builder.RegisterMediatR(configuration);
        builder.RegisterModule<WpfReactAppModule>();
        

        return builder.Build();
    }
}