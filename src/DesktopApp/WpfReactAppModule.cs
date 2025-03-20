using Autofac;
using DesktopApp.Users;
using WebView;
using WebView.Interop;

namespace DesktopApp;

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
        builder.RegisterType<ApiBridge>().SingleInstance();
        builder.RegisterType<ApiEventAggregator>().SingleInstance();
        builder.RegisterType<ApiRegistry>().SingleInstance();
        
        // Services
        builder.RegisterType<UserService>().AsSelf().SingleInstance();
        
        // ViewModels
        builder.RegisterType<MainViewModel>().SingleInstance();
        
        // Views
        builder.RegisterType<MainWindow>().SingleInstance();
    }
}