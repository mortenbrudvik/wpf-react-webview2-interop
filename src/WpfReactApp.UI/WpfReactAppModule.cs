using Autofac;
using WebView;
using WpfReactApp.UI.Users;
using WpfReactApp.UI.WebApi;

namespace WpfReactApp.UI;

public class WpfReactAppModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // WebView
        builder.RegisterType<WebViewControl>()
            .AsSelf()
            .As<IWebViewInterop>()
            .SingleInstance();

        // WebView Bridge
        builder.RegisterType<WebViewApiBridge>().SingleInstance();
        builder.RegisterType<WebViewEventAggregator>().SingleInstance();
        
        // Services
        builder.RegisterType<UserService>().AsSelf().SingleInstance();
        
        // ViewModels
        builder.RegisterType<MainViewModel>().SingleInstance();
        
        // Views
        builder.RegisterType<MainWindow>().SingleInstance();
    }
}