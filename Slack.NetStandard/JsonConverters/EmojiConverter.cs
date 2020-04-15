using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.JsonConverters
{
    public class EmojiConverter:JsonConverter<Emoji>
    {
        public override void WriteJson(JsonWriter writer, Emoji value, JsonSerializer serializer)
        {
            if(value == null)
            {
                writer.WriteNull();
                return;
            }

            if (!string.IsNullOrWhiteSpace(value.Value))
            {
                writer.WriteValue(value.Value);
                return;
            }

            if (value.Values?.Count > 0)
            {
                serializer.Serialize(writer,value.Values);
                return;
            }
            writer.WriteNull();
        }

        public override Emoji ReadJson(JsonReader reader, Type objectType, Emoji existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                return new Emoji {Value = reader.Value.ToString()};
            }

            if (reader.TokenType == JsonToken.StartObject)
            {
                return new Emoji{Values = serializer.Deserialize<Dictionary<string, string>>(reader)};
            }

            return null;
        }
    }
}
