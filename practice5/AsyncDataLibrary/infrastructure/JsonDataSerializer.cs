using System.Text.Json;
using System.Text.Json.Serialization;
using AsyncDataLibrary.Interfaces;

namespace AsyncDataLibrary.Infrastructure;

public class JsonDataSerializer : IDataSerializer
{
    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() }
    };

    public string Serialize<T>(T obj) =>
        JsonSerializer.Serialize(obj, _options);

    public T Deserialize<T>(string data) =>
        JsonSerializer.Deserialize<T>(data, _options)!;
}