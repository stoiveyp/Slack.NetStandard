using System;
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
                CallRejected.EventType => new CallRejected(),
                ChannelArchive.EventType => new ChannelArchive(),
                ChannelCreated.EventType => new ChannelCreated(),
                ChannelDeleted.EventType => new ChannelDeleted(),
                ChannelHistoryChanged.EventType => new ChannelHistoryChanged(),
                ChannelLeft.EventType => new ChannelLeft(),
                ChannelRename.EventType => new ChannelRename(),
                ChannelShared.EventType => new ChannelShared(),
                ChannelUnarchive.EventType => new ChannelUnarchive(),
                ChannelUnshared.EventType => new ChannelUnshared(),
                DndUpdated.EventType => new DndUpdated(),
                DndUpdatedUser.EventType => new DndUpdatedUser(),
                EmailDomainChanged.EventType => new EmailDomainChanged(),
                EmojiChanged.EventType => new EmojiChanged(),
                _ => new CallbackEvent()
            };
        }
    }
}
