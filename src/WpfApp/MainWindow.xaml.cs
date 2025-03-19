using WebView;
using Path = System.IO.Path;

namespace WpfApp;

public partial class MainWindow
{
    private readonly WebviewHandler _handler;

    public MainWindow()
    {
        InitializeComponent();
        
        var tempPath =  Path.Combine(Path.GetTempPath(), "WpfWebview2Interop");
        _handler = new WebviewHandler(WebBrowser,  "http://localhost:5174/", tempPath);
    }
}