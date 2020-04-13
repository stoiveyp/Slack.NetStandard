﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.EventsApi;
using Slack.NetStandard.EventsApi.CallbackEvents;

namespace Slack.NetStandard.JsonConverters
{
    public class CallbackEventConverter : JsonConverter<CallbackEvent>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, CallbackEvent value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override CallbackEvent ReadJson(JsonReader reader, Type objectType, CallbackEvent existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (objectType != typeof(CallbackEvent))
            {
                var known = Activator.CreateInstance(objectType);
                serializer.Populate(reader, known);
                return known as CallbackEvent;
            }
            var jObject = JObject.Load(reader);

            var target = GetEventType(jObject.Value<string>("type"));

            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        private CallbackEvent GetEventType(string type)
        {
            return type switch
            {
                AppHomeOpened.EventType => new AppHomeOpened(),
                AppMention.EventType => new AppMention(),
                AppRequested.EventType => new AppRequested(),
                AppUninstalled.EventType => new AppUninstalled(),
                _ => new CallbackEvent()
            };
        }
    }
}
