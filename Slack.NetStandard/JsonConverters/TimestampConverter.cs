using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Slack.NetStandard.JsonConverters
{
    public class TimestampConverter : JsonConverter<Timestamp>
    {
        public override void WriteJson(JsonWriter writer, Timestamp value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override Timestamp ReadJson(JsonReader reader, Type objectType, Timestamp existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            return reader.Value?.ToString();
        }
    }
}
