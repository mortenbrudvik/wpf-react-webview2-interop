using System.Text.Json;

namespace WpfApp;

public class EventAggregator
{
    private readonly IWebView _webView;

    public EventAggregator(IWebView webView) => _webView = webView;

    public void Publish(string eventName, object data)
    {
        var message = new { EventName = eventName, Data = data };
        _webView.PostWebMessageAsJson(JsonSerializer.Serialize(message));
    }
}

public interface IWebView
{
    void PostWebMessageAsJson(string message);
}