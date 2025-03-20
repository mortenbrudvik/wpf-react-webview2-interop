using System.Text.Json;

namespace Common;

public static class JsonUtils
{
    /// <summary>
    /// Serializes an object to a JSON string with camelCase naming policy
    /// and case-insensitive property handling.
    /// </summary>
    /// <param name="dataObj">The object to serialize. Can be null.</param>
    /// <returns>A JSON string representation of the object.</returns>
    public static string Serialize(object? dataObj)
    {
        JsonSerializerOptions options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Ensures camelCase for property names
            PropertyNameCaseInsensitive = true // Optional: allows case-insensitive deserialization
        };
        return JsonSerializer.Serialize(dataObj, options);
    }
}