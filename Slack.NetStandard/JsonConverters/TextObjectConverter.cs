using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.JsonConverters
{
    public class TextObjectConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            var target = jObject.Value<string>("type") == "plain_text" ? (TextObject)new PlainText() : (TextObject)new MarkdownText();

            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(TextObject).IsAssignableFrom(objectType);
        }
    }
}
