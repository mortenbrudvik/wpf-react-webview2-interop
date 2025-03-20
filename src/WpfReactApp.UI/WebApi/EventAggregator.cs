// WpfReactApp.UI.WebApi/EventAggregator.cs
using System.Text.Json;
using System.Text.Json.Serialization;
using Common;
using WebView;

namespace WpfReactApp.UI.WebApi;

public class EventAggregator
{
    private readonly IWebViewInterop _webViewInterop;

    public EventAggregator(IWebViewInterop webViewInterop)
    {
        _webViewInterop = webViewInterop;
    }

    public void Publish(string eventName, object data)
    {
        var message = new { EventName = eventName, Data = data };
        var json = JsonUtils.Serialize(message);
        _webViewInterop.PostWebMessageAsJson(json);
    }
}