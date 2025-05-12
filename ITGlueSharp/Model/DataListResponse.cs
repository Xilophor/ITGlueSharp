using System.Text.Json.Serialization;

namespace Xilophor.ITGlueSharp.Model;

public class DataListResponse<T>
{
    [JsonPropertyName("data")]
    public T[] Data { get; set; }
}