using Common;
using WebView;

namespace WpfReactApp.UI.WebApi;

public class EventAggregator(IWebViewInterop webViewInterop)
{
    public void Publish(string eventName, object data)
    {
        var message = new { EventName = eventName, Data = data };
        var json = JsonUtils.Serialize(message);
        webViewInterop.PostWebMessageAsJson(json);
    }
}