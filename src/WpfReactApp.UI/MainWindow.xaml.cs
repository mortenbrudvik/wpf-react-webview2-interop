using WebView;
using WpfReactApp.UI.WebApi;
using Path = System.IO.Path;

namespace WpfReactApp.UI;

public partial class MainWindow
{
    private readonly WebviewHandler _handler;

    public MainWindow(WebViewApiBridge bridge)
    {
        InitializeComponent();

        var tempPath =  Path.Combine(Path.GetTempPath(), "WpfWebview2Interop");
        _handler = new WebviewHandler(WebBrowser,  "http://localhost:5174/", tempPath)
        {
            HostObject = bridge,
            HostObjectName = "apibridge"
        };
    }
}