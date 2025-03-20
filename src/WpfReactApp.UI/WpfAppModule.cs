using AppUI.Users;
using AppUI.WebApi;
using Autofac;
using WebView;

namespace AppUI;

public class WpfAppModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // Register MediatR and scan the assembly containing handlers

        // Register other dependencies
        builder.RegisterType<WebViewApiBridge>().SingleInstance();
        //   builder.RegisterType<EventAggregator>().SingleInstance();
        
        // WebView
        builder.RegisterType<WebView.WebViewControl>()
            .AsSelf()
            .As<IWebViewInterop>()
            .InstancePerDependency();
        
        // Services
        builder.RegisterType<UserService>().AsSelf();
        
        // Views
        builder.RegisterType<MainWindow>().SingleInstance();
    }
}