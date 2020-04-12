using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Slack.NetStandard.Messages;

namespace Slack.NetStandard.JsonConverters
{
    public class TextObjectConverter : JsonConverter<TextObject>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, TextObject value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override TextObject ReadJson(JsonReader reader, Type objectType, TextObject existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                return new PlainText(reader.Value?.ToString());
            }

            if (objectType != typeof(TextObject))
            {
                var known = Activator.CreateInstance(objectType);
                serializer.Populate(reader,known);
                return (TextObject) known;
            }
            var jObject = JObject.Load(reader);

            var target = jObject.Value<string>("type") == "plain_text" ? (TextObject)new PlainText() : (TextObject)new MarkdownText();

            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }
    }
}
