using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Messages.Elements.RichText;

namespace Slack.NetStandard.JsonConverters
{
    public class RichTextElementConverter : JsonConverter<RichTextElement>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, RichTextElement value, JsonSerializer serializer)
        {

        }

        public override RichTextElement ReadJson(JsonReader reader, Type objectType, RichTextElement existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var componentType = jObject.Value<string>("type");
            var target = GetComponent(componentType);
            if (target == null)
            {
                throw new ArgumentOutOfRangeException($"MessageElement type {componentType} not supported");
            }
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public static Dictionary<string, Type> IMessageElementLookup = new Dictionary<string, Type>
        {
            {TextElement.ElementName, typeof(TextElement)},
            {Emoji.ElementName, typeof(Emoji)},
            {ChannelElement.ElementName, typeof(ChannelElement)},
            {UserElement.ElementName, typeof(UserElement)},
            {Link.ElementName, typeof(Link)},
            {TeamElement.ElementName, typeof(TeamElement)},
            {UsergroupElement.ElementName, typeof(UsergroupElement)},
            {DateElement.ElementName, typeof(DateElement)},
            {Broadcast.ElementName, typeof(Broadcast)},
            {ColorElement.ElementName, typeof(ColorElement)},
            {WorkflowTokenElement.ElementName, typeof(WorkflowTokenElement)}
        };

        private RichTextElement GetComponent(string type)
        {
            return (RichTextElement)(
                IMessageElementLookup.ContainsKey(type)
                    ? Activator.CreateInstance(IMessageElementLookup[type])
                    : new UnknownRichTextElement());
        }
    }
}