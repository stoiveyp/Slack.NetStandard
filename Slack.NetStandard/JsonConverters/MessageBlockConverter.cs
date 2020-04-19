using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Messages.Blocks;

namespace Slack.NetStandard.JsonConverters
{
    public class MessageBlockConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var componentType = jObject.Value<string>("type");
            object target = GetComponent(componentType);
            if (target == null)
            {
                throw new ArgumentOutOfRangeException($"MessageBlock type {componentType} not supported");
            }
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public static Dictionary<string, Type> IMessageBlockLookup = new Dictionary<string, Type>
        {
            {nameof(Divider).ToLower(), typeof(Divider)},
            {nameof(Section).ToLower(), typeof(Section)},
            {nameof(Image).ToLower(),typeof(Image) },
            {nameof(Actions).ToLower(),typeof(Actions) },
            {nameof(Context).ToLower(),typeof(Context) },
            {nameof(Input).ToLower(),typeof(Input) },
            {nameof(File).ToLower(),typeof(File) }
        };

        private IMessageBlock GetComponent(string type)
        {
            return (IMessageBlock)(
                IMessageBlockLookup.ContainsKey(type)
                    ? Activator.CreateInstance(IMessageBlockLookup[type])
                    : null);
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(IMessageBlock).IsAssignableFrom(objectType);
        }
    }
}
