using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Xilophor.ITGlueSharp.Converters;

internal class StringObjectDictionaryJsonConverter : JsonConverter<Dictionary<string, object?>>
{
    public override Dictionary<string, object?> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Dictionary<string, object?> value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        foreach (var keyPair in value.Where(keyPair => 
                     options.DefaultIgnoreCondition != JsonIgnoreCondition.WhenWritingNull || keyPair.Value != null))
        {
            writer.WritePropertyName(keyPair.Key);
            writer.WriteRawValue(JsonSerializer.Serialize(keyPair.Value, options));
        }
        writer.WriteEndObject();
    }
}