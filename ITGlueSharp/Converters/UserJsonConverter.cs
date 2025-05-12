using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xilophor.ITGlueSharp.Model;

namespace Xilophor.ITGlueSharp.Converters;

public class UserJsonConverter : JsonConverter<User>
{
    public override User Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }
        
        var user = new User();
        
        var startDepth = reader.CurrentDepth;

        while (reader.Read() && reader.CurrentDepth > startDepth)
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                switch (reader.GetString())
                {
                    case "id":
                        reader.Read();
                        user.Id = long.Parse(reader.GetString() ?? "0");
                        break;
                    case "first-name":
                        reader.Read();
                        user.FirstName = reader.GetString();
                        break;
                    case "last-name":
                        reader.Read();
                        user.LastName = reader.GetString();
                        break;
                    case "role-name":
                        reader.Read();
                        user.RoleName = reader.GetString();
                        break;
                    case "email": 
                        reader.Read();
                        user.Email = reader.GetString();
                        break;
                    case "avatar":
                        reader.Read();
                        if (reader.TokenType == JsonTokenType.StartArray)
                        {
                            var avatar = new Avatar();
                            reader.Read();
                            avatar.Content = reader.GetString();
                            reader.Read();
                            avatar.FileName = reader.GetString();
                            user.Avatar = avatar;
                            reader.Read();
                        }
                        break;
                    case "invitation-sent-at":
                        reader.Read();
                        user.InvitationSentAt = reader.TokenType != JsonTokenType.Null ? reader.GetDateTime() : null;
                        break;
                    case "invitation-accepted-at":
                        reader.Read();
                        user.InvitationAcceptedAt = reader.TokenType != JsonTokenType.Null ? reader.GetDateTime() : null;
                        break;
                    case "current-sign-in-at":
                        reader.Read();
                        user.CurrentSignInAt = reader.TokenType != JsonTokenType.Null ? reader.GetDateTime() : null;
                        break;
                    case "current-sign-in-ip":
                        reader.Read();
                        user.CurrentSignInIp = reader.TokenType != JsonTokenType.Null ? IPAddress.Parse(reader.GetString()!) : null;
                        break;
                    case "last-sign-in-at":
                        reader.Read();
                        user.LastSignInAt = reader.TokenType != JsonTokenType.Null ? reader.GetDateTime() : null;
                        break;
                    case "last-sign-in-ip":
                        reader.Read();
                        user.LastSignInIp = reader.TokenType != JsonTokenType.Null ? IPAddress.Parse(reader.GetString()!) : null;
                        break;
                    case "my-glue":
                        reader.Read();
                        user.MyGlue = reader.GetBoolean();
                        break;
                    case "my-glue-account-id":
                        reader.Read();
                        user.MyGlueAccountId = reader.TokenType != JsonTokenType.Null ? reader.GetInt64() : null;
                        break;
                }
            }
        }

        return user;
    }

    public override void Write(Utf8JsonWriter writer,
        User value,
        JsonSerializerOptions options)
        => throw new NotImplementedException();
}

public class UpdateUserJsonConverter : UserJsonConverter
{
    public override void Write(Utf8JsonWriter writer,
        User value,
        JsonSerializerOptions options)
    {
        writer.WriteStartObject("data");
        
        writer.WriteString("type", "users");
        writer.WriteStartObject("attributes");
        
        writer.WriteNumber("id", value.Id);
        writer.WriteString("first-name", value.FirstName);
        writer.WriteString("last-name", value.LastName);
        if (value.Avatar != null)
        {
            writer.WriteStartObject("avatar");
            
            writer.WriteString("content", value.Avatar.Content);
            writer.WriteString("file_name", value.Avatar.FileName);
            
            writer.WriteEndObject();
        }
        
        writer.WriteEndObject();
        writer.WriteEndObject();
    }
}