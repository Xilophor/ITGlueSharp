using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Xilophor.ITGlueSharp.Model;

internal class Params
{
    [JsonPropertyName("filter")]
    public Dictionary<string, object?>? Filter { get; set; }
    
    [JsonPropertyName("page")]
    public Page? Page { get; set; }
}