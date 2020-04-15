using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Interaction;

namespace Slack.NetStandard.JsonConverters
{
    public class InteractionContainerConverter : JsonConverter<Container>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, Container value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override Container ReadJson(JsonReader reader, Type objectType, Container existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var target = GetContainerType(jObject.Value<string>("type"));
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        private Container GetContainerType(string value)
        {
            return value switch
            {
                "message" => new MessageContainer(),
                "view" => new ViewContainer(),
                _ => new Container()
            };
        }
    }
}