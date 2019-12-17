using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Messages;
using Slack.NetStandard.Messages.Blocks;
using Slack.NetStandard.Messages.Elements;
using Image = Slack.NetStandard.Messages.Elements.Image;

namespace Slack.NetStandard.JsonConverters
{
    public class ContextElementConverter : JsonConverter
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
                throw new ArgumentOutOfRangeException($"MessageElement type {componentType} not supported");
            }
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public static Dictionary<string, Type> IMessageElementLookup = new Dictionary<string, Type>
        {
            {nameof(PlainText).ToLower(), typeof(PlainText)},
            {nameof(MarkdownText).ToLower(), typeof(MarkdownText)},
            {nameof(Image),typeof(Image) }
        };

        private IMessageElement GetComponent(string type)
        {
            return (IMessageElement)(
                IMessageElementLookup.ContainsKey(type)
                    ? Activator.CreateInstance(IMessageElementLookup[type])
                    : null);
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(IContextElement).IsAssignableFrom(objectType);
        }
    }
}