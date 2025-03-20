using System.Windows;
using Autofac;
using WebView.Interop;
using WpfReactApp.UI.Common;
using WpfReactApp.UI.Users;

namespace WpfReactApp.UI;

public partial class App : Application
{
    private IContainer _container;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        _container = AutofacBootstrapper.Bootstrap();

        var userService = _container.Resolve<UserService>();
        userService.AddUser(UserGenerator.Create());
        userService.AddUser(UserGenerator.Create());

        // Register API
        var registry = _container.Resolve<ApiRegistry>();
        registry.Register<GetUsersRequest>("userService", "getUsers");
        
        // Create and show main window
        var scope = _container.BeginLifetimeScope();
        var mainWindow = scope.Resolve<MainWindow>();
        mainWindow.Show();
    }
    
    protected override void OnExit(ExitEventArgs e)
    {
        _container?.Dispose();
        base.OnExit(e);
    }
}

