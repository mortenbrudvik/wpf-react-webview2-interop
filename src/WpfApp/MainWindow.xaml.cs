using MediatR;
using WebView;
using Path = System.IO.Path;

namespace WpfApp;

public partial class MainWindow
{
    private readonly WebviewHandler _handler;
    private readonly WebViewApiBridge _apiBridge;

    public MainWindow()
    {
        InitializeComponent();
        
       // _apiBridge = new WebViewApiBridge(mediator);
        
        var tempPath =  Path.Combine(Path.GetTempPath(), "WpfWebview2Interop");
        _handler = new WebviewHandler(WebBrowser,  "http://localhost:5174/", tempPath);
    }
}