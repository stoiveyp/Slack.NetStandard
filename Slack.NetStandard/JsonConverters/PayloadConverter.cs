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
            var isMessage = jObject.ContainsKey("message");

            object target = isMessage ? (object)new MessagePayload() : new ViewPayload();
            
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(PayloadAction);
        }
    }
}
