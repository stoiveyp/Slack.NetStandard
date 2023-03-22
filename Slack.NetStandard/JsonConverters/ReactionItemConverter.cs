using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using Slack.NetStandard.Objects.Reactions;

namespace Slack.NetStandard.JsonConverters
{
    public class ReactionItemConverter : JsonConverter<ReactionItem>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, ReactionItem value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override ReactionItem ReadJson(JsonReader reader, Type objectType, ReactionItem existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (objectType != typeof(ReactionItem))
            {
                var known = Activator.CreateInstance(objectType);
                serializer.Populate(reader, known);
                return known as ReactionItem;
            }
            var jObject = JObject.Load(reader);

            var target = GetItemType(jObject.Value<string>("type"));

            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        private ReactionItem GetItemType(string value)
        {
            return value switch
            {
                ItemTypes.Message => new MessageReactionItem(),
                ItemTypes.File => new FileReactionItem(),
                _ => new ReactionItem()
            };
        }
    }
}
