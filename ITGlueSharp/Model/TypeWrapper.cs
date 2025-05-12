using System.Text.Json.Serialization;

namespace Xilophor.ITGlueSharp.Model;

internal class TypeWrapper<T>
{
    [JsonPropertyName("type")]
    public string Type { get; set; }
    [JsonPropertyName("attributes")]
    public T Attributes { get; set; }
}