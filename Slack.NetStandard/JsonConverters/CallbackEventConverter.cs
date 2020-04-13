using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            if (objectType != typeof(CallbackEvent) && objectType != typeof(Message))
            {
                var known = Activator.CreateInstance(objectType);
                serializer.Populate(reader, known);
                return known as CallbackEvent;
            }
            var jObject = JObject.Load(reader);

            var target = GetEventType(jObject.Value<string>("type"),jObject);

            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        private CallbackEvent GetEventType(string type, JObject container)
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
                FileChange.EventType => new FileChange(),
                FileCreated.EventType => new FileCreated(),
                FileDeleted.EventType => new FileDeleted(),
                FilePublic.EventType => new FilePublic(),
                FileShared.EventType => new FileShared(),
                FileUnshared.EventType => new FileUnshared(),
                GridMigrationFinished.EventType => new GridMigrationFinished(),
                GridMigrationStarted.EventType => new GridMigrationStarted(),
                GroupArchive.EventType => new GroupArchive(),
                GroupClose.EventType => new GroupClose(),
                GroupDeleted.EventType => new GroupDeleted(),
                GroupHistoryChanged.EventType => new GroupHistoryChanged(),
                GroupLeft.EventType => new GroupLeft(),
                GroupOpen.EventType => new GroupOpen(),
                GroupRename.EventType => new GroupRename(),
                GroupUnarchive.EventType => new GroupUnarchive(),
                ImClose.EventType => new ImClose(),
                ImCreated.EventType => new ImCreated(),
                ImHistoryChanged.EventType => new ImHistoryChanged(),
                ImOpen.EventType => new ImOpen(),
                InviteRequested.EventType => new InviteRequested(),
                LinkShared.EventType => new LinkShared(),
                MemberJoinedChannel.EventType => new MemberJoinedChannel(),
                MemberLeftChannel.EventType => new MemberLeftChannel(),
                Message.EventType => MessageSubtype(container.Value<string>("subtype")),
                _ => new CallbackEvent()
            };
        }

        private Message MessageSubtype(string subType)
        {
            return subType switch
            {
                ThreadBroadcast.MessageSubType => new ThreadBroadcast(),
                MessageReplied.MessageSubType => new MessageReplied(),
                MessageDeleted.MessageSubType => new MessageDeleted(),
                MessageChanged.MessageSubType => new MessageChanged(),
                MeMessage.MessageSubType => new MeMessage(),
                EkmAccessDenied.MessageSubType => new EkmAccessDenied(),
                BotMessage.MessageSubType => new BotMessage(),
                _ => new Message()
            };
        }
    }
}
