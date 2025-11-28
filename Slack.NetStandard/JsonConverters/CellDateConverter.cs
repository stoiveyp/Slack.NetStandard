using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Slack.NetStandard.JsonConverters
{
    internal class CellDateConverter : JsonConverter<IEnumerable<DateTime>>
    {
        public override bool CanRead =>  false;

        public override IEnumerable<DateTime> ReadJson(JsonReader reader, Type objectType, IEnumerable<DateTime> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, IEnumerable<DateTime> value, JsonSerializer serializer)
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
