using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.JsonConverters
{
    public class ViewStateConverter:JsonConverter<Dictionary<string, Dictionary<string, ElementValue>>>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, Dictionary<string, Dictionary<string, ElementValue>> value, JsonSerializer serializer)
        {
            
        }

        public override Dictionary<string, Dictionary<string, ElementValue>> ReadJson(JsonReader reader, Type objectType, Dictionary<string, Dictionary<string, ElementValue>> existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                reader.Read();
                reader.Read();
                return null;
            }

            return serializer.Deserialize<Dictionary<string, Dictionary<string, ElementValue>>>(reader);
        }
    }
}
