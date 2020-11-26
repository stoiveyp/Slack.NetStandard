using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
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
            {ToEnumString(TextType.PlainText), typeof(PlainText)},
            {ToEnumString(TextType.Markdown), typeof(MarkdownText)},
            {nameof(Image).ToLower(),typeof(Image) }
        };

        private IContextElement GetComponent(string type)
        {
            return (IContextElement)(
                IMessageElementLookup.ContainsKey(type)
                    ? Activator.CreateInstance(IMessageElementLookup[type])
                    : null);
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(IContextElement).IsAssignableFrom(objectType);
        }

        private static string ToEnumString(TextType type)
        {
            var enumType = typeof(TextType);
            var name = Enum.GetName(enumType, type);
            var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetTypeInfo().GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).FirstOrDefault();
            return enumMemberAttribute?.Value ?? type.ToString();
        }
    }
}