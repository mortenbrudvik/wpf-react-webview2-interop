using CommunityToolkit.Mvvm.ComponentModel;
using WebView;

namespace WpfReactApp.UI;

public partial class MainViewModel(WebViewControl webview) : ObservableObject
{
    public WebViewControl WebView { get; set; } = webview;
}