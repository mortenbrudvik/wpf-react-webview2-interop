using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopApp.Common;
using DesktopApp.Users;
using WebView;
using WebView.Interop;

namespace DesktopApp;

public partial class MainViewModel : ObservableObject
{
    private readonly UserService _userService;
    private readonly WebviewHandler _handler;

    public MainViewModel(WebViewControl webview, ApiBridge bridge, UserService userService)
    {
        _userService = userService;
        WebView = webview;
 
        
        #if DEBUG
                var url = "http://localhost:5223/";
        #else
                var url = "https://webapp/index.html";
        #endif
        
        
        var hostWebHostNameForFolder = "webapp";
        var hostWebRootFolder = Path.Combine(Environment.CurrentDirectory, "Assets");
        
        var tempPath =  Path.Combine(Path.GetTempPath(), "WpfWebview2Interop");
        _handler = new WebviewHandler(WebView,  url, tempPath)
        {
            HostObject = bridge,
            HostObjectName = "apibridge",
            EnableDevTools = true,
            
            HostWebRootFolder = hostWebRootFolder,
            HostWebHostNameForFolder = hostWebHostNameForFolder
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