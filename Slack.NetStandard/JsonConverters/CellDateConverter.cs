using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Slack.NetStandard.JsonConverters
{
    internal class CellDateConverter : JsonConverter<List<DateTime>>
    {
        public override bool CanRead =>  false;

        public override List<DateTime> ReadJson(JsonReader reader, Type objectType, List<DateTime> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, List<DateTime> value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            foreach(var dt in value)
            {
                writer.WriteValue(dt.ToString("yyyy-MM-dd"));
            }
            writer.WriteEndArray();
        }
    }
}
