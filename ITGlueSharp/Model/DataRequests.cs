using System.Text.Json.Serialization;

namespace Xilophor.ITGlueSharp.Model;

internal class DataArrayRequest<T>
{
    [JsonPropertyName("data")]
    public T[] Data { get; set; }
}

internal class DataObjectRequest<T>(string type, T data)
{
    [JsonPropertyName("data")]
    public TypeWrapper<T> Data { get; set; } = new() { Type = type, Attributes = data };
}