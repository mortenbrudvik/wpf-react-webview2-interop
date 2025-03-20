using Autofac;
using WebView;
using WpfReactApp.UI.Users;
using WpfReactApp.UI.WebApi;

namespace WpfReactApp.UI;

public class WpfAppModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // WebView
        builder.RegisterType<WebViewControl>()
            .AsSelf()
            .As<IWebViewInterop>()
            .InstancePerDependency();

        // WebView Bridge
        builder.RegisterType<WebViewApiBridge>().SingleInstance();
        builder.RegisterType<EventAggregator>().SingleInstance();

        
        // Services
        builder.RegisterType<UserService>().AsSelf();
        
        // Views
        builder.RegisterType<MainWindow>().SingleInstance();
    }
}