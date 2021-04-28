using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Messages.Elements;

namespace Slack.NetStandard.JsonConverters
{
    public class OptionConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            var target = jObject.ContainsKey("label") ? new OptionGroup() : (IOption) new Option();

            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IOption).IsAssignableFrom(objectType);
        }
    }
}
