using System.Text.Json;
using System.Text.Json.Serialization;
using NatsStreaming.Interfaces;

namespace NatsStreaming.Services
{
    public class CustomSerializer : ICustomSerializer
    {
        public string Serialize<T>(T data) where T : class
        {
            return JsonSerializer.Serialize(
                data,
                new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    AllowTrailingCommas = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    Converters = { new JsonStringEnumConverter() }
                });
        }

        public T Deserialize<T>(string data) where T : class
        {
            return JsonSerializer.Deserialize<T>(
                data,
                new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    AllowTrailingCommas = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    Converters = { new JsonStringEnumConverter() }
                });
        }
    }
}
