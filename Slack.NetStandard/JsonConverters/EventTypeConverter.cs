using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.EventsApi;

namespace Slack.NetStandard.JsonConverters
{
    public class EventTypeConverter : JsonConverter<EventType>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, EventType value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override EventType ReadJson(JsonReader reader, Type objectType, EventType existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (objectType != typeof(EventType))
            {
                var known = Activator.CreateInstance(objectType);
                serializer.Populate(reader, known);
                return known as EventType;
            }
            var jObject = JObject.Load(reader);

            var target = GetEventType(jObject.Value<string>("type"));

            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        private EventType GetEventType(string type)
        {
            return type switch
            {
                AppHomeOpened.EventType => new AppHomeOpened(),
                _ => new EventType()
            };
        }
    }
}
