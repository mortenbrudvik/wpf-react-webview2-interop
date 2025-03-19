using MediatR;
using WebView;
using WpfApp.Users;
using Path = System.IO.Path;

namespace WpfApp;

public partial class MainWindow
{
    private readonly WebviewHandler _handler;

    public MainWindow(WebViewApiBridge bridge, WebViewApiBridge apiBridge)
    {
        InitializeComponent();

        //var test = mediator.Send(new GetUsersRequest());
        
        var tempPath =  Path.Combine(Path.GetTempPath(), "WpfWebview2Interop");
        _handler = new WebviewHandler(WebBrowser,  "http://localhost:5174/", tempPath)
        {
            HostObject = bridge,
            HostObjectName = "apiBridge"
        };
    }
}