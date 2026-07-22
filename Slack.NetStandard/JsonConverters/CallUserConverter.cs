using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.Apps;
using Slack.NetStandard.WebApi.Calls;

namespace Slack.NetStandard.JsonConverters;

public class CallUserConverter : JsonConverter<CallUser>
{
    public override bool CanWrite => false;

    public override void WriteJson(JsonWriter writer, CallUser value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override CallUser ReadJson(JsonReader reader, Type objectType, CallUser existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        var jObject = JObject.Load(reader);

        if (!string.IsNullOrWhiteSpace(jObject.Value<string>("slack_id")))
        {
            var target = new SlackCallUser();
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }
        else
        {
            var target = new ExternalCallUser();
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }
    }
}