using System.Text.Json;
using WebView;

namespace AppUI.WebApi;

public class EventAggregator
{
    private readonly IWebViewInterop _webViewInterop;

    public EventAggregator(IWebViewInterop webViewInterop) => _webViewInterop = webViewInterop;

    public void Publish(string eventName, object data)
    {
        var message = new { EventName = eventName, Data = data };
        _webViewInterop.PostWebMessageAsJson(JsonSerializer.Serialize(message));
    }
}