using WebView;
using WpfReactApp.UI.WebApi;
using Path = System.IO.Path;

namespace WpfReactApp.UI;

public partial class MainWindow
{
    private readonly WebviewHandler _handler;

    public MainWindow(WebViewApiBridge bridge, MainViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();

        var tempPath =  Path.Combine(Path.GetTempPath(), "WpfWebview2Interop");
        _handler = new WebviewHandler(viewModel.WebView,  "http://localhost:5174/", tempPath)
        {
            HostObject = bridge,
            HostObjectName = "apibridge"
        };
    }
}