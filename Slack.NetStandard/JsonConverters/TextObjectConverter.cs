using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Slack.NetStandard.JsonConverters
{
    public class TextObjectConverter : JsonConverter<TextObject>
    {
        public override void WriteJson(JsonWriter writer, TextObject value, JsonSerializer serializer)
        {
            if (value is PlainText pt && pt.WasConvertedFromString)
            {
                writer.WriteValue(value.Text);
                return;
            }
            writer.WriteStartObject();
            writer.WritePropertyName("type");
            if (value.Type == TextType.PlainText)
            {
                writer.WriteValue("plain_text");
            }
            else
            {
                writer.WriteValue("mrkdwn");
            }

            writer.WritePropertyName("text");
            writer.WriteValue(value.Text);

            if (value.Emoji.HasValue)
            {
                writer.WritePropertyName("emoji");
                writer.WriteValue(value.Emoji.Value);
            }

            if (value.Verbatim.HasValue)
            {
                writer.WritePropertyName("verbatim");
                writer.WriteValue(value.Verbatim.Value);
            }
            

            writer.WriteEndObject();
        }

        public override TextObject ReadJson(JsonReader reader, Type objectType, TextObject existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                return new PlainText(reader.Value?.ToString()){ WasConvertedFromString =true};
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
