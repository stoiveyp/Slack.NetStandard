using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.WebApi.Stars;

namespace Slack.NetStandard.JsonConverters
{
    public class StarredItemConverter:JsonConverter<StarredItem>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, StarredItem value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override StarredItem ReadJson(JsonReader reader, Type objectType, StarredItem existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (objectType != typeof(StarredItem))
            {
                var known = Activator.CreateInstance(objectType);
                serializer.Populate(reader, known);
                return known as StarredItem;
            }
            var jObject = JObject.Load(reader);

            var target = GetItemType(jObject.Value<string>("type"));

            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        private StarredItem GetItemType(string value)
        {
            return value switch
            {
                MessageItem.ItemType => new MessageItem(),
                FileItem.ItemType => new FileItem(),
                ChannelItem.ItemType => new ChannelItem(),
                _ => new StarredItem()
            };
        }
    }
}
