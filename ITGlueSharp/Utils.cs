using System.Text.Json;
using System.Text.Json.Serialization;
using Xilophor.ITGlueSharp.Converters;

namespace Xilophor.ITGlueSharp;

internal static class Utils
{
    public static JsonSerializerOptions DefaultSerializerOptions { get; } = new()
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new FilterJsonConverter(), new UserJsonConverter() },
    };
    
    public static JsonSerializerOptions WithNullDefaultSerializerOptions { get; } = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new FilterJsonConverter(), new UserJsonConverter() }
    };
}