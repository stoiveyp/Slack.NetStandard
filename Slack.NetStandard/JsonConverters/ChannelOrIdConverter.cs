using System;
using Newtonsoft.Json;
using Slack.NetStandard.Objects;

namespace Slack.NetStandard.JsonConverters;

public class ChannelOrIdConverter:JsonConverter<Channel>
{
    public override bool CanWrite => true;
    public override bool CanRead => false;

    public override void WriteJson(JsonWriter writer, Channel value, JsonSerializer serializer)
    {
        if (value.FromString.HasValue && value.FromString.Value)
        {
            writer.WriteValue(value.ID);
        }
        else
        {
            serializer.Serialize(writer,value);
        }
    }

    public override Channel ReadJson(JsonReader reader, Type objectType, Channel existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        return null;
    }
}