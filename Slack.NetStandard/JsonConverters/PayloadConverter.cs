using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Interaction;

namespace Slack.NetStandard.JsonConverters
{
    public class PayloadConverter:JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var containerType = jObject["container"].Value<string>("type");

            object target = containerType switch
            {
                "message" => new MessagePayload(),
                "message_attachment" => new MessagePayload(),
                "view" => new ViewPayload(),
                _ => new InteractionPayload()
            };
            
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(PayloadAction);
        }
    }
}
