using System.Text.Json;
using Common;
using MediatR;

namespace WebView.Interop;

// Bridge class to handle API calls from web client.
public class ApiBridge(IMediator mediator, ApiRegistry apiRegistry)
{
    public async Task<string> InvokeMethod(string serviceName, string methodName, string jsonParams)
    {
        var requestType = apiRegistry.GetRequestType(serviceName, methodName);
        if (requestType == null) throw new Exception($"Unknown API: {serviceName}.{methodName}");
        
        var request = JsonSerializer.Deserialize(jsonParams, requestType);
        
        if (request == null) throw new Exception($"Invalid API params: {jsonParams}");
        
        var result = await mediator.Send(request);

        return JsonUtils.Serialize(result);
    }
}
