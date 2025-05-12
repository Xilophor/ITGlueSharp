using System.Text.Json.Serialization;

namespace Xilophor.ITGlueSharp.Model;

internal struct DataArrayResponse<T>
{
    [JsonPropertyName("data")]
    public T[] Data { get; set; }
}

internal struct DataObjectResponse<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }
}