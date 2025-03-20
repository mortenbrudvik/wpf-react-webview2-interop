using System.IO;
using Bogus;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WebView;
using WpfReactApp.UI.Common;
using WpfReactApp.UI.Users;
using WpfReactApp.UI.WebApi;

namespace WpfReactApp.UI;

public partial class MainViewModel : ObservableObject
{
    private readonly UserService _userService;
    private readonly WebviewHandler _handler;

    public MainViewModel(WebViewControl webview, WebViewApiBridge bridge, UserService userService)
    {
        _userService = userService;
        WebView = webview;
        
        
        var tempPath =  Path.Combine(Path.GetTempPath(), "WpfWebview2Interop");
        _handler = new WebviewHandler(WebView,  "http://localhost:5174/", tempPath)
        {
            HostObject = bridge,
            HostObjectName = "apibridge",
            EnableDevTools = true,
        };
    }

    public WebViewControl WebView { get; set; }
    
    [RelayCommand]
    private void AddUser()
    {
        var user = UserGenerator.Create();
        
        _userService.AddUser(user);
    }
}