using Microsoft.Web.WebView2.Wpf;

namespace WebView;

public class WebViewControl : WebView2, IWebViewInterop
{
    public void PostWebMessageAsJson(string message)
    {
        CoreWebView2.PostWebMessageAsJson(message);
    }
}