namespace WpfReactApp.UI.WebApi;

public static class ApiRegistry
{
    private static readonly Dictionary<string, Type> Requests = new();

    public static void Register<TRequest>(string serviceName, string methodName)
    {
        Requests[$"{serviceName}.{methodName}"] = typeof(TRequest);
    }

    public static Type GetRequestType(string serviceName, string methodName)
    {
        return Requests.GetValueOrDefault($"{serviceName}.{methodName}");
    }
}