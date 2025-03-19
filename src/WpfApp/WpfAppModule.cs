using Autofac;
using WpfApp;
using WpfApp.Users;

public class WpfAppModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // Register MediatR and scan the assembly containing handlers

        // Register other dependencies
        builder.RegisterType<WebViewApiBridge>().SingleInstance();
        //   builder.RegisterType<EventAggregator>().SingleInstance();
        builder.RegisterType<UserService>().AsSelf();
        
        builder.RegisterType<MainWindow>().SingleInstance();
    }
}
