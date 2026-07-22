using Newtonsoft.Json;
using System;

namespace Slack.NetStandard.JsonConverters
{
    public abstract class SingleAsArrayConverter<T> : JsonConverter<T>
    {
        public abstract T ReadSingle(JsonReader reader, JsonSerializer serializer);

        public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartArray)
            {
                throw new NotImplementedException("Unknown token type when trying to deserialize array");
            }

            var value = ReadSingle(reader, serializer);
            reader.Read();
            return value;
        }

        public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            serializer.Serialize(writer, value);
            writer.WriteEndArray();
        }
    }
}
