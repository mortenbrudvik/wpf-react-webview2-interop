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
    private async Task AddUser()
    {
        var user = UserGenerator.Create();
        
        await _userService.AddUser(user);
    }   
    [RelayCommand]
    private async Task RemoveUser()
    {
        var users = _userService.GetUsers();
        if(users.Count == 0) return;
        
        await _userService.RemoveUser(users[0].Id);
    }
}