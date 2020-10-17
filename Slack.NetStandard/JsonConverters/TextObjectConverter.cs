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
            if (value is PlainText plt)
            {
                writer.WriteValue("plain_text");
                if (plt.Emoji.HasValue)
                {
                    writer.WritePropertyName("emoji");
                    writer.WriteValue(plt.Emoji.Value);
                }
            }
            else
            {
                var mrk = value as MarkdownText;
                writer.WriteValue("mrkdwn");
                if (mrk.Verbatim.HasValue)
                {
                    writer.WritePropertyName("verbatim");
                    writer.WriteValue(mrk.Verbatim.Value);
                }
            }

            writer.WritePropertyName("text");
            writer.WriteValue(value.Text);

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

            var target = jObject.Value<string>("type") == "plain_text" ? new PlainText() : (TextObject)new MarkdownText();

            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }
    }
}
