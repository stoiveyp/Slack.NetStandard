using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using Slack.NetStandard.Objects.Pins;

namespace Slack.NetStandard.JsonConverters
{
    public class PinnedItemConverter : JsonConverter<PinnedItem>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, PinnedItem value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override PinnedItem ReadJson(JsonReader reader, Type objectType, PinnedItem existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (objectType != typeof(PinnedItem))
            {
                var known = Activator.CreateInstance(objectType);
                serializer.Populate(reader, known);
                return known as PinnedItem;
            }
            var jObject = JObject.Load(reader);

            var target = GetItemType(jObject.Value<string>("type"));

            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        private PinnedItem GetItemType(string value)
        {
            return value switch
            {
                ItemTypes.Message => new MessagePinnedItem(),
                ItemTypes.File => new FilePinnedItem(),
                _ => new PinnedItem()
            };
        }
    }
}
