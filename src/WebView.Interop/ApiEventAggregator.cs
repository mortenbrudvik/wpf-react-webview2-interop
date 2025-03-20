using Common;

namespace WebView.Interop;

public class ApiEventAggregator(IWebViewInterop webViewInterop)
{
    public void Publish(string eventName, object data)
    {
        var message = new { EventName = eventName, Data = data };
        var json = JsonUtils.Serialize(message);
        webViewInterop.PostWebMessageAsJson(json);
    }
}