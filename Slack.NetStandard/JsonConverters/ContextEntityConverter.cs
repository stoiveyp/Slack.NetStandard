using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Slack.NetStandard.JsonConverters
{
    using Slack.NetStandard.EventsApi.CallbackEvents;

    public class ContextEntityConverter : JsonConverter<ContextEntity>
    {
        private static readonly Dictionary<string, Type> TypeMap = new Dictionary<string, Type>
        {
            { "slack#/types/channel_id", typeof(ChannelIdEntity) },
            { "slack#/types/canvas_id", typeof(CanvasIdEntity) },
            { "slack#/types/list_id", typeof(ListIdEntity) },
            { "slack#/types/message_context", typeof(MessageContextEntity) }
        };

        public override bool CanWrite => false;

        public override ContextEntity ReadJson(JsonReader reader, Type objectType, ContextEntity existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;

            var jo = JObject.Load(reader);

            var type = jo.Value<string>("type");

            if (type == null || !TypeMap.TryGetValue(type, out var targetType))
            {
                targetType = typeof(UnknownContextEntity);
            }

            var obj = (ContextEntity)Activator.CreateInstance(targetType);
            serializer.Populate(jo.CreateReader(), obj);
            return obj;
        }

        public override void WriteJson(JsonWriter writer, ContextEntity value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
