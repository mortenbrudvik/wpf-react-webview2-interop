using System.Text.Json;
using MediatR;
using WebView;

namespace WpfApp;

// Bridge class to handle API calls from web client.
public class WebViewApiBridge(IMediator mediator)
{
    public async Task<string> InvokeMethod(string serviceName, string methodName, string jsonParams)
    {
        var requestType = ApiRegistry.GetRequestType(serviceName, methodName);
        if (requestType == null) throw new Exception($"Unknown API: {serviceName}.{methodName}");
        
        var request = JsonSerializer.Deserialize(jsonParams, requestType);
        
        if (request == null) throw new Exception($"Invalid API params: {jsonParams}");
        
        var result = await mediator.Send(request);

        return ConvertToCamelCaseJson(result);
    }

    private string ConvertToCamelCaseJson(object? dataObj)
    {
        JsonSerializerOptions options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Ensures camelCase for property names
            PropertyNameCaseInsensitive = true // Optional: allows case-insensitive deserialization
        };
        return JsonSerializer.Serialize(dataObj, options);
    }
}
