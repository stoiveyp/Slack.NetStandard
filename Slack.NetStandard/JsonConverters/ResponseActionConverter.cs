using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.EventsApi;
using Slack.NetStandard.Interaction;

namespace Slack.NetStandard.JsonConverters
{
    public class ResponseActionConverter:JsonConverter<ResponseAction>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, ResponseAction value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override ResponseAction ReadJson(JsonReader reader, Type objectType, ResponseAction existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (objectType != typeof(ResponseAction))
            {
                var known = Activator.CreateInstance(objectType);
                serializer.Populate(reader, known);
                return (ResponseAction)known;
            }

            var jObject = JObject.Load(reader);

            var target = GetEventType(jObject.Value<string>("response_action"));

            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        private ResponseAction GetEventType(string type)
        {
            return type switch
            {
                "push" => new ResponseActionPush(),
                "update" => new ResponseActionUpdate(),
                "clear" => new ResponseActionClear(),
                "errors" => new ResponseActionErrors(),
                _ => (ResponseAction)null
            };
        }
    }
}
