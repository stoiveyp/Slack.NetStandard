using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Slack.NetStandard.WebApi;
using Slack.NetStandard.WebApi.Admin;

namespace Slack.NetStandard.JsonConverters
{
    public class EmojiConverter:JsonConverter<EmojiInformation>
    {
        public override void WriteJson(JsonWriter writer, EmojiInformation value, JsonSerializer serializer)
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

        public override EmojiInformation ReadJson(JsonReader reader, Type objectType, EmojiInformation existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                return new EmojiInformation {Value = reader.Value.ToString()};
            }

            if (reader.TokenType == JsonToken.StartObject)
            {
                return new EmojiInformation{Values = serializer.Deserialize<Dictionary<string, string>>(reader)};
            }

            return null;
        }
    }
}
