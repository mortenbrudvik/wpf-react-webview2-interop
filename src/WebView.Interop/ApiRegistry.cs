namespace WebView.Interop;

public class ApiRegistry
{
    private readonly Dictionary<string, Type> Requests = new();

    public void Register<TRequest>(string serviceName, string methodName)
    {
        Requests[$"{serviceName}.{methodName}"] = typeof(TRequest);
    }

    public Type GetRequestType(string serviceName, string methodName)
    {
        return Requests.GetValueOrDefault($"{serviceName}.{methodName}");
    }
}