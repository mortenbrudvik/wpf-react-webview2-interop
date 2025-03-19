namespace WebView;

public static class ApiRegistry
{
    private static readonly Dictionary<string, Type> _requests = new();

    public static void Register<TRequest>(string serviceName, string methodName)
    {
        _requests[$"{serviceName}.{methodName}"] = typeof(TRequest);
    }

    public static Type GetRequestType(string serviceName, string methodName)
    {
        return _requests.GetValueOrDefault($"{serviceName}.{methodName}");
    }
}