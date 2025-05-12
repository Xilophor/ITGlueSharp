using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xilophor.ITGlueSharp.Model;

namespace Xilophor.ITGlueSharp.Converters;

internal class FilterJsonConverter : JsonConverter<Filter>
{
    public override Filter Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Filter value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        foreach (var keyPair in value.Values.Where(keyPair => 
                     options.DefaultIgnoreCondition != JsonIgnoreCondition.WhenWritingNull || keyPair.Value != null))
        {
            writer.WritePropertyName(keyPair.Key);
            writer.WriteRawValue(JsonSerializer.Serialize(keyPair.Value, options));
        }
        writer.WriteEndObject();
    }
}