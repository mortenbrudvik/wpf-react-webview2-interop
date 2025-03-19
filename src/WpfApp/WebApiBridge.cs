// API Bridge exposed to React

using System.Text.Json;
using MediatR;
using WebView;

namespace WpfApp;

public class WebViewApiBridge
{
    private readonly IMediator _mediator;

    public WebViewApiBridge(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Generic method to handle API calls from React
    public string InvokeMethod(string serviceName, string methodName, string jsonParams)
    {
        var requestType = ApiRegistry.GetRequestType(serviceName, methodName);
        if (requestType == null) throw new Exception($"Unknown API: {serviceName}.{methodName}");
        
        var request = JsonSerializer.Deserialize(jsonParams, requestType);
        var result = _mediator.Send(request);
        return JsonSerializer.Serialize(result);
    }
}
