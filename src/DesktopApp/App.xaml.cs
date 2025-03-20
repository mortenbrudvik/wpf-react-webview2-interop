using System.Windows;
using Autofac;
using DesktopApp.Common;
using DesktopApp.Users;
using WebView.Interop;

namespace DesktopApp;

public partial class App
{
    private IContainer? _container;

    protected async override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        _container = AutofacBootstrapper.Bootstrap();

        var userService = _container.Resolve<UserService>();
        await userService.AddUser(UserGenerator.Create());
        await userService.AddUser(UserGenerator.Create());

        // Register API
        var registry = _container.Resolve<ApiRegistry>();
        registry.Register<GetUsersRequest>("userService", "getUsers");
        registry.Register<GetUserRequest>("userService", "getUser");
        
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

