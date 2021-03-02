using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.NetStandard.Interaction;

namespace Slack.NetStandard.JsonConverters
{
    public class SlashCommandConverter : JsonConverter<SlashCommand>
    {
        public override void WriteJson(JsonWriter writer, SlashCommand value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.Payload);
        }

        public override SlashCommand ReadJson(JsonReader reader, Type objectType, SlashCommand existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            return new SlashCommand(serializer.Deserialize<Dictionary<string, string>>(reader));
        }
    }
}