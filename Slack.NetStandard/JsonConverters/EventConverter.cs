using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.EventsApi;

namespace Slack.NetStandard.JsonConverters
{
    public class EventConverter:JsonConverter<Event>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, Event value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override Event ReadJson(JsonReader reader, Type objectType, Event existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (objectType != typeof(Event))
            {
                var known = Activator.CreateInstance(objectType);
                serializer.Populate(reader,known);
                return (Event)known;
            }

            var jObject = JObject.Load(reader);

            var target = GetEventType(jObject.Value<string>("type"));

            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        private Event GetEventType(string type)
        {
            return type switch
            {
                UrlVerification.EventType => new UrlVerification(),
                EventCallback.EventType => new EventCallback(),
                _ => new Event()
            };
        }
    }
}
