using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using WebView;
using WpfReactApp.UI.WebApi;

namespace WpfReactApp.UI;

public partial class MainViewModel : ObservableObject
{
    private readonly WebviewHandler _handler;

    public MainViewModel(WebViewControl webview, WebViewApiBridge bridge)
    {
        WebView = webview;
        
        
        var tempPath =  Path.Combine(Path.GetTempPath(), "WpfWebview2Interop");
        _handler = new WebviewHandler(WebView,  "http://localhost:5174/", tempPath)
        {
            HostObject = bridge,
            HostObjectName = "apibridge"
        };
    }

    public WebViewControl WebView { get; set; }
}