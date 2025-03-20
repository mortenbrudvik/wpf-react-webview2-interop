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

    }
}